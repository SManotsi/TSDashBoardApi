namespace TSDashBoardApi.Core.Domain
{
    public class Meetings
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required DateTime Date { get; set; }
   
    }
}
