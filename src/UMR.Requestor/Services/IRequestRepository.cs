
using System.Collections.Generic;
using UMR.Requestor.Models;

namespace UMR.Requestor.Services
{
    public interface IRequestRepository
    {
        IEnumerable<Request> GetAll();
        IEnumerable<Request> GetByRequestor(string requestor);
        Request GetById(int id);
        void Add(Request request);
        StatusSummary GetStatusSummary();
        Dictionary<string, int> GetBusinessAreaCounts();

    void Update(Request request);
        Task<bool> Delete(int requestId);
    }
}
