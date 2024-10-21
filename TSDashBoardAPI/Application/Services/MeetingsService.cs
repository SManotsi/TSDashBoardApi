using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class MeetingsService : IMeetingsService
    {
        private readonly IGenericRepository<Meetings> _meetingsRepository;

        public MeetingsService(IGenericRepository<Meetings> meetingsRepository)
        {
            _meetingsRepository = meetingsRepository;
        }

        public async Task<Meetings> GetMeetingsByIdAsync(int id)
        {
            return await _meetingsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Meetings>> GetAllMeetingAsync()
        {
            return await _meetingsRepository.GetAllAsync();
        }

        public async Task AddMeetingsAsync(Meetings meetings)
        {
            await _meetingsRepository.AddAsync(meetings);
        }

        public async Task UpdateMeetingsAsync(Meetings meetings)
        {
            await _meetingsRepository.UpdateAsync(meetings);
        }

        public async Task DeleteMeetingsAsync(int id)
        {
            await _meetingsRepository.DeleteAsync(id);
        }
    }
}
