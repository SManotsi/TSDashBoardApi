using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IPerformanceReviewsService
    {
        Task<PerformanceReviews> GetPerformanceReviewsByIdAsync(int id);
        Task<IEnumerable<PerformanceReviews>> GetAllPerformanceReviewAsync();
        Task AddPerformanceReviewsAsync(PerformanceReviews performanceReviews);
        Task UpdatePerformanceReviewsAsync(PerformanceReviews PerformanceReviews);
        Task DeletePerformanceReviewsAsync(int id);
    }
}
