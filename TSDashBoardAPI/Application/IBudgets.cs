using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IBudgetsService
    {
        Task<Budgets> GetBudgetsByIdAsync(int id);
        Task<IEnumerable<Budgets>> GetAllBudgetAsync();
        Task AddBudgetsAsync(Budgets budgets);
        Task UpdateBudgetsAsync(Budgets budgets);
        Task DeleteBudgetsAsync(int id);
    }
}
