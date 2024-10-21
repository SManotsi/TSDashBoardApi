namespace TeksaHDashboard.Models
{
    public class PerformanceReviewsViewModel
    {
        public int Id { get; set; }
        public int? StaffId { get; set; }
        public required DateOnly ReviewDate { get; set; }
        public required string Reviewer { get; set; }
        public int? Rating { get; set; }
        public string? Comments { get; set; }
    }
}
