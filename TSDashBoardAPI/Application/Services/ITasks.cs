using System.Threading.Tasks;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface ITaskService
    {
        Task<Task> GetTaskByIdAsync(int id);
        Task<IEnumerable<Task>> GetAllTasksAsync();
        Task AddTaskAsync(Task task);
        Task UpdateTaskAsync(Task task);
        Task DeleteTaskAsync(int id);
    }
}
