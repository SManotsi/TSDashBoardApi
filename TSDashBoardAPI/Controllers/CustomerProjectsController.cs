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
    public class CustomerPController : ControllerBase
    {
        private readonly ICustomerProjectsService _customerProjectsService;

        public CustomerPController(ICustomerProjectsService customerProjectsService)
        {
            _customerProjectsService = customerProjectsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerProjectsById(int id)
        {
            var customerProjects = await _customerProjectsService.GetCustomerProjectsByIdAsync(id);
            if (customerProjects == null) return NotFound();
            return Ok(customerProjects);
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerProjectsService>> GetAllCustomerP()
        {
            return (IEnumerable<CustomerProjectsService>)await _customerProjectsService.GetAllCustomerPAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerProjects([FromBody] CustomerProjects customerProjects)
        {
            await _customerProjectsService.AddCustomerProjectsAsync(customerProjects);
            return CreatedAtAction(nameof(GetCustomerProjectsById), new { id = customerProjects.Id }, customerProjects);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerProjects(int id, [FromBody] CustomerProjects customerProjects)
        {
            if (id != customerProjects.Id) return BadRequest();

            await _customerProjectsService.UpdateCustomerProjectsAsync(customerProjects);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerProjects(int id)
        {
            await _customerProjectsService.DeleteCustomerProjectsAsync(id);
            return NoContent();
        }
    }
}
