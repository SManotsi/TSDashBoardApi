using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class ParticipantsService : IParticipantsService
    {
        private readonly IGenericRepository<Participants> _participantsRepository;

        public ParticipantsService(IGenericRepository<Participants> participantsRepository)
        {
            _participantsRepository = participantsRepository;
        }

        public async Task<Participants> GetParticipantsByIdAsync(int id)
        {
            return await _participantsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Participants>> GetAllParticipantAsync()
        {
            return await _participantsRepository.GetAllAsync();
        }

        public async Task AddParticipantsAsync(Participants participants)
        {
            await _participantsRepository.AddAsync(participants);
        }

        public async Task UpdateParticipantsAsync(Participants participants)
        {
            await _participantsRepository.UpdateAsync(participants);
        }

        public async Task DeleteParticipantsAsync(int id)
        {
            await _participantsRepository.DeleteAsync(id);
        }
    }
}
