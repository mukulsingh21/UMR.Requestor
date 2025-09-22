namespace UMR.Requestor.Models
{
    /// <summary>
    /// Get Summary Status
    /// </summary>
    public class StatusSummary
    {
        public int Total { get; set; }
        public int New { get; set; }
        public int NotStarted { get; set; }
        public int OnGarnet { get; set; }
        public int Prioritization { get; set; }
        public int InProcess { get; set; }
        public int InstallDateAssigned { get; set; }
        public int Completed { get; set; }
        public int Pending { get; set; }
    }
}
