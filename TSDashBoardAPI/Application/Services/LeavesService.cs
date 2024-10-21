using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class LeavesService : ILeavesService
    {
        private readonly IGenericRepository<Leaves> _leavesRepository;

        public LeavesService(IGenericRepository<Leaves> leavesRepository)
        {
            _leavesRepository = leavesRepository;
        }

        public async Task<Leaves> GetLeavesByIdAsync(int id)
        {
            return await _leavesRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Leaves>> GetAllLeaveAsync()
        {
            return await _leavesRepository.GetAllAsync();
        }

        public async Task AddLeavesAsync(Leaves leaves)
        {
            await _leavesRepository.AddAsync(leaves);
        }

        public async Task UpdateLeavesAsync(Leaves leaves)
        {
            await _leavesRepository.UpdateAsync(leaves);
        }

        public async Task DeleteLeavesAsync(int id)
        {
            await _leavesRepository.DeleteAsync(id);
        }
    }
}
