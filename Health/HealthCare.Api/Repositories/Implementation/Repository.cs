using HealthCare.Api.Data;
using HealthCare.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly HealthCareDbContext _context;

        public Repository(HealthCareDbContext context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync(T entity, CancellationToken ct = default)
        {
            await _context.Set<T>().AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task<T> DeleteAsync(T entity, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Set<T>().ToListAsync(ct);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Set<T>().FindAsync(new object[] { id }, ct);
        }

        public async Task<T> UpdateAsync(int id, T entity, CancellationToken ct = default)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(ct);
            return entity;
        }
    }
}
