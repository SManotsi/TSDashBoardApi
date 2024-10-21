namespace TSDashBoardApi.Core.Domain
{
    public class Reports
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required DateOnly ReportDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? GeneratedBy { get; set; }
        public string? ReportType { get; set; }
    }
}
