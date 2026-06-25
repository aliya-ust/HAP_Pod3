namespace HealthCare.Api.DTOs.Appointment
{
    public class AppointmentReportFilter
    {
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}