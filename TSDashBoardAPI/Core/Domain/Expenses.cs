namespace TSDashBoardApi.Core.Domain
{
    public class Expenses
    {
        public  int Id { get; set; }
        public required DateOnly ExpenseDate { get; set; }
        public required Decimal Amount { get; set; }
        public required string Category { get; set; }
        public string? Description { get; set; }
    }
}
