using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TSDashBoardApi.Application;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeDepartmentController : ControllerBase
    {
        private readonly IEmployeeDepartmentsService _employeeDepartmentsService;

        public EmployeeDepartmentController(IEmployeeDepartmentsService employeeDepartmentsService)
        {
            _employeeDepartmentsService = employeeDepartmentsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeDepartmentsById(int id)
        {
            var employeeDepartments = await _employeeDepartmentsService.GetEmployeeDepartmentsByIdAsync(id);
            if (employeeDepartments == null) return NotFound();
            return Ok(employeeDepartments);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDepartments>> GetAllEmployeeDepartment()
        {
            return await _employeeDepartmentsService.GetAllEmployeeDepartmentAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeDepartments([FromBody] EmployeeDepartments employeeDepartments)
        {
            await _employeeDepartmentsService.AddEmployeeDepartmentsAsync(employeeDepartments);
            return CreatedAtAction(nameof(GetEmployeeDepartmentsById), new { id = employeeDepartments.Id }, employeeDepartments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeDepartments(int id, [FromBody] EmployeeDepartments employeeDepartments)
        {
            if (id != employeeDepartments.Id) return BadRequest();

            await _employeeDepartmentsService.UpdateEmployeeDepartmentsAsync(employeeDepartments);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDepartments(int id)
        {
            await _employeeDepartmentsService.DeleteEmployeeDepartmentsAsync(id);
            return NoContent();
        }
    }
}
