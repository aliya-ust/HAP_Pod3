using System;

namespace HealthAppWeb.Models.ViewModels
{
    public class PatientAppointmentListViewModel
    {
        public int AppointmentId { get; set; }
        public string DoctorName { get; set; }
        public string Specialisation { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string TimeSlot { get; set; }
        public string Status { get; set; }
        public string CancellationReason { get; set; }
    }
}