using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IInvoicesService
    {
        Task<Invoices> GetInvoicesByIdAsync(int id);
        Task<IEnumerable<Invoices>> GetAllInvoiceAsync();
        Task AddInvoicesAsync(Invoices invoices);
        Task UpdateInvoicesAsync(Invoices invoices);
        Task DeleteInvoicesAsync(int id);
    }
}
