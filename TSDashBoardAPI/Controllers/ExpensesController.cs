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
    public class ExpenseController : ControllerBase
    {
        private readonly IExpensesService _expensesTrainingService;
       /*fix*/ private IExpensesService _expensesService;
        public ExpenseController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpensesById(int id)
        {
            var expenses = await _expensesTrainingService.GetExpensesByIdAsync(id);
            if (expenses == null) return NotFound();
            return Ok(expenses);
        }

        [HttpGet]
        public async Task<IEnumerable<Expenses>> GetAllExpense()
        {
            return await _expensesTrainingService.GetAllExpenseAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddExpenses([FromBody] Expenses expenses)
        {
            await _expensesTrainingService.AddExpensesAsync(expenses);
            return CreatedAtAction(nameof(GetExpensesById), new { id = expenses.Id }, expenses);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpenses(int id, [FromBody] Expenses expenses)
        {
            if (id != expenses.Id) return BadRequest();

            await _expensesTrainingService.UpdateExpensesAsync(expenses);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenses(int id)
        {
            await _expensesTrainingService.DeleteExpensesAsync(id);
            return NoContent();
        }
    }
}
