using HealthCare.Shared;
using HealthCareApi.Repositories.Interfaces;
using HealthCareApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareApi.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> BookAppointmentAsync(Appointment appointment)
        {
            var patientExists = await _appointmentRepository
                .PatientExistsAsync(appointment.PatientId);

            if (!patientExists)
                return null;

            var doctorExists = await _appointmentRepository
                .DoctorExistsAsync(appointment.DoctorId);

            if (!doctorExists)
                return null;

            var slotExists = await _appointmentRepository
                .SlotExistsAsync(appointment.DoctorId, appointment.TimeSlot);

            if (!slotExists)
                return null;

            if (appointment.ScheduledDate.Date < DateTime.Today)
                return null;

            var isBooked = await _appointmentRepository
                .IsSlotBookedAsync(
                    appointment.DoctorId,
                    appointment.ScheduledDate,
                    appointment.TimeSlot);

            if (isBooked)
                return null;

            appointment.Status = "Pending";

            await _appointmentRepository.AddAsync(appointment);

            return appointment;
        }

        public async Task<PagedResult<Appointment>> GetPatientAppointmentsAsync(
            int patientId,
            string status = null,
            int pageNumber = 1,
            int pageSize = 10)
        {
            return await _appointmentRepository.GetPatientAppointmentsAsync(
                patientId, status, pageNumber, pageSize);
        }

        public async Task<PagedResult<Appointment>> GetDoctorAppointmentsAsync(
            int doctorId,
            string status = null,
            int pageNumber = 1,
            int pageSize = 10)
        {
            return await _appointmentRepository.GetDoctorAppointmentsAsync(
                doctorId, status, pageNumber, pageSize);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDateAsync(DateTime date)
        {
            return await _appointmentRepository.GetAppointmentsByDateAsync(date);
        }

        public async Task<List<string>> GetAvailableSlotsAsync(int doctorId, DateTime date)
        {
            var allSlots = await _appointmentRepository.GetDoctorSlotsAsync(doctorId);
            var bookedSlots = await _appointmentRepository.GetBookedSlotsAsync(doctorId, date);

            return allSlots.Except(bookedSlots).ToList();
        }

        public async Task<Appointment> ConfirmAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);

            if (appointment == null)
                return null;

            if (appointment.Status == "Cancelled" ||
                appointment.Status == "Completed")
                return null;

            appointment.Status = "Confirmed";

            await _appointmentRepository.UpdateAsync(appointment);

            return appointment;
        }

        public async Task<Appointment> CancelAppointmentAsync(int appointmentId, string reason)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);

            if (appointment == null)
                return null;

            if (appointment.Status == "Cancelled")
                return null;

            if (string.IsNullOrWhiteSpace(reason))
                return null;

            appointment.Status = "Cancelled";
            appointment.CancellationReason = reason;

            await _appointmentRepository.UpdateAsync(appointment);

            return appointment;
        }

        public async Task<PagedResult<Appointment>> GetUpcomingAppointmentsAsync(
            int? patientId,
            int? doctorId,
            int pageNumber,
            int pageSize)
        {
            return await _appointmentRepository.GetUpcomingAppointmentsAsync(
                patientId, doctorId, pageNumber, pageSize);
        }
    }
}