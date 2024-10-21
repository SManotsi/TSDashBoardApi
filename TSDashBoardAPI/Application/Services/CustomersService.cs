using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IGenericRepository<Customers> _customersRepository;

        public CustomersService(IGenericRepository<Customers> customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<Customers> GetCustomersByIdAsync(int id)
        {
            return await _customersRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Customers>> GetAllCustomerAsync()
        {
            return await _customersRepository.GetAllAsync();
        }

        public async Task AddCustomersAsync(Customers customers)
        {
            await _customersRepository.AddAsync(customers);
        }

        public async Task UpdateCustomersAsync(Customers customers)
        {
            await _customersRepository.UpdateAsync(customers);
        }

        public async Task DeleteCustomersAsync(int id)
        {
            await _customersRepository.DeleteAsync(id);
        }
    }
}
