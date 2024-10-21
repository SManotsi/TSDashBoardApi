using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly IGenericRepository<Transactions> _transactionsRepository;

        public TransactionsService(IGenericRepository<Transactions> transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }

        public async Task<Transactions> GetTransactionsByIdAsync(int id)
        {
            return await _transactionsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Transactions>> GetAllTransactionAsync()
        {
            return await _transactionsRepository.GetAllAsync();
        }

        public async Task AddTransactionsAsync(Transactions transactions)
        {
            await _transactionsRepository.AddAsync(transactions);
        }

        public async Task UpdateTransactionsAsync(Transactions transactions)
        {
            await _transactionsRepository.UpdateAsync(transactions);
        }

        public async Task DeleteTransactionsAsync(int id)
        {
            await _transactionsRepository.DeleteAsync(id);
        }
    }
}
