using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TSDashBoardApi.Application;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeTrackingsController : ControllerBase
    {
        private readonly ITimeTrackingService _timeTrackingService;

        public TimeTrackingsController(ITimeTrackingService timeTrackingService)
        {
            _timeTrackingService = timeTrackingService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimeTrackingById(int id)
        {
            var timeTracking = await _timeTrackingService.GetTimeTrackingByIdAsync(id);
            if (timeTracking == null) return NotFound();
            return Ok(timeTracking);
        }

        [HttpGet]
        public async Task<IEnumerable<TimeTracking>> GetAllTimeTrackings()
        {
            return await _timeTrackingService.GetAllTimeTrackingsAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddTimeTracking([FromBody] TimeTracking timeTracking)
        {
            await _timeTrackingService.AddTimeTrackingAsync(timeTracking);
            return CreatedAtAction(nameof(GetTimeTrackingById), new { id = timeTracking.Id }, timeTracking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTimeTracking(int id, [FromBody] TimeTracking timeTracking)
        {
            if (id != timeTracking.Id) return BadRequest();

            await _timeTrackingService.UpdateTimeTrackingAsync(timeTracking);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeTracking(int id)
        {
            await _timeTrackingService.DeleteTimeTrackingAsync(id);
            return NoContent();
        }
    }
}
