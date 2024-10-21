using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface ITimeTrackingService
    {
        Task<TimeTracking> GetTimeTrackingByIdAsync(int id);
        Task<IEnumerable<TimeTracking>> GetAllTimeTrackingsAsync();
        Task AddTimeTrackingAsync(TimeTracking timeTracking);
        Task UpdateTimeTrackingAsync(TimeTracking timeTracking);
        Task DeleteTimeTrackingAsync(int id);
    }
}
