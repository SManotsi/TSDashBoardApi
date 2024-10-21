using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IEmployeeDepartmentsService
    {
        Task<EmployeeDepartments> GetEmployeeDepartmentsByIdAsync(int id);
        Task<IEnumerable<EmployeeDepartments>> GetAllEmployeeDepartmentAsync();
        Task AddEmployeeDepartmentsAsync(EmployeeDepartments employeeDepartments);
        Task UpdateEmployeeDepartmentsAsync(EmployeeDepartments employeeDepartments);
        Task DeleteEmployeeDepartmentsAsync(int id);
    }
}
