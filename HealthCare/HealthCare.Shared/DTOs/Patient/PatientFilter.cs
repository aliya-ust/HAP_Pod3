namespace HealthCare.Api.DTOs.Patient
{
    public class PatientFilter : Shared.DTOs.PaginationParams
    {
        public string? Search { get; set; }           // Name search

        public bool? HasInsurance { get; set; }       // true => has insurance

        public bool? IsActive { get; set; }
    }
}
