using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class SupportTicketsService : ISupportTicketsService
    {
        private readonly IGenericRepository<SupportTickets> _supportTicketsRepository;

        public SupportTicketsService(IGenericRepository<SupportTickets> supportTicketsRepository)
        {
            _supportTicketsRepository = supportTicketsRepository;
        }

        public async Task<SupportTickets> GetSupportTicketsByIdAsync(int id)
        {
            return await _supportTicketsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SupportTickets>> GetAllSupportTicketAsync()
        {
            return await _supportTicketsRepository.GetAllAsync();
        }

        public async Task AddSupportTicketsAsync(SupportTickets supportTickets)
        {
            await _supportTicketsRepository.AddAsync(supportTickets);
        }

        public async Task UpdateSupportTicketsAsync(SupportTickets supportTickets)
        {
            await _supportTicketsRepository.UpdateAsync(supportTickets);
        }

        public async Task DeleteSupportTicketsAsync(int id)
        {
            await _supportTicketsRepository.DeleteAsync(id);
        }
    }
}
