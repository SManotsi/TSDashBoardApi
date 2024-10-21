using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class InvoiceService : IInvoicesService
    {
        private readonly IGenericRepository<Invoices> _invoicesRepository;

        public InvoiceService(IGenericRepository<Invoices> invoicesRepository)
        {
            _invoicesRepository = invoicesRepository;
        }

        public async Task<Invoices> GetInvoicesByIdAsync(int id)
        {
            return await _invoicesRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Invoices>> GetAllInvoiceAsync()
        {
            return await _invoicesRepository.GetAllAsync();
        }

        public async Task AddInvoicesAsync(Invoices invoices)
        {
            await _invoicesRepository.AddAsync(invoices);
        }

        public async Task UpdateInvoicesAsync(Invoices invoices)
        {
            await _invoicesRepository.UpdateAsync(invoices);
        }

        public async Task DeleteInvoicesAsync(int id)
        {
            await _invoicesRepository.DeleteAsync(id);
        }
    }
}
