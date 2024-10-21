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
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantsService _participantsService;

        public ParticipantController(IParticipantsService participantsService)
        {
            _participantsService = participantsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantsById(int id)
        {
            var participants = await _participantsService.GetParticipantsByIdAsync(id);
            if (participants == null) return NotFound();
            return Ok(participants);
        }

        [HttpGet]
        public async Task<IEnumerable<Participants>> GetAllParticipant()
        {
            return await _participantsService.GetAllParticipantAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddParticipants([FromBody] Participants participants)
        {
            await _participantsService.AddParticipantsAsync(participants);
            return CreatedAtAction(nameof(GetParticipantsById), new { id = participants.Id }, participants);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParticipants(int id, [FromBody] Participants participants)
        {
            if (id != participants.Id) return BadRequest();

            await _participantsService.UpdateParticipantsAsync(participants);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipants(int id)
        {
            await _participantsService.DeleteParticipantsAsync(id);
            return NoContent();
        }
    }
}
