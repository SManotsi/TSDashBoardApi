using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class EmployeeTrainingsService : IEmployeeTrainingService
    {
        private readonly IGenericRepository<EmployeeTraining> _employeeTrainingRepository;

        public EmployeeTrainingsService(IGenericRepository<EmployeeTraining> employeeTrainingRepository)
        {
            _employeeTrainingRepository = employeeTrainingRepository;
        }

        public async Task<EmployeeTraining> GetEmployeeTrainingByIdAsync(int id)
        {
            return await _employeeTrainingRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<EmployeeTraining>> GetAllEmployeeTrainingsAsync()
        {
            return await _employeeTrainingRepository.GetAllAsync();
        }

        public async Task AddEmployeeTrainingAsync(EmployeeTraining employeeTraining)
        {
            await _employeeTrainingRepository.AddAsync(employeeTraining);
        }

        public async Task UpdateEmployeeTrainingAsync(EmployeeTraining employeeTraining)
        {
            await _employeeTrainingRepository.UpdateAsync(employeeTraining);
        }

        public async Task DeleteEmployeeTrainingAsync(int id)
        {
            await _employeeTrainingRepository.DeleteAsync(id);
        }
    }
}
