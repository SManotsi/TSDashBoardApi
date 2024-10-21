using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface ITransactionsService
    {
        Task<Transactions> GetTransactionsByIdAsync(int id);
        Task<IEnumerable<Transactions>> GetAllTransactionAsync();
        Task AddTransactionsAsync(Transactions transactions);
        Task UpdateTransactionsAsync(Transactions transactions);
        Task DeleteTransactionsAsync(int id);
    }
}
