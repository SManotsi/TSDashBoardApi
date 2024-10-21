using Microsoft.EntityFrameworkCore;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id) 
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _dbSet.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
                
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task AddAsync(object invoices)
        {
            throw new NotImplementedException();
        }
    }
}
