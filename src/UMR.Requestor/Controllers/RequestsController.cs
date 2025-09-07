using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using UMR.Requestor.Models;
using UMR.Requestor.Services;

namespace UMR.Requestor.Controllers
{
    public class RequestsController : Controller
    {
        private readonly IRequestRepository _repo;
        public RequestsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public IActionResult My(string? requestor)
        {
            requestor ??= "External"; // default demo
            var items = _repo.GetByRequestor(requestor);
            ViewBag.Requestor = requestor;
            return View(items);
        }

        [HttpGet]
        public IActionResult All(string? projectNo, string? status, string? area, string? system, string? title)
        {
            var items = _repo.GetAll();
            if (!string.IsNullOrWhiteSpace(title)) items = items.Where(x => x.ProjectTitle.Contains(title, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<ProjectStatus>(status, out var s)) items = items.Where(x => x.ProjectStatus == s);
            if (!string.IsNullOrWhiteSpace(area)) items = items.Where(x => string.Equals(x.Ownership, area, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(system)) items = items.Where(x => string.Equals(x.SMEId, system, StringComparison.OrdinalIgnoreCase));
            return View(items);
        }

        [HttpGet]
        public IActionResult Edit(int id, string returnUrl)
        {
            var request = _repo.GetById(id);
            if (request == null)
                return NotFound();

            ViewBag.ReturnUrl = returnUrl;
            return View(request);
        }

        [HttpGet]
        public IActionResult GetNote(int id)
        {
            var request = _repo.GetById(id);
            if (request == null)
                return NotFound();
            return Content(request.Notes ?? "No notes available.");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public IActionResult EditPost(Request model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            _repo.Update(model);
            TempData["Message"] = "Request updated.";
            // Redirect to returnUrl if provided, otherwise to All
            return !string.IsNullOrEmpty(returnUrl)
                ? Redirect(returnUrl)
                : RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Request());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Request model)
        {
            if (!ModelState.IsValid)
            {
                return View (model);
            }

            _repo.Add(model);

            return RedirectToAction(nameof(All));
        }

    }
}
