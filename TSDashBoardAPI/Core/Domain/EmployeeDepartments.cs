namespace TSDashBoardApi.Core.Domain
{
    public class EmployeeDepartments
    {
        public required int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public  required DateOnly AssignmentDate { get; set; }
  
    }
}
