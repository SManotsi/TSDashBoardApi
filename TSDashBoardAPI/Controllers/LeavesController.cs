using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TSDashBoardApi.Application;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveController : ControllerBase
    {
        private readonly ILeavesService _leavesService;
        public LeaveController(ILeavesService leavesService)
        {
            _leavesService = leavesService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeavesById(int id)
        {
            var leaves = await _leavesService.GetLeavesByIdAsync(id);
            if (leaves == null) return NotFound();
            return Ok(leaves);
        }

        [HttpGet]
        public async Task<IEnumerable<Leaves>> GetAllLeave()
        {
            return await _leavesService.GetAllLeaveAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddLeaves([FromBody] Leaves leaves)
        {
            await _leavesService.AddLeavesAsync(leaves);
            return CreatedAtAction(nameof(GetLeavesById), new { id = leaves.Id }, leaves);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeaves(int id, [FromBody] Leaves leaves)
        {
            if (id != leaves.Id) return BadRequest();

            await _leavesService.UpdateLeavesAsync(leaves);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeaves(int id)
        {
            await _leavesService.DeleteLeavesAsync(id);
            return NoContent();
        }
    }
}
