using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentListDto?> GetByIdAsync(int id);
        Task<PagedResult<AppointmentListDto>> GetAllAsync(AppointmentFilter filter);
        Task AddAsync(CreateAppointmentDto dto);
        Task UpdateAsync(int id, UpdateAppointmentDto dto);
        Task DeleteAsync(int id);
    }
}
