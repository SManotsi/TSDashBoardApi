using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class EmployeeDepartmentsService : IEmployeeDepartmentsService
    {
        private readonly IGenericRepository<EmployeeDepartments> _employeeDepartmentsRepository;

        public EmployeeDepartmentsService(IGenericRepository<EmployeeDepartments> employeeDepartmentsRepository)
        {
            _employeeDepartmentsRepository = employeeDepartmentsRepository;
        }

        public async Task<EmployeeDepartments> GetEmployeeDepartmentsByIdAsync(int id)
        {
            return await _employeeDepartmentsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<EmployeeDepartments>> GetAllEmployeeDepartmentAsync()
        {
            return await _employeeDepartmentsRepository.GetAllAsync();
        }

        public async Task AddEmployeeDepartmentsAsync(EmployeeDepartments employeeDepartments)
        {
            await _employeeDepartmentsRepository.AddAsync(employeeDepartments);
        }

        public async Task UpdateEmployeeDepartmentsAsync(EmployeeDepartments employeeDepartments)
        {
            await _employeeDepartmentsRepository.UpdateAsync(employeeDepartments);
        }

        public async Task DeleteEmployeeDepartmentsAsync(int id)
        {
            await _employeeDepartmentsRepository.DeleteAsync(id);
        }
    }
}
