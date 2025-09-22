using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using UMR.Requestor.Models;

namespace UMR.Requestor.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly ITempDataProvider _tempDataProvider;

        public GlobalExceptionMiddleware(RequestDelegate next, IWebHostEnvironment env, ITempDataProvider tempDataProvider)
        {
            _next = next;
            _env = env;
            _tempDataProvider = tempDataProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception (logging logic not shown here)
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handles exceptions by creating and rendering a custom error page
        /// </summary>
        /// <param name="context">The current HTTP context</param>
        /// <param name="exception">The exception that was caught</param>
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Set the HTTP status code based on exception type
            context.Response.StatusCode = GetStatusCode(exception);

            // Create the error model with user-friendly message
            var errorModel = CreateErrorModel(context, exception);

            // Setup view rendering context
            var (actionContext, viewData, tempData) = SetupViewContext(context, errorModel);

            // Find and validate the error view
            var view = FindAndValidateErrorView(context, actionContext);

            // Render the error view and send the response
            await RenderErrorView(context, view, actionContext, viewData, tempData);
        }

        /// <summary>
        /// Creates an ErrorViewModel with appropriate messages and request details
        /// </summary>
        private ErrorViewModel CreateErrorModel(HttpContext context, Exception exception)
        {
            return new ErrorViewModel
            {
                RequestId = context.TraceIdentifier,
                Message = GetUserFriendlyMessage(exception),
                DetailedMessage = _env.IsDevelopment() ? exception.ToString() : null
            };
        }

        /// <summary>
        /// Sets up the necessary context for rendering the view
        /// </summary>
        private (ActionContext actionContext, ViewDataDictionary<ErrorViewModel> viewData, ITempDataDictionary tempData)
            SetupViewContext(HttpContext context, ErrorViewModel errorModel)
        {
            var actionContext = new ActionContext(
                context,
                new RouteData(),
                new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor()
            );

            var viewData = new ViewDataDictionary<ErrorViewModel>(
                new EmptyModelMetadataProvider(),
                new ModelStateDictionary()
            )
            {
                Model = errorModel
            };

            var tempData = new TempDataDictionary(context, _tempDataProvider);

            return (actionContext, viewData, tempData);
        }

        /// <summary>
        /// Finds and validates the Error view
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Error view cannot be found</exception>
        private IView FindAndValidateErrorView(HttpContext context, ActionContext actionContext)
        {
            var viewEngine = context.RequestServices.GetRequiredService<ICompositeViewEngine>();
            var viewResult = viewEngine.FindView(actionContext, "Error", false);

            if (!viewResult.Success)
            {
                throw new InvalidOperationException(
                    $"Couldn't find the Error view. Searched locations: {string.Join(", ", viewResult.SearchedLocations)}"
                );
            }

            return viewResult.View;
        }

        /// <summary>
        /// Renders the error view and writes it to the response
        /// </summary>
        private async Task RenderErrorView(
            HttpContext context,
            IView view,
            ActionContext actionContext,
            ViewDataDictionary<ErrorViewModel> viewData,
            ITempDataDictionary tempData)
        {
            using var writer = new StringWriter();
            var viewContext = new ViewContext(
                actionContext,
                view,
                viewData,
                tempData,
                writer,
                new HtmlHelperOptions()
            );

            await view.RenderAsync(viewContext);
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync(writer.ToString());
        }

        private int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                ArgumentException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };
        }

        private string GetUserFriendlyMessage(Exception exception)
        {
            return exception switch
            {
                UnauthorizedAccessException => "You don't have permission to access this resource.",
                KeyNotFoundException => "The requested resource was not found.",
                ArgumentException => "Invalid request parameters.",
                _ => "An unexpected error occurred while processing your request."
            };
        }
    }
}
