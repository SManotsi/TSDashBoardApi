namespace TSDashBoardApi.Core.Domain
{
    public class Projects
    {
        public  int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Status { get; set; }
        public required DateOnly StartDate{ get; set; }
        public required DateOnly? EndDate { get; set; }
    }
}
