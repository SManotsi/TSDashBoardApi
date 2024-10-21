namespace TeksaHDashboard.Models
{
    public class AnnouncementsViewModel
    {
        public int Id { get; set; }
        public required string Message { get; set; }
        public required DateTime CreatedDate { get; set; }
    }
}
