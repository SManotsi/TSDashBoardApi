using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TSDashBoardApi.Application;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingProgramController : ControllerBase
    {
        private readonly ITrainingProgramsService _trainingProgramsService;

        public TrainingProgramController(ITrainingProgramsService trainingProgramsService)
        {
            _trainingProgramsService = trainingProgramsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingProgramsById(int id)
        {
            var trainingPrograms = await _trainingProgramsService.GetTrainingProgramsByIdAsync(id);
            if (trainingPrograms == null) return NotFound();
            return Ok(trainingPrograms);
        }

        [HttpGet]
        public async Task<IEnumerable<TrainingPrograms>> GetAllTrainingProgram()
        {
            return await _trainingProgramsService.GetAllTrainingProgramAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainingPrograms([FromBody] TrainingPrograms trainingPrograms)
        {
            await _trainingProgramsService.AddTrainingProgramsAsync(trainingPrograms);
            return CreatedAtAction(nameof(GetTrainingProgramsById), new { id = trainingPrograms.Id }, trainingPrograms);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingPrograms(int id, [FromBody] TrainingPrograms trainingPrograms)
        {
            if (id != trainingPrograms.Id) return BadRequest();

            await _trainingProgramsService.UpdateTrainingProgramsAsync(trainingPrograms);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingPrograms(int id)
        {
            await _trainingProgramsService.DeleteTrainingProgramsAsync(id);
            return NoContent();
        }
    }
}
