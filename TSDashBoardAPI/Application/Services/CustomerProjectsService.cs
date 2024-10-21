using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class CustomerProjectsService : ICustomerProjectsService
    {
        private readonly IGenericRepository<CustomerProjects> _customerProjectsRepository;

        public CustomerProjectsService(IGenericRepository<CustomerProjects> customerProjectsRepository)
        {
            _customerProjectsRepository = customerProjectsRepository;
        }

        public async Task<CustomerProjects> GetCustomerProjectsByIdAsync(int id)
        {
            return await _customerProjectsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CustomerProjects>> GetAllCustomerPAsync()
        {
            return await _customerProjectsRepository.GetAllAsync();
        }

        public async Task AddCustomerProjectsAsync(CustomerProjects customerProjects)
        {
            await _customerProjectsRepository.AddAsync(customerProjects);
        }

        public async Task UpdateCustomerProjectsAsync(CustomerProjects customerProjects)
        {
            await _customerProjectsRepository.UpdateAsync(customerProjects);
        }

        public async Task DeleteCustomerProjectsAsync(int id)
        {
            await _customerProjectsRepository.DeleteAsync(id);
        }
    }
}
