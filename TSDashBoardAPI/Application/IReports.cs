using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IReportsService
    {
        Task<Reports> GetReportsByIdAsync(int id);
        Task<IEnumerable<Reports>> GetAllReportAsync();
        Task AddReportsAsync(Reports reports);
        Task UpdateReportsAsync(Reports Reports);
        Task DeleteReportsAsync(int id);
    }
}
