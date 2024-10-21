namespace TeksaHDashboard.Models
{
    public class AttendanceRecordsViewModel
    {
        public required int Id { get; set; }
        public required int EmployeeId { get; set; }
        public required DateTime Date { get; set; }
        public required string Status { get; set; }
        
    }
}
