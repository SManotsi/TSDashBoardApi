using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IPaymentsService
    {
        Task<Payments> GetPaymentsByIdAsync(int id);
        Task<IEnumerable<Payments>> GetAllPaymentAsync();
        Task AddPaymentsAsync(Payments payments);
        Task UpdatePaymentsAsync(Payments payments);
        Task DeletePaymentsAsync(int id);
    }
}
