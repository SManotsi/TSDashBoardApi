namespace TeksaHDashboard.Models
{
    public class CustomerProjectsViewModel
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ProjectId { get; set; }
        public required DateTime AssignedDate { get; set; }

    }
}
