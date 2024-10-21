using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IParticipantsService
    {
        Task<Participants> GetParticipantsByIdAsync(int id);
        Task<IEnumerable<Participants>> GetAllParticipantAsync();
        Task AddParticipantsAsync(Participants participants);
        Task UpdateParticipantsAsync(Participants participants);
        Task DeleteParticipantsAsync(int id);
    }
}
