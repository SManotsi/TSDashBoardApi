using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IEmployeesService
    {
        Task<Employees> GetEmployeesByIdAsync(int id);
        Task<IEnumerable<Employees>> GetAllEmployeeAsync();
        Task AddEmployeesAsync(Employees employees);
        Task UpdateEmployeesAsync(Employees employees);
        Task DeleteEmployeesAsync(int id);
    }
}
