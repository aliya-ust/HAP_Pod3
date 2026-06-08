using HealthAppWeb.Services;
using HealthAppWeb.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace HealthAppWeb.Services.Interfaces
{
    public interface IAppointmentService
    {
        // Patient
        AppointmentBookingViewModel GetBookingViewModel(int? doctorId = null);
        List<string> GetAvailableSlots(int doctorId, DateTime date);
        ServiceResult Book(AppointmentBookingViewModel vm, int currentUserId);
        List<PatientAppointmentListViewModel> GetPatientAppointments(int currentUserId);
        CancelAppointmentViewModel GetCancelViewModelForPatient(int appointmentId, int currentUserId);
        ServiceResult CancelByPatient(int appointmentId, string reason, int currentUserId);

        // Doctor
        DoctorScheduleViewModel GetDoctorSchedule(int currentUserId, DateTime filterDate);
        CancelAppointmentViewModel GetCancelViewModelForDoctor(int appointmentId, int currentUserId);
        ServiceResult CancelByDoctor(int appointmentId, string reason, int currentUserId);
        ServiceResult ConfirmByDoctor(int appointmentId, int currentUserId);
    }
}