using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IMeetingsService
    {
        Task<Meetings> GetMeetingsByIdAsync(int id);
        Task<IEnumerable<Meetings>> GetAllMeetingAsync();
        Task AddMeetingsAsync(Meetings meetings);
        Task UpdateMeetingsAsync(Meetings meetings);
        Task DeleteMeetingsAsync(int id);
    }
}
