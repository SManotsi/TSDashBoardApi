namespace TeksaHDashboard.Models
{
    public class EmployeesViewModel
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public required DateTime HireDate { get; set; }

        public required string Status { get; set; }
    }
}
