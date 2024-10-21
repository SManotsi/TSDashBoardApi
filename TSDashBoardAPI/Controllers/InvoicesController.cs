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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoicesService _invoicesService;

        public InvoiceController(IInvoicesService invoicesService)
        {
            _invoicesService = invoicesService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoicesById(int id)
        {
            var invoices = await _invoicesService.GetInvoicesByIdAsync(id);
            if (invoices == null) return NotFound();
            return Ok(invoices);
        }

        [HttpGet]
        public async Task<IEnumerable<Invoices>> GetAllInvoice()
        {
            return await _invoicesService.GetAllInvoiceAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoices([FromBody] Invoices invoices)
        {
            await _invoicesService.AddInvoicesAsync(invoices);
            return CreatedAtAction(nameof(GetInvoicesById), new { id = invoices.Id }, invoices);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoices(int id, [FromBody] Invoices invoices)
        {
            if (id != invoices.Id) return BadRequest();

            await _invoicesService.UpdateInvoicesAsync(invoices);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoices(int id)
        {
            await _invoicesService.DeleteInvoicesAsync(id);
            return NoContent();
        }
    }
}
