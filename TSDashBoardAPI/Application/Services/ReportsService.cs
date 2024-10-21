using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class ReportsService : IReportsService
    {
        private readonly IGenericRepository<Reports> _reportsRepository;

        public ReportsService(IGenericRepository<Reports> reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }

        public async Task<Reports> GetReportsByIdAsync(int id)
        {
            return await _reportsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Reports>> GetAllReportAsync()
        {
            return await _reportsRepository.GetAllAsync();
        }

        public async Task AddReportsAsync(Reports reports)
        {
            await _reportsRepository.AddAsync(reports);
        }

        public async Task UpdateReportsAsync(Reports reports)
        {
            await _reportsRepository.UpdateAsync(reports);
        }

        public async Task DeleteReportsAsync(int id)
        {
            await _reportsRepository.DeleteAsync(id);
        }
    }
}
