using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IGenericRepository<Users> _usersRepository;

        public UsersService(IGenericRepository<Users> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Users> GetUsersByIdAsync(int id)
        {
            return await _usersRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Users>> GetAllUserAsync()
        {
            return await _usersRepository.GetAllAsync();
        }

        public async Task AddUsersAsync(Users users)
        {
            await _usersRepository.AddAsync(users);
        }

        public async Task UpdateUsersAsync(Users users)
        {
            await _usersRepository.UpdateAsync(users);
        }

        public async Task DeleteUsersAsync(int id)
        {
            await _usersRepository.DeleteAsync(id);
        }
    }
}
