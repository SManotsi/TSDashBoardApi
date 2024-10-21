using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IGenericRepository<Employees> _employeesRepository;

        public EmployeesService(IGenericRepository<Employees> employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<Employees> GetEmployeesByIdAsync(int id)
        {
            return await _employeesRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Employees>> GetAllEmployeeAsync()
        {
            return await _employeesRepository.GetAllAsync();
        }

        public async Task AddEmployeesAsync(Employees employees)
        {
            await _employeesRepository.AddAsync(employees);
        }

        public async Task UpdateEmployeesAsync(Employees employees)
        {
            await _employeesRepository.UpdateAsync(employees);
        }

        public async Task DeleteEmployeesAsync(int id)
        {
            await _employeesRepository.DeleteAsync(id);
        }
    }
}
