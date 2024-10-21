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
    public class ActivityController : ControllerBase
    {
        private readonly IActivitiesService _activitiesService;

        public ActivityController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityById(int id)
        {
            var activities = await _activitiesService.GetActivitiesByIdAsync(id);
            if (activities == null) return NotFound();
            return Ok(activities);
        }

        [HttpGet]
        public async Task<IEnumerable<Activities>> GetAllActivity()
        {
            return await _activitiesService.GetAllActivityAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddActicvities([FromBody] Activities activities)
        {
            await _activitiesService.AddActivitiesAsync(activities);
            return CreatedAtAction(nameof(GetActivityById), new { id = activities.Id }, activities);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivities(int id, [FromBody] Activities activities)
        {
            if (id  != activities.Id) return BadRequest();

            await _activitiesService.UpdateActivitiesAsync(activities);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivities(int id)
        {
            await _activitiesService.DeleteActivitiesAsync(id);
            return NoContent();
        }
    }
}
