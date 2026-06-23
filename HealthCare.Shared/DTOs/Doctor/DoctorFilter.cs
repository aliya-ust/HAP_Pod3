namespace HealthCare.Api.DTOs.Doctor
{
    public class DoctorFilter : PaginationParams
    {
        public string? Specialisation { get; set; }
        public int? MinExperience { get; set; }
    }
}
