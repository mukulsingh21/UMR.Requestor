
using System;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UMR.Requestor.Models
{
    public class Request
    {
        [Required]
        public int RequestId { get; set; }
        /// <summary>
        /// Project title
        /// </summary>
        [Required]
        public string ProjectTitle { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public ProjectStatus ProjectStatus { get; set; }

        public string? Description { get; set; }
        public string? Reason { get; set; }
        public string? PIPP { get; set; }
        public string? UserStory { get; set; }
        public DateTime ITInstallDate { get; set; }
        public string? Ownership { get; set; }
        public string? SMEId { get; set; }
        public string? Notes { get; set; }
        public string? PriorityRanking { get; set; }
        public string? Contingency { get; set; }
        public string? Risk { get; set; }
        public string? BlueChip { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
