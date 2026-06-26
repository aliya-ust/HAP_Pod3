using HealthCare.Shared.DTOs;

namespace HealthCare.Api.DTOs.Doctor
{
    public class DoctorFilter : PaginationParams
    {
        public string? Search { get; set; }
        public string? Specialisation { get; set; }
        public bool? IsActive { get; set; }

        public string? SortBy { get; set; }     // "experience" or "fee"
        public bool IsDescending { get; set; }  // true/false
    }
} 