using HealthAppWeb.App_Start;
using HealthAppWeb.Models;
using HealthAppWeb.Services.Interfaces;
using HealthAppWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HealthAppWeb.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        // ── Patient: booking ───────────────────────────────────────

        public AppointmentBookingViewModel GetBookingViewModel(int? selectedDoctorId = null)
        {
            var vm = new AppointmentBookingViewModel
            {
                SelectedDate = DateTime.Today,

                Doctors = InMemoryStore.Doctors
                    .Where(d => d.IsActive)
                    .Select(d => new SelectListItem
                    {
                        Value = d.DoctorId.ToString(),
                        Text = d.FullName + " — " + d.Specialisation
                    })
                    .ToList(),

                AvailableSlots = new List<string>()
            };

            // ✅ THIS IS THE IMPORTANT PART
            if (selectedDoctorId.HasValue && selectedDoctorId.Value > 0)
            {
                vm.AvailableSlots = InMemoryStore.DoctorAvailableSlots
                    .Where(s => s.DoctorId == selectedDoctorId.Value)
                    .Select(s => s.TimeSlot)
                    .ToList();
            }

            return vm;
        }


        public List<string> GetAvailableSlots(int doctorId, DateTime date)
        {
            bool isOnLeave = InMemoryStore.DoctorLeaves.Exists(
                l => l.DoctorId == doctorId && l.LeaveDate.Date == date.Date
            );
            if (isOnLeave)
                return new List<string>();

            var allSlots = InMemoryStore.DoctorAvailableSlots
                .Where(s => s.DoctorId == doctorId)
                .Select(s => s.TimeSlot)
                .ToList();

            var bookedSlots = InMemoryStore.Appointments
                .Where(a => a.DoctorId == doctorId
                         && a.ScheduledDate.Date == date.Date
                         && (a.Status == "Pending" || a.Status == "Confirmed"))
                .Select(a => a.TimeSlot)
                .ToList();

            return allSlots.Where(s => !bookedSlots.Contains(s)).ToList();
        }

        public ServiceResult Book(AppointmentBookingViewModel vm, int currentUserId)
        {
            var patient = InMemoryStore.Patients.Find(p => p.UserId == currentUserId);
            if (patient == null)
                return ServiceResult.Fail("", "Patient record not found.");

            if (string.IsNullOrEmpty(vm.SelectedSlot))
                return ServiceResult.Fail("SelectedSlot", "Please select a time slot.");

            bool alreadyBooked = InMemoryStore.Appointments.Exists(a =>
                a.DoctorId == vm.SelectedDoctorId &&
                a.ScheduledDate.Date == vm.SelectedDate.Date &&
                a.TimeSlot == vm.SelectedSlot &&
                (a.Status == "Pending" || a.Status == "Confirmed")
            );
            if (alreadyBooked)
                return ServiceResult.Fail("SelectedSlot", "This slot was just taken. Please choose another.");

            InMemoryStore.Appointments.Add(new Appointment
            {
                AppointmentId = InMemoryStore.NextAppointmentId++,
                PatientId = patient.PatientId,
                DoctorId = vm.SelectedDoctorId,
                ScheduledDate = vm.SelectedDate,
                TimeSlot = vm.SelectedSlot,
                Status = "Pending",
                CreatedDate = DateTime.Now
            });

            return ServiceResult.Ok();
        }

        // ── Patient: appointments list ─────────────────────────────

        public List<PatientAppointmentListViewModel> GetPatientAppointments(int currentUserId)
        {
            var patient = InMemoryStore.Patients.Find(p => p.UserId == currentUserId);
            if (patient == null)
                return new List<PatientAppointmentListViewModel>();

            return InMemoryStore.Appointments
                .Where(a => a.PatientId == patient.PatientId)
                .OrderByDescending(a => a.ScheduledDate)
                .Select(a =>
                {
                    var doctor = InMemoryStore.Doctors.Find(d => d.DoctorId == a.DoctorId);
                    return new PatientAppointmentListViewModel
                    {
                        AppointmentId = a.AppointmentId,
                        DoctorName = doctor != null ? doctor.FullName : "Unknown",
                        Specialisation = doctor != null ? doctor.Specialisation : "",
                        ScheduledDate = a.ScheduledDate,
                        TimeSlot = a.TimeSlot,
                        Status = a.Status,
                        CancellationReason = a.CancellationReason
                    };
                })
                .ToList();
        }

        public CancelAppointmentViewModel GetCancelViewModelForPatient(int appointmentId, int currentUserId)
        {
            var patient = InMemoryStore.Patients.Find(p => p.UserId == currentUserId);
            if (patient == null)
                return null;

            var appt = InMemoryStore.Appointments.Find(
                a => a.AppointmentId == appointmentId && a.PatientId == patient.PatientId
            );
            if (appt == null || appt.Status != "Pending")
                return null;

            return new CancelAppointmentViewModel
            {
                AppointmentId = appt.AppointmentId,
                PatientName = patient.FullName,
                TimeSlot = appt.TimeSlot
            };
        }

        public ServiceResult CancelByPatient(int appointmentId, string reason, int currentUserId)
        {
            var patient = InMemoryStore.Patients.Find(p => p.UserId == currentUserId);
            if (patient == null)
                return ServiceResult.Fail("", "Unauthorized.");

            var appt = InMemoryStore.Appointments.Find(
                a => a.AppointmentId == appointmentId && a.PatientId == patient.PatientId
            );
            if (appt == null)
                return ServiceResult.Fail("", "Unauthorized.");

            if (appt.Status != "Pending")
                return ServiceResult.Fail("", "Only pending appointments can be cancelled.");

            appt.Status = "Cancelled";
            appt.CancellationReason = reason;
            return ServiceResult.Ok();
        }

        // ── Doctor: schedule ───────────────────────────────────────

        public DoctorScheduleViewModel GetDoctorSchedule(int currentUserId, DateTime filterDate)
        {
            var doctor = InMemoryStore.Doctors.Find(d => d.UserId == currentUserId);
            if (doctor == null)
                return new DoctorScheduleViewModel();

            var today = DateTime.Today;
            var weekEnd = today.AddDays(7);

            var todayList = InMemoryStore.Appointments
                .Where(a => a.DoctorId == doctor.DoctorId && a.ScheduledDate.Date == today)
                .OrderBy(a => a.TimeSlot)
                .Select(a => MapToScheduleItem(a))
                .ToList();

            var weekList = InMemoryStore.Appointments
                .Where(a => a.DoctorId == doctor.DoctorId
                         && a.ScheduledDate.Date > today
                         && a.ScheduledDate.Date <= weekEnd)
                .OrderBy(a => a.ScheduledDate)
                .ThenBy(a => a.TimeSlot)
                .Select(a => MapToScheduleItem(a))
                .ToList();

            var filteredList = InMemoryStore.Appointments
                .Where(a => a.DoctorId == doctor.DoctorId
                         && a.ScheduledDate.Date == filterDate.Date)
                .OrderBy(a => a.TimeSlot)
                .Select(a => MapToScheduleItem(a))
                .ToList();

            return new DoctorScheduleViewModel
            {
                TodayAppointments = todayList,
                WeekAppointments = weekList,
                FilteredAppointments = filteredList,
                FilterDate = filterDate
            };
        }

        public CancelAppointmentViewModel GetCancelViewModelForDoctor(int appointmentId, int currentUserId)
        {
            var doctor = InMemoryStore.Doctors.Find(d => d.UserId == currentUserId);
            if (doctor == null)
                return null;

            var appt = InMemoryStore.Appointments.Find(
                a => a.AppointmentId == appointmentId && a.DoctorId == doctor.DoctorId
            );
            if (appt == null)
                return null;

            var patient = InMemoryStore.Patients.Find(p => p.PatientId == appt.PatientId);

            return new CancelAppointmentViewModel
            {
                AppointmentId = appt.AppointmentId,
                PatientName = patient != null ? patient.FullName : "Unknown",
                TimeSlot = appt.TimeSlot
            };
        }

        public ServiceResult CancelByDoctor(int appointmentId, string reason, int currentUserId)
        {
            var doctor = InMemoryStore.Doctors.Find(d => d.UserId == currentUserId);
            if (doctor == null)
                return ServiceResult.Fail("", "Unauthorized.");

            var appt = InMemoryStore.Appointments.Find(
                a => a.AppointmentId == appointmentId && a.DoctorId == doctor.DoctorId
            );
            if (appt == null)
                return ServiceResult.Fail("", "Unauthorized.");

            appt.Status = "Cancelled";
            appt.CancellationReason = reason;
            return ServiceResult.Ok();
        }

        public ServiceResult ConfirmByDoctor(int appointmentId, int currentUserId)
        {
            var doctor = InMemoryStore.Doctors.Find(d => d.UserId == currentUserId);
            if (doctor == null)
                return ServiceResult.Fail("", "Unauthorized.");

            var appt = InMemoryStore.Appointments.Find(
                a => a.AppointmentId == appointmentId && a.DoctorId == doctor.DoctorId
            );
            if (appt == null)
                return ServiceResult.Fail("", "Unauthorized.");

            if (appt.Status != "Pending")
                return ServiceResult.Fail("", "Only pending appointments can be confirmed.");

            appt.Status = "Confirmed";
            return ServiceResult.Ok();
        }

        // ── Private helpers ────────────────────────────────────────

        private ScheduleItemViewModel MapToScheduleItem(Appointment a)
        {
            var patient = InMemoryStore.Patients.Find(p => p.PatientId == a.PatientId);
            return new ScheduleItemViewModel
            {
                AppointmentId = a.AppointmentId,
                PatientName = patient != null ? patient.FullName : "Unknown",
                ScheduledDate = a.ScheduledDate,
                TimeSlot = a.TimeSlot,
                Status = a.Status
            };
        }
    }
}