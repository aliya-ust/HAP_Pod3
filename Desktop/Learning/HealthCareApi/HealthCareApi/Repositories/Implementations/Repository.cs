using HealthCareApi.Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HealthCareApi.Repositories.Interfaces;

namespace HealthCareApi.Repositories.Implementations
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

        public T GetById(int id) => _dbSet.Find(id);
        public List<T> GetAll() => _dbSet.ToList();
        public void Add(T entity) => _dbSet.Add(entity);
        public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;
        public void Delete(T entity) => _dbSet.Remove(entity);
    }
}
