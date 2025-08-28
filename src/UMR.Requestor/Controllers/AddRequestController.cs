using Microsoft.AspNetCore.Mvc;
using UMR.Requestor.Data;

namespace UMR.Requestor.Controllers
{
    public class AddRequestController : Controller
    {
        private readonly AppDbContext _context;
        public AddRequestController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var addRequest = _context.Requests.ToList();

            return View(addRequest);
        }
    }
}
