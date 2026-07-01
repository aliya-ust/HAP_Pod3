using HealthCare.Shared.DTOs;

namespace HealthCare.Shared.DTOs.Appointment
{
    public class AppointmentFilter : PaginationParams
    {
        public string? Status { get; set; }     // filter by status
    }

}
