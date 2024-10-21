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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentsService _paymentsService;

        public PaymentController(IPaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentsById(int id)
        {
            var payments = await _paymentsService.GetPaymentsByIdAsync(id);
            if (payments == null) return NotFound();
            return Ok(payments);
        }

        [HttpGet]
        public async Task<IEnumerable<Payments>> GetAllPayment()
        {
            return await _paymentsService.GetAllPaymentAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddPayments([FromBody] Payments payments)
        {
            await _paymentsService.AddPaymentsAsync(payments);
            return CreatedAtAction(nameof(GetPaymentsById), new { id = payments.Id }, payments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayments(int id, [FromBody] Payments payments)
        {
            if (id != payments.Id) return BadRequest();

            await _paymentsService.UpdatePaymentsAsync(payments);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayments(int id)
        {
            await _paymentsService.DeletePaymentsAsync(id);
            return NoContent();
        }
    }
}
