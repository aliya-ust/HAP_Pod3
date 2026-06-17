using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<Appointment>> GetAllAsync(CancellationToken ct = default);
        Task<Appointment> CreateAsync(Appointment appointment, CancellationToken ct = default);
        Task<Appointment> UpdateAsync(int id, Appointment appointment, CancellationToken ct = default);
        Task<Appointment> DeleteAsync(Appointment appointment, CancellationToken ct = default);

        Task<List<Appointment>> GetAppointmentsByPatientIdAsync(int patientId, CancellationToken ct = default);
        Task<List<Appointment>> GetAppointmentsByDoctorIdAsync(int doctorId, CancellationToken ct = default);
        Task<List<Appointment>> GetConfirmedAppointmentsAsync(CancellationToken ct = default);
    }
}
