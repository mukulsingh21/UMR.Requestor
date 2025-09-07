namespace UMR.Requestor.Models
{
    /// <summary>
    /// Get Summary Status
    /// </summary>
    public class StatusSummary
    {
        public int total {  get; set; }
        public int completed { get; set; }
        public int pending { get; set; }
        public int rejected { get; set; }
    }
}
