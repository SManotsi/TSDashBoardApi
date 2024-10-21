using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly IGenericRepository<Departments> _departmentsRepository;

        public DepartmentsService(IGenericRepository<Departments> departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;
        }

        public async Task<Departments> GetDepartmentsByIdAsync(int id)
        {
            return await _departmentsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Departments>> GetAllDepartmentAsync()
        {
            return await _departmentsRepository.GetAllAsync();
        }

        public async Task AddDepartmentsAsync(Departments departments)
        {
            await _departmentsRepository.AddAsync(departments);
        }

        public async Task UpdateDepartmentsAsync(Departments departments)
        {
            await _departmentsRepository.UpdateAsync(departments);
        }

        public async Task DeleteDepartmentsAsync(int id)
        {
            await _departmentsRepository.DeleteAsync(id);
        }
    }
}
