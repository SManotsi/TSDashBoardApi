using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class AttendanceRecordsService : IAttendanceRecordsService
    {
        private readonly IGenericRepository<AttendanceRecords> _attendanceRecordsRepository;

        public AttendanceRecordsService(IGenericRepository<AttendanceRecords> attendanceRecordsRepository)
        {
            _attendanceRecordsRepository = attendanceRecordsRepository;
        }

       public async Task<AttendanceRecords> GetAttendanceByIdAsync(int id)
        {
            return await _attendanceRecordsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<AttendanceRecords>> GetAllAttendanceAsync()
        {
            return await _attendanceRecordsRepository.GetAllAsync();
        }

        public async Task AddAttendanceRecordsAsync(AttendanceRecords attendanceRecords)
        {
            await _attendanceRecordsRepository.AddAsync(attendanceRecords);
        }

        public async Task UpdateAttendanceRecordsAsync(AttendanceRecords attendanceRecords)
        {
            await _attendanceRecordsRepository.UpdateAsync(attendanceRecords);
        }

        public async Task DeleteAttendanceRecordsAsync(int id)
        {
            await _attendanceRecordsRepository.DeleteAsync(id);
        }
    }
}
