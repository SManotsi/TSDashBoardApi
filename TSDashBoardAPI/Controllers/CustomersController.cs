using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TSDashBoardApi.Application;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomerController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomersById(int id)
        {
            var customers = await _customersService.GetCustomersByIdAsync(id);
            if (customers == null) return NotFound();
            return Ok(customers);
        }

        [HttpGet]
        public async Task<IEnumerable<Customers>> GetAllCustomer()
        {
            return await _customersService.GetAllCustomerAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomers([FromBody] Customers customers)
        {
            await _customersService.AddCustomersAsync(customers);
            return CreatedAtAction(nameof(GetCustomersById), new { id = customers.Id }, customers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomers(int id, [FromBody] Customers customers)
        {
            if (id != customers.Id) return BadRequest();

            await _customersService.UpdateCustomersAsync(customers);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            await _customersService.DeleteCustomersAsync(id);
            return NoContent();
        }
    }
}
