namespace TSDashBoardApi.Core.Domain
{
    public class PerformanceReviews
    {
        public int Id { get; set; }
        public int? StaffId { get; set; }
        public required DateOnly ReviewDate { get; set; }
        public required string Reviewer { get; set; }
        public int? Rating { get; set; }
        public string? Comments { get; set; }
    }
}
