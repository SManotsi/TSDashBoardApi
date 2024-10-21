using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IFinancialsService
    {
        Task<Financials> GetFinancialsByIdAsync(int id);
        Task<IEnumerable<Financials>> GetAllFinancialAsync();
        Task AddFinancialsAsync(Financials financials);
        Task UpdateFinancialsAsync(Financials Financials);
        Task DeleteFinancialsAsync(int id);
    }
}
