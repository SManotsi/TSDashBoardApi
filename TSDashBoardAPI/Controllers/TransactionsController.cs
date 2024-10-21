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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionsById(int id)
        {
            var transactions = await _transactionsService.GetTransactionsByIdAsync(id);
            if (transactions == null) return NotFound();
            return Ok(transactions);
        }

        [HttpGet]
        public async Task<IEnumerable<Transactions>> GetAllTransaction()
        {
            return await _transactionsService.GetAllTransactionAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddTransactions([FromBody] Transactions transactions)
        {
            await _transactionsService.AddTransactionsAsync(transactions);
            return CreatedAtAction(nameof(GetTransactionsById), new { id = transactions.Id }, transactions);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransactions(int id, [FromBody] Transactions transactions)
        {
            if (id != transactions.Id) return BadRequest();

            await _transactionsService.UpdateTransactionsAsync(transactions);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactions(int id)
        {
            await _transactionsService.DeleteTransactionsAsync(id);
            return NoContent();
        }
    }
}
