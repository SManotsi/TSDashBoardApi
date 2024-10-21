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
    public class ReportController : ControllerBase
    {
        private readonly IReportsService _reportsService;

        public ReportController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportsById(int id)
        {
            var reports = await _reportsService.GetReportsByIdAsync(id);
            if (reports == null) return NotFound();
            return Ok(reports);
        }

        [HttpGet]
        public async Task<IEnumerable<Reports>> GetAllReport()
        {
            return await _reportsService.GetAllReportAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddReports([FromBody] Reports reports)
        {
            await _reportsService.AddReportsAsync(reports);
            return CreatedAtAction(nameof(GetReportsById), new { id = reports.Id }, reports);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReports(int id, [FromBody] Reports reports)
        {
            if (id != reports.Id) return BadRequest();

            await _reportsService.UpdateReportsAsync(reports);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReports(int id)
        {
            await _reportsService.DeleteReportsAsync(id);
            return NoContent();
        }
    }
}
