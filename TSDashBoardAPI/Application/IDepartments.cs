using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IDepartmentsService
    {
        Task<Departments> GetDepartmentsByIdAsync(int id);
        Task<IEnumerable<Departments>> GetAllDepartmentAsync();
        Task AddDepartmentsAsync(Departments departments);
        Task UpdateDepartmentsAsync(Departments departments);
        Task DeleteDepartmentsAsync(int id);
    }
}
