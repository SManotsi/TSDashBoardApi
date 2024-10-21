using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class BudgetsService : IBudgetsService
    {
        private readonly IGenericRepository<Budgets> _budgetsRepository;

        public BudgetsService(IGenericRepository<Budgets> budgetsRepository)
        {
            _budgetsRepository = budgetsRepository;
        }

        public async Task<Budgets> GetBudgetsByIdAsync(int id)
        {
            return await _budgetsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Budgets>> GetAllBudgetAsync()
        {
            return await _budgetsRepository.GetAllAsync();
        }

        public async Task AddBudgetsAsync(Budgets budgets)
        {
            await _budgetsRepository.AddAsync(budgets);
        }

        public async Task UpdateBudgetsAsync(Budgets budgets)
        {
            await _budgetsRepository.UpdateAsync(budgets);
        }

        public async Task DeleteBudgetsAsync(int id)
        {
            await _budgetsRepository.DeleteAsync(id);
        }
    }
}
