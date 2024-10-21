using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface ICustomerProjectsService
    {
        Task<CustomerProjects> GetCustomerProjectsByIdAsync(int id);
        Task<IEnumerable<CustomerProjects>> GetAllCustomerPAsync();
        Task AddCustomerProjectsAsync(CustomerProjects customerProjects);
        Task UpdateCustomerProjectsAsync(CustomerProjects customerProjects);
        Task DeleteCustomerProjectsAsync(int id);
    }
}
