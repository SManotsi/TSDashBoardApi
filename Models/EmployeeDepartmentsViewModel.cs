namespace TeksaHDashboard.Models
{
    public class EmployeeDepartmentsViewModel
    {

        public required int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public required DateOnly AssignmentDate { get; set; }
    }
}
