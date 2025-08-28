
using Microsoft.AspNetCore.Mvc;
using UMR.Requestor.Services;
using UMR.Requestor.ViewModels;

namespace UMR.Requestor.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRequestRepository _repo;
        public HomeController(IRequestRepository repo) => _repo = repo;

        public IActionResult Index()
        {
            var (total, completed, pending, rejected) = _repo.GetStatusSummary();
            var vm = new DashboardViewModel
            {
                TotalCount = total,
                Completed = completed,
                Pending = pending,
                Rejected = rejected,
                BusinessAreaCounts = _repo.GetBusinessAreaCounts(),
            };
            vm.Cards.Add(new DashboardCard { Title = "Total Count", Count = total, Css = "bg-primary" });
            vm.Cards.Add(new DashboardCard { Title = "Pending", Count = pending, Css = "bg-warning" });
            vm.Cards.Add(new DashboardCard { Title = "Completed", Count = completed, Css = "bg-success" });
            vm.Cards.Add(new DashboardCard { Title = "Reject", Count = rejected, Css = "bg-danger" });
            return View(vm);
        }
    }
}
