
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
                TotalCount = statusSummary.Total,
                New = statusSummary.New,
                NotStarted = statusSummary.NotStarted,
                OnGarnet = statusSummary.OnGarnet,
                Prioritization = statusSummary.Prioritization,
                InProcess = statusSummary.InProcess,
                InstallDateAssigned = statusSummary.InstallDateAssigned,
                Completed = statusSummary.Completed,
                Pending = statusSummary.Pending,
                BusinessAreaCounts = _repo.GetBusinessAreaCounts(),
            };

            // Add cards with different colors for each status
            vm.Cards.Add(new DashboardCard { Title = "Total Requests", Count = statusSummary.Total, Css = "bg-primary text-white" });
            vm.Cards.Add(new DashboardCard { Title = "New", Count = statusSummary.New, Css = "bg-info text-white" });
            vm.Cards.Add(new DashboardCard { Title = "Not Started", Count = statusSummary.NotStarted, Css = "bg-secondary text-white" });
            vm.Cards.Add(new DashboardCard { Title = "On Garnet", Count = statusSummary.OnGarnet, Css = "bg-purple" });  // Custom class already has white text
            vm.Cards.Add(new DashboardCard { Title = "Prioritization", Count = statusSummary.Prioritization, Css = "bg-indigo" });  // Custom class already has white text
            vm.Cards.Add(new DashboardCard { Title = "In Process", Count = statusSummary.InProcess, Css = "bg-warning text-dark" });  // Dark text for better contrast
            vm.Cards.Add(new DashboardCard { Title = "Install Date Assigned", Count = statusSummary.InstallDateAssigned, Css = "bg-pink" });  // Custom class already has white text
            vm.Cards.Add(new DashboardCard { Title = "Completed", Count = statusSummary.Completed, Css = "bg-success text-white" });
            vm.Cards.Add(new DashboardCard { Title = "Pending", Count = statusSummary.Pending, Css = "bg-danger text-white" });

            return View(vm);
        }
    }
}
