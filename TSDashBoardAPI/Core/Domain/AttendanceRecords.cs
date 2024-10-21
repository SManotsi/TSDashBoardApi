using System;

namespace TSDashBoardApi.Core.Domain
{
    public class AttendanceRecords
    {
        public required int Id { get; set; }
        public required int EmployeeId { get; set; }
        public required DateTime Date { get; set; }
        public required string Status { get; set; }

    }
}
