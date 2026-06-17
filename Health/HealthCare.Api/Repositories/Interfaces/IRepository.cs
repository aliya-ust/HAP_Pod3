namespace HealthCare.Api.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<T>> GetAllAsync(CancellationToken ct = default);
        Task<T> CreateAsync(T entity, CancellationToken ct = default);
        Task<T> UpdateAsync(int id, T entity, CancellationToken ct = default);
        Task<T> DeleteAsync(T entity, CancellationToken ct = default);
    }
}
