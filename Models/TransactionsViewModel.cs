namespace TeksaHDashboard.Models
{
    public class TransactionsViewModel
    {
        public required int Id { get; set; }
        public required string Description { get; set; }
        public required Decimal Amount { get; set; }
        public required DateOnly Date { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
