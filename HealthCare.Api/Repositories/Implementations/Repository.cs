using HealthCare.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using HealthCare.Api.Data;

namespace HealthCare.Api.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly HealthCareDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(HealthCareDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id) =>
            await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _dbSet.ToListAsync();

        public async Task AddAsync(T entity) =>
            await _dbSet.AddAsync(entity);

        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is not null)
                _dbSet.Remove(entity);
        }
    }
}
