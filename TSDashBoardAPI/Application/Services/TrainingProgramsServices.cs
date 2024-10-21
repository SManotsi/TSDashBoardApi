using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class TrainingProgramsService : ITrainingProgramsService
    {
        private readonly IGenericRepository<TrainingPrograms> _trainingProgramsRepository;

        public TrainingProgramsService(IGenericRepository<TrainingPrograms> trainingProgramsRepository)
        {
            _trainingProgramsRepository = trainingProgramsRepository;
        }

        public async Task<TrainingPrograms> GetTrainingProgramsByIdAsync(int id)
        {
            return await _trainingProgramsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TrainingPrograms>> GetAllTrainingProgramAsync()
        {
            return await _trainingProgramsRepository.GetAllAsync();
        }

        public async Task AddTrainingProgramsAsync(TrainingPrograms trainingPrograms)
        {
            await _trainingProgramsRepository.AddAsync(trainingPrograms);
        }

        public async Task UpdateTrainingProgramsAsync(TrainingPrograms trainingPrograms)
        {
            await _trainingProgramsRepository.UpdateAsync(trainingPrograms);
        }

        public async Task DeleteTrainingProgramsAsync(int id)
        {
            await _trainingProgramsRepository.DeleteAsync(id);
        }
    }
}
