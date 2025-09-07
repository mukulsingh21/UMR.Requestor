using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UMR.Requestor.Data;
using UMR.Requestor.Models;

namespace UMR.Requestor.Services
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _appDbContext;

        public RequestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Get summary status of dashboard
        /// </summary>
        /// <returns></returns>
        public StatusSummary GetStatusSummary()
        {
            var statusSummary = new StatusSummary();
            var requestList = _appDbContext.Requests.ToList();
            statusSummary.total = requestList.Count;
            statusSummary.completed = requestList.Count(r => r.ProjectStatus == ProjectStatus.Completed);
            statusSummary.rejected = requestList.Count(r => r.ProjectStatus == ProjectStatus.NotStarted);
            statusSummary.pending = statusSummary.total - statusSummary.completed - statusSummary.rejected;
            return statusSummary;
        }

        /// <summary>
        /// Get bussiness count
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetBusinessAreaCounts()
        {
            return _appDbContext.Requests.GroupBy(r => r.Ownership ?? "Unassigned")
                                .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Get complete list of data
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Request> GetAll()
        {
            return _appDbContext.Requests.ToList();
        }

        /// <summary>
        /// Get data from DB as per Ownership
        /// </summary>
        /// <param name="requestor"></param>
        /// <returns></returns>
        public IEnumerable<Request> GetByRequestor(string requestor)
        {
            return _appDbContext.Requests.Where(r => string.Equals(r.Ownership, requestor));
        }

        /// <summary>
        /// Get request by Id
        /// </summary>
        /// <param name="id"></param>
        public Request GetById(int id)
        {
            return _appDbContext.Requests.FirstOrDefault(r => r.RequestId == id);
        }

        /// <summary>
        /// Adding request to DB
        /// </summary>
        /// <param name="request"></param>
        public void Add(Request request)
        {
            request.CreatedDate = DateTime.UtcNow;
            _appDbContext.Add(request);
            Save();
        }

        /// <summary>
        /// Deleting request from DB
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int requestId)
        {
            var request = await _appDbContext.Requests.FindAsync(requestId);
           if (request == null)
                return false;

            _appDbContext.Requests.Remove(request);
            Save();
            return true;
        }

        public void Update(Request request)
        {
            _appDbContext.Requests.Update(request);
            Save();
        }

        /// <summary>
        /// Save the Data to DB
        /// </summary>
        private void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
