using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IHealthRecordService
    {
        Task<HealthRecord?> GetByIdAsync(int id);
        Task<IEnumerable<HealthRecord>> GetAllAsync();
        Task AddAsync(HealthRecord healthRecord);
        Task UpdateAsync(HealthRecord healthRecord);
        Task DeleteAsync(int id);
    }
}
