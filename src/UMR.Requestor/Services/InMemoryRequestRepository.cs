
using System;
using System.Collections.Generic;
using System.Linq;
using UMR.Requestor.Models;

namespace UMR.Requestor.Services
{
    public class InMemoryRequestRepository : IRequestRepository
    {
        private readonly List<Request> _requests = new();
        private readonly object _lock = new();

        public InMemoryRequestRepository()
        {
            // Seed sample data similar to screenshots
            var rnd = new Random(42);
            string[] systems = new[] { "CPS", "Web Portal", "OnBase", "EDI", "SQL" };
            string[] areas = new[] { "Call/Claims", "Billing", "Treasury", "Case Install" };
            string[] types = new[] { "Enhancement", "New Dev", "Bug" };

            for (int i = 0; i < 40; i++)
            {
                var status = (ProjectStatus)(i % 5);
                _requests.Add(new Request
                {
                    ProjectNo = $"PCL{7000 + i}",
                    ProjectTitle = i % 3 == 0 ? "Duplicate Efficiency Initiative" : i % 4 == 0 ? "Inventory Assignment" : "Provider Search",
                    ProjectStatus = status,
                    ImpactedSystem = systems[rnd.Next(systems.Length)],
                    BusinessArea = areas[rnd.Next(areas.Length)],
                    TypeOfRequest = types[rnd.Next(types.Length)],
                    Requestor = i % 2 == 0 ? "Mukul Singh" : "Raj Abhishek",
                    CreatedDate = DateTime.UtcNow.AddDays(-rnd.Next(1, 400)),
                });
            }
        }

        public IEnumerable<Request> GetAll() => _requests.OrderByDescending(r => r.CreatedDate);

        public IEnumerable<Request> GetByRequestor(string requestor)
            => _requests.Where(r => string.Equals(r.Requestor, requestor, StringComparison.OrdinalIgnoreCase));

        public void Add(Request request)
        {
            lock (_lock)
            {
                request.ProjectNo = request.ProjectNo?.Trim().Length > 0 ? request.ProjectNo : $"PCL{7000 + _requests.Count}";
                request.CreatedDate = DateTime.UtcNow;
                _requests.Add(request);
            }
        }

        public (int total, int completed, int pending, int rejected) GetStatusSummary()
        {
            int total = _requests.Count;
            int completed = _requests.Count(r => r.ProjectStatus == ProjectStatus.Complete);
            int rejected = _requests.Count(r => r.ProjectStatus == ProjectStatus.Cancelled);
            int pending = total - completed - rejected;
            return (total, completed, pending, rejected);
        }

        public Dictionary<string, int> GetBusinessAreaCounts()
            => _requests.GroupBy(r => r.BusinessArea)
                        .ToDictionary(g => g.Key, g => g.Count());
    }
}
