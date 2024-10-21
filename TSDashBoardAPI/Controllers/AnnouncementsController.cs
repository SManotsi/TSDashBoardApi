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
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementsService _announcementsService;

        public AnnouncementController(IAnnouncementsService announcementsService)
        {
            _announcementsService = announcementsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncementById(int id)
        {
            var announcements = await _announcementsService.GetAnnouncementsByIdAsync(id);
            if (announcements == null) return NotFound();
            return Ok(announcements);
        }

        [HttpGet]
        public async Task<IEnumerable<Announcements>> GetAllAnnouncement()
        {
            return await _announcementsService.GetAllAnnouncementAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddAnnouncements([FromBody] Announcements announcements)
        {
            await _announcementsService.AddAnnouncementstAsync(announcements);
            return CreatedAtAction(nameof(GetAnnouncementById), new { id = announcements.Id }, announcements);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnnouncements(int id, [FromBody] Announcements announcements)
        {
            if (id != announcements.Id) return BadRequest();

            await _announcementsService.UpdateAnnouncementsAsync(announcements);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncements(int id)
        {
            await _announcementsService.DeleteAnnouncementsAsync(id);
            return NoContent();
        }
    }
}
