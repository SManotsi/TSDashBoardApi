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
    public class MeetingParticipantController : ControllerBase
    {
        private readonly IMeetingParticipantsService _meetingParticipantsService;

        public MeetingParticipantController(IMeetingParticipantsService meetingParticipantsService)
        {
            _meetingParticipantsService = meetingParticipantsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeetingParticipantsById(int id)
        {
            var meetingParticipants = await _meetingParticipantsService.GetMeetingParticipantsByIdAsync(id);
            if (meetingParticipants == null) return NotFound();
            return Ok(meetingParticipants);
        }

        [HttpGet]
        public async Task<IEnumerable<MeetingParticipants>> GetAllMeetingParticipant()
        {
            return await _meetingParticipantsService.GetAllMeetingParticipantAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddMeetingParticipants([FromBody] MeetingParticipants meetingParticipants)
        {
            await _meetingParticipantsService.AddMeetingParticipantsAsync(meetingParticipants);
            return CreatedAtAction(nameof(GetMeetingParticipantsById), new { id = meetingParticipants.Id }, meetingParticipants);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeetingParticipants(int id, [FromBody] MeetingParticipants meetingParticipants)
        {
            if (id != meetingParticipants.Id) return BadRequest();

            await _meetingParticipantsService.UpdateMeetingParticipantsAsync(meetingParticipants);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetingParticipants(int id)
        {
            await _meetingParticipantsService.DeleteMeetingParticipantsAsync(id);
            return NoContent();
        }
    }
}
