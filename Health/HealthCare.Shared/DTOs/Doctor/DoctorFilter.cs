namespace HealthCare.Api.DTOs.Doctor
{
    public class DoctorFilter : PaginationParams
    {
        public string FullName { get; set; } = string.Empty;
        public string? Specialisation { get; set; }
        public string? ExperienceSort { get; set; }
        public string? Status { get; set; }
    }
}