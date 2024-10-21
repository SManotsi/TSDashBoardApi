using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IGenericRepository<Expenses> _expensesRepository;

        public ExpensesService(IGenericRepository<Expenses> expensesRepository)
        {
            _expensesRepository = expensesRepository;
        }

        public async Task<Expenses> GetExpensesByIdAsync(int id)
        {
            return await _expensesRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Expenses>> GetAllExpenseAsync()
        {
            return await _expensesRepository.GetAllAsync();
        }

        public async Task AddExpensesAsync(Expenses expenses)
        {
            await _expensesRepository.AddAsync(expenses);
        }

        public async Task UpdateExpensesAsync(Expenses expenses)
        {
            await _expensesRepository.UpdateAsync(expenses);
        }

        public async Task DeleteExpensesAsync(int id)
        {
            await _expensesRepository.DeleteAsync(id);
        }
    }
}
