
using Microsoft.AspNetCore.Mvc;
using UMR.Requestor.Services;
using UMR.Requestor.ViewModels;

namespace UMR.Requestor.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequestRepository _repo;
        public HomeController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var statusSummary = _repo.GetStatusSummary();
            var vm = new DashboardViewModel
            {
                TotalCount = statusSummary.total,
                Completed = statusSummary.completed,
                Pending = statusSummary.pending,
                Rejected = statusSummary.rejected,
                BusinessAreaCounts = _repo.GetBusinessAreaCounts(),
            };
            vm.Cards.Add(new DashboardCard { Title = "Total Count", Count = statusSummary.total, Css = "bg-primary" });
            vm.Cards.Add(new DashboardCard { Title = "Pending", Count = statusSummary.pending, Css = "bg-warning" });
            vm.Cards.Add(new DashboardCard { Title = "Completed", Count = statusSummary.completed, Css = "bg-success" });
            vm.Cards.Add(new DashboardCard { Title = "Reject", Count = statusSummary.rejected, Css = "bg-danger" });
            return View(vm);
        }
    }
}
