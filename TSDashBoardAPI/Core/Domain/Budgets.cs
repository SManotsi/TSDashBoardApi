namespace TSDashBoardApi.Core.Domain
{
    public class Budgets
    {
        public  int Id { get; set; }
        public required string Department { get; set; }
        public required int FiscalYear { get; set; }
        public required decimal AllocatedAmount { get; set; }
        public required decimal SpentAmount { get; set; }
    }
}
