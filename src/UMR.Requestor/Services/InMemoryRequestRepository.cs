
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

            _requests = ExcelData.requests;
            
        }

        public IEnumerable<Request> GetAll() => _requests.OrderByDescending(r => r.ITInstallDate);

        public IEnumerable<Request> GetByRequestor(string requestor)
            => _requests.Where(r => string.Equals(r.Ownership, requestor, StringComparison.OrdinalIgnoreCase));

        public void Add(Request request)
        {
            lock (_lock)
            {
                request.CreatedDate = DateTime.UtcNow;
                _requests.Add(request);
            }
        }

        public (int total, int completed, int pending, int rejected) GetStatusSummary()
        {
            int total = _requests.Count;
            int completed = _requests.Count(r => r.ProjectStatus == ProjectStatus.Completed);
            int rejected = _requests.Count(r => r.ProjectStatus == ProjectStatus.NotStarted);
            int pending = total - completed - rejected;
            return (total, completed, pending, rejected);
        }

        public Dictionary<string, int> GetBusinessAreaCounts()
            => _requests.GroupBy(r => r.Ownership)
                        .ToDictionary(g => g.Key, g => g.Count());
    }
}
