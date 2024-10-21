namespace TSDashBoardApi.Core.Domain
{
    public class Financials
    {
        public int Id { get; set; }
        public required Decimal TotalRevenue { get; set; }
        public required Decimal TotalExpenses { get; set; }
        public required Decimal ProfitMargin { get; set; }
    }
}
