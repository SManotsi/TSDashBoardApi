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
    public class SupportTicketsController : ControllerBase
    {
        private readonly ISupportTicketsService _supportTicketsService;

        public SupportTicketsController(ISupportTicketsService supportTicketsService)
        {
            _supportTicketsService = supportTicketsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupportTicketsById(int id)
        {
            var supportTickets = await _supportTicketsService.GetSupportTicketsByIdAsync(id);
            if (supportTickets == null) return NotFound();
            return Ok(supportTickets);
        }

        [HttpGet]
        public async Task<IEnumerable<SupportTickets>> GetAllSupportTicket()
        {
            return await _supportTicketsService.GetAllSupportTicketAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddSupportTickets([FromBody] SupportTickets supportTickets)
        {
            await _supportTicketsService.AddSupportTicketsAsync(supportTickets);
            return CreatedAtAction(nameof(GetSupportTicketsById), new { id = supportTickets.Id }, supportTickets);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupportTickets(int id, [FromBody] SupportTickets supportTickets)
        {
            if (id != supportTickets.Id) return BadRequest();

            await _supportTicketsService.UpdateSupportTicketsAsync(supportTickets);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupportTickets(int id)
        {
            await _supportTicketsService.DeleteSupportTicketsAsync(id);
            return NoContent();
        }
    }
}
