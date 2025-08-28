
using System;
using System.ComponentModel.DataAnnotations;

namespace UMR.Requestor.Models
{
    public enum ProjectStatus { New, PLC_Pending, IT_Sizing_Complete, Complete, Cancelled }
    public class Request
    {
        [Required]
        public string ProjectNo { get; set; } = string.Empty;
        [Required]
        public string ProjectTitle { get; set; } = string.Empty;
        public ProjectStatus ProjectStatus { get; set; } = ProjectStatus.New;
        public string ImpactedSystem { get; set; } = string.Empty; // e.g., CPS, Web Portal, OnBase
        public string BusinessArea { get; set; } = string.Empty;   // e.g., Call/Claims, Billing
        public string TypeOfRequest { get; set; } = string.Empty;  // Enhancement, New Dev, Bug
        public string Requestor { get; set; } = string.Empty;
        public string? ExternalVendor { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? NeedByDate { get; set; }
        public string? ProblemStatement { get; set; }
        public string? ExpectedOutcome { get; set; }
    }
}
