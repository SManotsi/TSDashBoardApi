namespace TSDashBoardApi.Core.Domain
{
    public class Transactions
    {
        public required int Id { get; set; }
        public required string Description { get; set; }
        public required Decimal Amount { get; set; }
        public required DateOnly Date { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
