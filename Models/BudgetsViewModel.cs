namespace TeksaHDashboard.Models
{
    public class BudgetsViewModel
    {
        public int Id { get; set; }
        public required string Department { get; set; }
        public required int FiscalYear { get; set; }
        public required decimal AllocatedAmount { get; set; }
        public required decimal SpentAmount { get; set; }
    }
}
