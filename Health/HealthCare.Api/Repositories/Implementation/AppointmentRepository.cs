using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Repositories.Implementation
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(HealthCareDbContext context)
            : base(context)
        {
        }

        public async Task<List<Appointment>> GetAppointmentsByPatientIdAsync(
            int patientId,
            CancellationToken ct = default)
        {
            return await _context.Set<Appointment>()
                .Where(a => a.PatientId == patientId)
                .ToListAsync(ct);
        }

        public async Task<List<Appointment>> GetAppointmentsByDoctorIdAsync(
            int doctorId,
            CancellationToken ct = default)
        {
            return await _context.Set<Appointment>()
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync(ct);
        }

        public async Task<List<Appointment>> GetConfirmedAppointmentsAsync(
            CancellationToken ct = default)
        {
            return await _context.Set<Appointment>()
                .Where(a => a.Status == "Confirmed")
                .ToListAsync(ct);
        }
    }
}
