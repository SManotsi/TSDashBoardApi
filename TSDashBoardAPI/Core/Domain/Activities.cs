namespace TSDashBoardApi.Core.Domain
{
    public class Activities
    {
        public  int Id { get; set; }
        public required int Activity { get; set; }
        public required string? Description { get; set; }
        public required decimal CreatedDate { get; set; }
        
    }                 
}
