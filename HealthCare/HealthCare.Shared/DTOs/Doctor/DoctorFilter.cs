namespace HealthCare.Shared.DTOs.Doctor
{
    public class DoctorFilter : PaginationParams
    {

        public string? Name { get; set; }             
        public string? Specialisation { get; set; }
        public bool? IsActive { get; set; }           
        public string? ExperienceOrder { get; set; }  

    }
}