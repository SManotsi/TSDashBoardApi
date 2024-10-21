using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IMeetingParticipantsService
    {
        Task<MeetingParticipants> GetMeetingParticipantsByIdAsync(int id);
        Task<IEnumerable<MeetingParticipants>> GetAllMeetingParticipantAsync();
        Task AddMeetingParticipantsAsync(MeetingParticipants meetingParticipants);
        Task UpdateMeetingParticipantsAsync(MeetingParticipants meetingParticipants);
        Task DeleteMeetingParticipantsAsync(int id);
    }
}
