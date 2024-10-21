using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TSDashBoardApi.Application;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;

        public DepartmentController(IDepartmentsService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentsById(int id)
        {
            var departments = await _departmentsService.GetDepartmentsByIdAsync(id);
            if (departments == null) return NotFound();
            return Ok(departments);
        }

        [HttpGet]
        public async Task<IEnumerable<Departments>> GetAllDepartment()
        {
            return await _departmentsService.GetAllDepartmentAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartments([FromBody] Departments departments)
        {
            await _departmentsService.AddDepartmentsAsync(departments);
            return CreatedAtAction(nameof(GetDepartmentsById), new { id = departments.Id }, departments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartments(int id, [FromBody] Departments departments)
        {
            if (id != departments.Id) return BadRequest();

            await _departmentsService.UpdateDepartmentsAsync(departments);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartments(int id)
        {
            await _departmentsService.DeleteDepartmentsAsync(id);
            return NoContent();
        }
    }
}
