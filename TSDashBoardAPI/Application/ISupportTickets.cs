using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface ISupportTicketsService
    {
        Task<SupportTickets> GetSupportTicketsByIdAsync(int id);
        Task<IEnumerable<SupportTickets>> GetAllSupportTicketAsync();
        Task AddSupportTicketsAsync(SupportTickets SupportTickets);
        Task UpdateSupportTicketsAsync(SupportTickets SupportTickets);
        Task DeleteSupportTicketsAsync(int id);
    }
}
