using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IGenericRepository<Task> _taskRepository;

        public TaskService(IGenericRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Task> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Task>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task AddTaskAsync(Task task)
        {
            await _taskRepository.AddAsync(task);
        }

        public async Task UpdateTaskAsync(Task task)
        {
            await _taskRepository.UpdateAsync(task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
        }
    }
}
