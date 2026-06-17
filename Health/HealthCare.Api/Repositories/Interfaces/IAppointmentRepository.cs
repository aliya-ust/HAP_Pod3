using HealthCare.Api.Models;

namespace HealthCare.Api.Repositories.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<List<Appointment>> GetAppointmentsByPatientIdAsync(
            int patientId,
            CancellationToken ct = default);

        Task<List<Appointment>> GetAppointmentsByDoctorIdAsync(
            int doctorId,
            CancellationToken ct = default);

        Task<List<Appointment>> GetConfirmedAppointmentsAsync(
            CancellationToken ct = default);
    }
}
