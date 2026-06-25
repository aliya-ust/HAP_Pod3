namespace HealthCare.Shared.DTOs.Appointment
{
    public class AppointmentFilter : PaginationParams
    {
        public string? Status { get; set; }
        public DateOnly? ScheduledDate { get; set; }
    }
}