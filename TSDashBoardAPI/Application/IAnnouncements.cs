using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IAnnouncementsService
    {
        Task<Announcements> GetAnnouncementsByIdAsync(int id);
        Task<IEnumerable<Announcements>> GetAllAnnouncementAsync();
        Task AddAnnouncementstAsync(Announcements announcements);
        Task UpdateAnnouncementsAsync(Announcements announcements);
        Task DeleteAnnouncementsAsync(int id);
    }
}
