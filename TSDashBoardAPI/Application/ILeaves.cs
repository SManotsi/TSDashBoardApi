using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface ILeavesService
    {
        Task<Leaves> GetLeavesByIdAsync(int id);
        Task<IEnumerable<Leaves>> GetAllLeaveAsync();
        Task AddLeavesAsync(Leaves leaves);
        Task UpdateLeavesAsync(Leaves leaves);
        Task DeleteLeavesAsync(int id);
    }
}
