using System;
using System.Collections.Generic;

namespace HealthAppWeb.Models.ViewModels
{
    public class DoctorScheduleViewModel
    {
        public List<ScheduleItemViewModel> TodayAppointments { get; set; }
        public List<ScheduleItemViewModel> WeekAppointments { get; set; }
        public List<ScheduleItemViewModel> FilteredAppointments { get; set; }
        public DateTime FilterDate { get; set; }

        public DoctorScheduleViewModel()
        {
            TodayAppointments = new List<ScheduleItemViewModel>();
            WeekAppointments = new List<ScheduleItemViewModel>();
            FilteredAppointments = new List<ScheduleItemViewModel>();
            FilterDate = DateTime.Today;
        }
    }

    public class ScheduleItemViewModel
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string TimeSlot { get; set; }
        public string Status { get; set; }
    }
}