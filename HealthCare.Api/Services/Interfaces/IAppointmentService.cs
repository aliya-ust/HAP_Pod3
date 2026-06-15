using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment?> GetByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(int id);
    }
}
