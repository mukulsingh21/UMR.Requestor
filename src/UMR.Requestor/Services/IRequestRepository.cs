
using System.Collections.Generic;
using UMR.Requestor.Models;

namespace UMR.Requestor.Services
{
    public interface IRequestRepository
    {
        IEnumerable<Request> GetAll();
        IEnumerable<Request> GetByRequestor(string requestor);
        void Add(Request request);
        (int total, int completed, int pending, int rejected) GetStatusSummary();
        Dictionary<string, int> GetBusinessAreaCounts();
    }
}
