namespace TSDashBoardApi.Core.Domain
{
    public class SupportTickets
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
