using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IAttendanceRecordsService
    {
        Task<AttendanceRecords> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<AttendanceRecords>> GetAllAttendanceAsync();
        Task AddAttendanceRecordsAsync(AttendanceRecords attendanceRecords);
        Task UpdateAttendanceRecordsAsync(AttendanceRecords attendanceRecords);
        Task DeleteAttendanceRecordsAsync(int id);
    }
}
