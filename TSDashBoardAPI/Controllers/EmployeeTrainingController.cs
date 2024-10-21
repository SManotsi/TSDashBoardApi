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
    public class EmployeeTrainingsController : ControllerBase
    {
        private readonly IEmployeeTrainingService _employeeTrainingService;

        public EmployeeTrainingsController(IEmployeeTrainingService employeeTrainingService)
        {
            _employeeTrainingService = employeeTrainingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeTrainingById(int id)
        {
            var employeeTraining = await _employeeTrainingService.GetEmployeeTrainingByIdAsync(id);
            if (employeeTraining == null) return NotFound();
            return Ok(employeeTraining);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeTraining>> GetAllEmployeeTrainings()
        {
            return await _employeeTrainingService.GetAllEmployeeTrainingsAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] EmployeeTraining employeeTraining)
        {
            await _employeeTrainingService.AddEmployeeTrainingAsync(employeeTraining);
            return CreatedAtAction(nameof(GetEmployeeTrainingById), new { id = employeeTraining.Id }, employeeTraining);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeTraining(int id, [FromBody] EmployeeTraining employeeTraining)
        {
            if (id != employeeTraining.Id) return BadRequest();

            await _employeeTrainingService.UpdateEmployeeTrainingAsync(employeeTraining);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeTraining(int id)
        {
            await _employeeTrainingService.DeleteEmployeeTrainingAsync(id);
            return NoContent();
        }
    }
}
