using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;    

namespace UMR.Requestor.Models
{
    public class Add_Request
    {
        [Key]
        public required string TitleOrTopic { get; set; } // Primary key
        public required string Description { get; set; }
        public required string WhyIsThisNeeded { get; set; }
        public required string PIPP { get; set; }
        public required string UserStory { get; set; }
        public DateTime ITInstallDate { get; set; }
        public required string Ownership { get; set; }
        public required string SME { get; set; }
        public required string Notes { get; set; }
        public required string Status { get; set; }
        public required string PriorityRanking { get; set; }
        public required string Contingency { get; set; }
        public required string Risk { get; set; }
        public required string BlueChip { get; set; }


    }
}
