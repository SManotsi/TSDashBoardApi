using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class TimeTrackingService : ITimeTrackingService
    {
        private readonly IGenericRepository<TimeTracking> _timeTrackingRepository;

        public TimeTrackingService(IGenericRepository<TimeTracking> timeTrackingRepository)
        {
            _timeTrackingRepository = timeTrackingRepository;
        }

        public async Task<TimeTracking> GetTimeTrackingByIdAsync(int id)
        {
            return await _timeTrackingRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TimeTracking>> GetAllTimeTrackingsAsync()
        {
            return await _timeTrackingRepository.GetAllAsync();
        }

        public async Task AddTimeTrackingAsync(TimeTracking timeTracking)
        {
            await _timeTrackingRepository.AddAsync(timeTracking);
        }

        public async Task UpdateTimeTrackingAsync(TimeTracking timeTracking)
        {
            await _timeTrackingRepository.UpdateAsync(timeTracking);
        }

        public async Task DeleteTimeTrackingAsync(int id)
        {
            await _timeTrackingRepository.DeleteAsync(id);
        }
    }
}
