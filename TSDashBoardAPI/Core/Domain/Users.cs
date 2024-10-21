namespace TSDashBoardApi.Core.Domain
{
    public class Users
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Role { get; set; }
        public required string Status { get; set; }
    }
}
