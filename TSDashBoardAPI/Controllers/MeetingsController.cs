using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TSDashBoardApi.Application;
using TSDashBoardApi.Application.Services;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingsService _meetingsService;

        public MeetingController(IMeetingsService meetingsService)
        {
            _meetingsService = meetingsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeetingsById(int id)
        {
            var meetings = await _meetingsService.GetMeetingsByIdAsync(id);
            if (meetings == null) return NotFound();
            return Ok(meetings);
        }

        [HttpGet]
        public async Task<IEnumerable<Meetings>> GetAllMeeting()
        {
            return await _meetingsService.GetAllMeetingAsync();
        }


        [HttpPost]
        public async Task<IActionResult> AddMeetings([FromBody] Meetings meetings)
        {
            await _meetingsService.AddMeetingsAsync(meetings);
            return CreatedAtAction(nameof(GetMeetingsById), new { id = meetings.Id }, meetings);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeetings(int id, [FromBody] Meetings meetings)
        {
            if (id != meetings.Id) return BadRequest();

            await _meetingsService.UpdateMeetingsAsync(meetings);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetings(int id)
        {
            await _meetingsService.DeleteMeetingsAsync(id);
            return NoContent();
        }
    }
}
