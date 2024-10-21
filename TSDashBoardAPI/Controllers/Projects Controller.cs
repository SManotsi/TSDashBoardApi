using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TSDashBoardApi.Application;
using TSDashBoardApi.Application.Services;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectsService _projectsService;

        public ProjectController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectsById(int id)
        {
            var projects = await _projectsService.GetProjectsByIdAsync(id);
            if (projects == null) return NotFound();
            return Ok(projects);
        }

        [HttpGet]
        public async Task<IEnumerable<Projects>> GetAllProject()
        {
            return await _projectsService.GetAllProjectAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddProjects([FromBody] Projects projects)
        {
            await _projectsService.AddProjectsAsync(projects);
            return CreatedAtAction(nameof(GetProjectsById), new { id = projects.Id }, projects);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjects(int id, [FromBody] Projects projects)
        {
            if (id != projects.Id) return BadRequest();

            await _projectsService.UpdateProjectsAsync(projects);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjects(int id)
        {
            await _projectsService.DeleteProjectsAsync(id);
            return NoContent();
        }
    }
}
