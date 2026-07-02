using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentListDto?> GetByIdAsync(int id);
        Task<PagedResult<AppointmentListDto>> GetAllAsync(AppointmentFilter filter);
        Task UpdateAsync(int id, UpdateAppointmentDto dto);
        Task DeleteAsync(int id);
        Task<List<string>> AvailableTimeSlots(DateOnly date, int doctorId);
        Task<bool> IsAvailable(DateOnly date, int doctorId, string timeSlot);
        Task AddAsync(CreateAppointmentDto dto, int patientId);
        Task UpdateStatusAsync(int id, UpdateAppointmentDto dto);
        Task<List<AppointmentReportDto>> GetDailyReport(
                    DateOnly? startDate,
                    DateOnly? endDate);
        Task<List<AppointmentListDto>> GetDoctorSchedule(DateOnly date, int id);
        Task<List<AppointmentListDto>> GetPatientSchedule(DateOnly date, int id);
        Task<List<AppointmentListDto>> GetAppointmentByPatient(int id);
        Task<List<AppointmentListDto>> GetAppointmentByDoctor(int id);
        Task ConfirmAppointment(int appointmentId);

        Task CancelAppointment(int appointmentId);

        Task<List<DoctorDropdownDto>>GetAvailableDoctorsAsync(DateOnly date, string specialization);

        Task<List<string>>GetAvailableSlotsAsync(int doctorId, DateOnly date);

        Task ValidateDoctorAvailability(int doctorId, DateOnly date);
    }
}