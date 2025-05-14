using System.ComponentModel.DataAnnotations;

namespace MultiWheeler.Domain
{
    public class Report
    {
        public int ReportId { get; set; } //PK
        public string? IssueCategory { get; set; }

        [Required(ErrorMessage = "Description of issue is required.")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 200 characters.")]
        public string? IssueDescription { get; set; }
        public Customer? Customer { get; set; } //Navigation
        public int? CustomerId { get; set; } //FK
    }
}
