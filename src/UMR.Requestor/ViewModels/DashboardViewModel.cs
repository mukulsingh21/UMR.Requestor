
using System.Collections.Generic;

namespace UMR.Requestor.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalCount { get; set; }
        public int Completed { get; set; }
        public int Pending { get; set; }
        public int Rejected { get; set; }
        public List<DashboardCard> Cards { get; set; } = new();
        public Dictionary<string,int> BusinessAreaCounts { get; set; } = new();
    }
}
