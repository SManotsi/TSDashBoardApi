namespace TSDashBoardApi.Core.Domain
{
    public class Customers
    {
        public  int Id { get; set; }
        public required String Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public required DateOnly RegistrationDate { get; set; }
    }
}
