
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
        public RequestsController(IRequestRepository repo) => _repo = repo;

        [HttpGet]
        public IActionResult Add() => View(new Request());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Request model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _repo.Add(model);
            TempData["Message"] = "Request saved.";
            return RedirectToAction(nameof(My));
        }

        [HttpGet]
        public IActionResult My(string? requestor)
        {
            requestor ??= "Mukul Singh"; // default demo
            var items = _repo.GetByRequestor(requestor);
            ViewBag.Requestor = requestor;
            return View(items);
        }

        [HttpGet]
        public IActionResult All(string? projectNo, string? status, string? area, string? system, string? title)
        {
            var items = _repo.GetAll();
            if (!string.IsNullOrWhiteSpace(projectNo)) items = items.Where(x => x.ProjectNo.Contains(projectNo, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(title)) items = items.Where(x => x.ProjectTitle.Contains(title, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<ProjectStatus>(status, out var s)) items = items.Where(x => x.ProjectStatus == s);
            if (!string.IsNullOrWhiteSpace(area)) items = items.Where(x => string.Equals(x.BusinessArea, area, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(system)) items = items.Where(x => string.Equals(x.ImpactedSystem, system, StringComparison.OrdinalIgnoreCase));
            return View(items);
        }
    }
}
