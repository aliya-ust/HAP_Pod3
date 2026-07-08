namespace HealthCare.Api.Events
{
    public class AppointmentBookedEvent
    {
        public int AppointmentId { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public int DoctorId { get; set; }

        public DateOnly ScheduledDate { get; set; }

        public string TimeSlot { get; set; } = string.Empty;

        public DateTime OccurredAt { get; set; }
    }
}