
using System.Collections.Generic;

namespace UMR.Requestor.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalCount { get; set; }
        public int New { get; set; }
        public int NotStarted { get; set; }
        public int OnGarnet { get; set; }
        public int Prioritization { get; set; }
        public int InProcess { get; set; }
        public int InstallDateAssigned { get; set; }
        public int Completed { get; set; }
        public int Pending { get; set; }
        public List<DashboardCard> Cards { get; set; } = new();
        public Dictionary<string,int> BusinessAreaCounts { get; set; } = new();
    }
}
