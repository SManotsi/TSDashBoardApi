using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class PerformanceReviewsService : IPerformanceReviewsService
    {
        private readonly IGenericRepository<PerformanceReviews> _performanceReviewsRepository;

        public PerformanceReviewsService(IGenericRepository<PerformanceReviews> performanceReviewsRepository)
        {
            _performanceReviewsRepository = performanceReviewsRepository;
        }

        public async Task<PerformanceReviews> GetPerformanceReviewsByIdAsync(int id)
        {
            return await _performanceReviewsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PerformanceReviews>> GetAllPerformanceReviewAsync()
        {
            return await _performanceReviewsRepository.GetAllAsync();
        }

        public async Task AddPerformanceReviewsAsync(PerformanceReviews performanceReviews)
        {
            await _performanceReviewsRepository.AddAsync(performanceReviews);
        }

        public async Task UpdatePerformanceReviewsAsync(PerformanceReviews performanceReviews)
        {
            await _performanceReviewsRepository.UpdateAsync(performanceReviews);
        }

        public async Task DeletePerformanceReviewsAsync(int id)
        {
            await _performanceReviewsRepository.DeleteAsync(id);
        }
    }
}
