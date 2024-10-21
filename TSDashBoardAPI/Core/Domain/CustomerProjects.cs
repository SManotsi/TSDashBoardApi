namespace TSDashBoardApi.Core.Domain
{
    public class CustomerProjects
    {
        public  int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ProjectId { get; set; }
        public required DateTime AssignedDate { get; set; }
        
    }
}
