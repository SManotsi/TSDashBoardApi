using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class AnnouncementsService : IAnnouncementsService
    {
        private readonly IGenericRepository<Announcements> _announcementsRepository;

        public AnnouncementsService(IGenericRepository<Announcements> announcementsRepository)
        {
            _announcementsRepository = announcementsRepository;
        }

        public async Task<Announcements> GetAnnouncementsByIdAsync(int id)
        {
            return await _announcementsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Announcements>> GetAllAnnouncementAsync()
        {
            return await _announcementsRepository.GetAllAsync();
        }

        public async Task AddAnnouncementsAsync(Announcements announcements)
        {
            await _announcementsRepository.AddAsync(announcements);
        }

        public async Task UpdateAnnouncementsAsync(Announcements announcements)
        {
            await _announcementsRepository.UpdateAsync(announcements);
        }

        public async Task DeleteAnnouncementsAsync(int id)
        {
            await _announcementsRepository.DeleteAsync(id);
        }

        public Task AddAnnouncementstAsync(Announcements announcements)
        {
            throw new NotImplementedException();
        }
    }
}
