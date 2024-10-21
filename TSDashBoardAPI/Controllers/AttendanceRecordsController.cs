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
    public class AttendanceRecordController : ControllerBase
    {
        private readonly IAttendanceRecordsService _attendanceRecordsService;

        public AttendanceRecordController(IAttendanceRecordsService attendanceRecords)
        {
            _attendanceRecordsService = attendanceRecords;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendanceRecordById(int id)
        {
            var attendanceRecords = await _attendanceRecordsService.GetAttendanceByIdAsync(id);
            if (attendanceRecords == null) return NotFound();
            return Ok(attendanceRecords);
        }

        [HttpGet]
        public async Task<IEnumerable<AttendanceRecords>> GetAllAttendanceRecord()
        {
            return await _attendanceRecordsService.GetAllAttendanceAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddAttendanceRecords([FromBody] AttendanceRecords attendanceRecords)
        {
            await _attendanceRecordsService.AddAttendanceRecordsAsync(attendanceRecords);
            return CreatedAtAction(nameof(GetAttendanceRecordById), new { id = attendanceRecords.Id }, attendanceRecords);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendanceRecords(int id, [FromBody] AttendanceRecords attendanceRecords)
        {
            if (id != attendanceRecords.Id) return BadRequest();

            await _attendanceRecordsService.UpdateAttendanceRecordsAsync(attendanceRecords);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivities(int id)
        {
            await _attendanceRecordsService.DeleteAttendanceRecordsAsync(id);
            return NoContent();
        }
    }
}
