using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IGenericRepository<Projects> _projectsRepository;

        public ProjectsService(IGenericRepository<Projects> projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public async Task<Projects> GetProjectsByIdAsync(int id)
        {
            return await _projectsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Projects>> GetAllProjectAsync()
        {
            return await _projectsRepository.GetAllAsync();
        }

        public async Task AddProjectsAsync(Projects projects)
        {
            await _projectsRepository.AddAsync(projects);
        }

        public async Task UpdateProjectsAsync(Projects projects)
        {
            await _projectsRepository.UpdateAsync(projects);
        }

        public async Task DeleteProjectsAsync(int id)
        {
            await _projectsRepository.DeleteAsync(id);
        }
    }
}
