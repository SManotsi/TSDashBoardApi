using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly IGenericRepository<Activities> _activitiesRepository;

        public ActivitiesService(IGenericRepository<Activities> activitiesRepository)
        {
            _activitiesRepository = activitiesRepository;
        }

        public async Task<Activities> GetActivitiesByIdAsync(int id)
        {
            return await _activitiesRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Activities>> GetAllActivityAsync()
        {
            return await _activitiesRepository.GetAllAsync();
        }

        public async Task AddActivitiesAsync(Activities activities)
        {
            await _activitiesRepository.AddAsync(activities);
        }

        public async Task UpdateActivitiesAsync(Activities activities)
        {
            await _activitiesRepository.UpdateAsync(activities);
        }

        public async Task DeleteActivitiesAsync(int id)
        {
            await _activitiesRepository.DeleteAsync(id);
        }
    }
}
