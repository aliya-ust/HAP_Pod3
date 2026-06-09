using System;

namespace HealthCareApi.DTOs.Appointment
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string TimeSlot { get; set; }
        public string Status { get; set; }
        public string CancellationReason { get; set; }
    }
}
