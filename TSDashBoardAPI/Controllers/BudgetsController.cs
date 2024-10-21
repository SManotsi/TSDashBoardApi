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
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetsService _budgetsService;

        public BudgetController(IBudgetsService budgetsService)
        {
            _budgetsService = budgetsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgetById(int id)
        {
            var budgets = await _budgetsService.GetBudgetsByIdAsync(id);
            if (budgets == null) return NotFound();
            return Ok(budgets);
        }

        [HttpGet]
        public async Task<IEnumerable<Budgets>> GetAllABudget()
        {
            return await _budgetsService.GetAllBudgetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddBudgets([FromBody] Budgets budgets)
        {
            await _budgetsService.AddBudgetsAsync(budgets);
            return CreatedAtAction(nameof(GetBudgetById), new { id = budgets.Id }, budgets);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBudgets(int id, [FromBody] Budgets budgets)
        {
            if (id != budgets.Id) return BadRequest();

            await _budgetsService.UpdateBudgetsAsync(budgets);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudgets(int id)
        {
            await _budgetsService.DeleteBudgetsAsync(id);
            return NoContent();
        }
    }
}
