using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface ICustomersService
    {
        Task<Customers> GetCustomersByIdAsync(int id);
        Task<IEnumerable<Customers>> GetAllCustomerAsync();
        Task AddCustomersAsync(Customers customers);
        Task UpdateCustomersAsync(Customers customers);
        Task DeleteCustomersAsync(int id);
    }
}
