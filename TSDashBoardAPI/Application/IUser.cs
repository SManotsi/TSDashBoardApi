using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IUsersService
    {
        Task<Users> GetUsersByIdAsync(int id);
        Task<IEnumerable<Users>> GetAllUserAsync();
        Task AddUsersAsync(Users users);
        Task UpdateUsersAsync(Users users);
        Task DeleteUsersAsync(int id);
    }
}
