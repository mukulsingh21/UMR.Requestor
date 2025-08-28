using System;
using System.ComponentModel.DataAnnotations;

public class AddRequest
{
    [Key]
    public int RequestId { get; set; }  // Primary key

    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string WhyNeeded { get; set; }
    public required string PIPP { get; set; }
    public required string UserStory { get; set; }
    public DateTime InstallDate { get; set; }
    public required string Ownership { get; set; }
    public required string SME { get; set; }
    public required string Notes { get; set; }
    public required string Status { get; set; }
    public required string PriorityRanking { get; set; }
    public required string Contingency { get; set; }
    public required string Risk { get; set; }
    public required string BlueChip { get; set; }
}