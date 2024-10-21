using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TSDashBoardApi.Application;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeeController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesById(int id)
        {
            var employees = await _employeesService.GetEmployeesByIdAsync(id);
            if (employees == null) return NotFound();
            return Ok(employees);
        }

        [HttpGet]
        public async Task<IEnumerable<Employees>> GetAllEmployee()
        {
            return await _employeesService.GetAllEmployeeAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployees([FromBody] Employees employees)
        {
            await _employeesService.AddEmployeesAsync(employees);
            return CreatedAtAction(nameof(GetEmployeesById), new { id = employees.Id }, employees);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployees(int id, [FromBody] Employees employees)
        {
            if (id != employees.Id) return BadRequest();

            await _employeesService.UpdateEmployeesAsync(employees);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            await _employeesService.DeleteEmployeesAsync(id);
            return NoContent();
        }
    }
}
