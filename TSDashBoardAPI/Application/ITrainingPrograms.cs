using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface ITrainingProgramsService
    {
        Task<TrainingPrograms> GetTrainingProgramsByIdAsync(int id);
        Task<IEnumerable<TrainingPrograms>> GetAllTrainingProgramAsync();
        Task AddTrainingProgramsAsync(TrainingPrograms trainingPrograms);
        Task UpdateTrainingProgramsAsync(TrainingPrograms trainingPrograms);
        Task DeleteTrainingProgramsAsync(int id);
    }
}
