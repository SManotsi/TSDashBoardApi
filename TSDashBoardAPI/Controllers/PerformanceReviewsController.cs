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
    public class PerformanceReviewController : ControllerBase
    {
        private readonly IPerformanceReviewsService _performanceReviewsService;

        public PerformanceReviewController(IPerformanceReviewsService performanceReviewsService)
        {
            _performanceReviewsService = performanceReviewsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerformanceReviewsById(int id)
        {
            var performanceReviews = await _performanceReviewsService.GetPerformanceReviewsByIdAsync(id);
            if (performanceReviews == null) return NotFound();
            return Ok(performanceReviews);
        }

        [HttpGet]
        public async Task<IEnumerable<PerformanceReviews>> GetAllPerformanceReview()
        {
            return await _performanceReviewsService.GetAllPerformanceReviewAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddPerformanceReviews([FromBody] PerformanceReviews performanceReviews)
        {
            await _performanceReviewsService.AddPerformanceReviewsAsync(performanceReviews);
            return CreatedAtAction(nameof(GetPerformanceReviewsById), new { id = performanceReviews.Id }, performanceReviews);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerformanceReviews(int id, [FromBody] PerformanceReviews performanceReviews)
        {
            if (id != performanceReviews.Id) return BadRequest();

            await _performanceReviewsService.UpdatePerformanceReviewsAsync(performanceReviews);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformanceReviews(int id)
        {
            await _performanceReviewsService.DeletePerformanceReviewsAsync(id);
            return NoContent();
        }
    }
}
