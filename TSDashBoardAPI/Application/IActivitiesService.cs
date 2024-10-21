using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IActivitiesService
    {
        Task<Activities> GetActivitiesByIdAsync(int id);
        Task<IEnumerable<Activities>> GetAllActivityAsync();
        Task AddActivitiesAsync(Activities activities);
        Task UpdateActivitiesAsync(Activities activities);
        Task DeleteActivitiesAsync(int id);
    }
}
