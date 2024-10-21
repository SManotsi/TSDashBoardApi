using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IExpensesService
    {
        Task<Expenses> GetExpensesByIdAsync(int id);
        Task<IEnumerable<Expenses>> GetAllExpenseAsync();
        Task AddExpensesAsync(Expenses expenses);
        Task UpdateExpensesAsync(Expenses Expenses);
        Task DeleteExpensesAsync(int id);
    }
}
