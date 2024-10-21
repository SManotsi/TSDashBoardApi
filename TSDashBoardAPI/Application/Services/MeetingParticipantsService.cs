using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class MeetingParticipantsService : IMeetingParticipantsService
    {
        private readonly IGenericRepository<MeetingParticipants> _meetingParticipantsRepository;

        public MeetingParticipantsService(IGenericRepository<MeetingParticipants> meetingParticipantsRepository)
        {
            _meetingParticipantsRepository = meetingParticipantsRepository;
        }

        public async Task<MeetingParticipants> GetMeetingParticipantsByIdAsync(int id)
        {
            return await _meetingParticipantsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<MeetingParticipants>> GetAllMeetingParticipantAsync()
        {
            return await _meetingParticipantsRepository.GetAllAsync();
        }

        public async Task AddMeetingParticipantsAsync(MeetingParticipants meetingParticipants)
        {
            await _meetingParticipantsRepository.AddAsync(meetingParticipants);
        }

        public async Task UpdateMeetingParticipantsAsync(MeetingParticipants meetingParticipants)
        {
            await _meetingParticipantsRepository.UpdateAsync(meetingParticipants);
        }

        public async Task DeleteMeetingParticipantsAsync(int id)
        {
            await _meetingParticipantsRepository.DeleteAsync(id);
        }
    }
}
