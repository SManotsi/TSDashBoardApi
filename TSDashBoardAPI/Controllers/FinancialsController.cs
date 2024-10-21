using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Microsoft.VisualBasic;
using TSDashBoardApi.Application;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
        public class FinancialController : ControllerBase
        {
            private readonly IFinancialsService _financialsService;

            public FinancialController(IFinancialsService financialsService)
            {
            _financialsService = financialsService;
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetFinancialsById(int id)
            {
                var financials = await _financialsService.GetFinancialsByIdAsync(id);
                if (financials == null) return NotFound();
                return Ok(financials);
            }

            [HttpGet]
            public async Task<IEnumerable<Financials>> GetAllFinancial()
            {
                return await _financialsService.GetAllFinancialAsync();
            }

            [HttpPost]
            public async Task<IActionResult> AddFinancials([FromBody] Financials financials)
            {
                await _financialsService.AddFinancialsAsync(financials);
                return CreatedAtAction(nameof(GetFinancialsById), new { id = financials.Id }, financials);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateFinancials(int id, [FromBody] Financials financials)
            {
                if (id != financials.Id) return BadRequest();

                await _financialsService.UpdateFinancialsAsync(financials);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteFinancials(int id)
            {
                await _financialsService.DeleteFinancialsAsync(id);
                return NoContent();
            }
        }
}
