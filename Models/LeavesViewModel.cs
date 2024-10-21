namespace TeksaHDashboard.Models
{
    public class LeavesViewModel
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public required string LeaveType { get; set; }
        public required DateOnly StartDate { get; set; }
        public required DateOnly EndDate { get; set; }
        public required string Status { get; set; }
    }
}
