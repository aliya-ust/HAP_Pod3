namespace HealthCare.Api.DTOs.Patient
{
    public class PatientFilter : PaginationParams
    {
        public string? Search { get; set; }           // Name search

        public bool? HasInsurance { get; set; }       // true => has insurance

        public bool? IsActive { get; set; }           // active/inactive
    }
}
