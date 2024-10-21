using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IGenericRepository<Payments> _paymentsRepository;

        public PaymentsService(IGenericRepository<Payments> paymentsRepository)
        {
            _paymentsRepository = paymentsRepository;
        }

        public async Task<Payments> GetPaymentsByIdAsync(int id)
        {
            return await _paymentsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Payments>> GetAllPaymentAsync()
        {
            return await _paymentsRepository.GetAllAsync();
        }

        public async Task AddPaymentsAsync(Payments payments)
        {
            await _paymentsRepository.AddAsync(payments);
        }

        public async Task UpdatePaymentsAsync(Payments payments)
        {
            await _paymentsRepository.UpdateAsync(payments);
        }

        public async Task DeletePaymentsAsync(int id)
        {
            await _paymentsRepository.DeleteAsync(id);
        }
    }
}
