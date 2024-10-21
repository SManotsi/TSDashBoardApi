namespace TSDashBoardApi.Core.Domain
{
    public class TimeTracking
    {
        public required int Id { get; set; }
        public int? StaffId { get; set; }
        public int? ProjectId { get; set; }
        public required DateOnly Date { get; set; }
        public required Decimal HoursWorked { get; set; }
    }
}
