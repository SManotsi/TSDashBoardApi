using System.ComponentModel.DataAnnotations;

namespace TeksaHDashboard.Models
{
    public class MeetingsViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required DateTime Date { get; set; }
       
    }
}
