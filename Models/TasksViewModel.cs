namespace TeksaHDashboard.Models
{
    public class TasksViewModel
    {
        public required int Id { get; set; }
        public int? StaffId { get; set; }
        public int? ProjectId { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required string Status { get; set; }
        public required DateOnly? DueDate { get; set; }
        public required DateOnly CreatedDate { get; set; }
    }
}
