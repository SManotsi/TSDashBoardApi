using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class FinancialsService : IFinancialsService
    {
        private readonly IGenericRepository<Financials> _financialsRepository;

        public FinancialsService(IGenericRepository<Financials> financialsRepository)
        {
            _financialsRepository = financialsRepository;
        }

        public async Task<Financials> GetFinancialsByIdAsync(int id)
        {
            return await _financialsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Financials>> GetAllFinancialAsync()
        {
            return await _financialsRepository.GetAllAsync();
        }

        public async Task AddFinancialsAsync(Financials financials)
        {
            await _financialsRepository.AddAsync(financials);
        }

        public async Task UpdateFinancialsAsync(Financials financials)
        {
            await _financialsRepository.UpdateAsync(financials);
        }

        public async Task DeleteFinancialsAsync(int id)
        {
            await _financialsRepository.DeleteAsync(id);
        }
    }
}
