namespace HealthCare.Api.DTOs.Appointment
{
    public class AppointmentFilter : PaginationParams
    {
        public string? Status { get; set; }     // filter by status
    }

}
