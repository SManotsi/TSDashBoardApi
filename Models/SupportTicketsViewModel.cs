namespace TeksaHDashboard.Models
{
    public class SupportTicketsViewModel
    {
        public required int Id { get; set; }
        public int? CustomerId { get; set; }
        public required string Subject { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public required DateTime CreatedDate { get; set; }
        public DateTime? ResolvedDate { get; set; }
    }
}
