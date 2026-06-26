namespace HealthCare.Shared.DTOs.Appointment
{
    public class AppointmentFilter : PaginationParams
    {
        public string? Search { get; set; }     // patient/doctor name
        public string? Status { get; set; }     // filter by status
        public bool IsDescending { get; set; }  // sort by date
    }
} 