using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IEmployeeTrainingService
    {
        Task<EmployeeTraining> GetEmployeeTrainingByIdAsync(int id);
        Task<IEnumerable<EmployeeTraining>> GetAllEmployeeTrainingsAsync();
        Task AddEmployeeTrainingAsync(EmployeeTraining employeeTraining);
        Task UpdateEmployeeTrainingAsync(EmployeeTraining employeeTraining);
        Task DeleteEmployeeTrainingAsync(int id);
    }
}
