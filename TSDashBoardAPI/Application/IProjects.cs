using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IProjectsService
    {
        Task<Projects> GetProjectsByIdAsync(int id);
        Task<IEnumerable<Projects>> GetAllProjectAsync();
        Task AddProjectsAsync(Projects projects);
        Task UpdateProjectsAsync(Projects Projects);
        Task DeleteProjectsAsync(int id);
    }
}
