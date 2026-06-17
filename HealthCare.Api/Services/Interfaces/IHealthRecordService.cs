using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.HealthRecord;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IHealthRecordService
    {
        Task<HealthRecordListDto?> GetByIdAsync(int id);
        Task<PagedResult<HealthRecordListDto>> GetAllAsync(HealthRecordFilter filter);
        Task AddAsync(CreateHealthRecordDto dto);
        Task UpdateAsync(int id, UpdateHealthRecordDto dto);
        Task DeleteAsync(int id);
        Task<List<HealthRecordListDto>> GetHealthRecordByPatient(int id);
        Task<List<HealthRecordListDto>> GetHealthRecordByAppointment(int id);
    }
}
