namespace HealthCare.Api.DTOs.Patient
{
    public class PatientFilter : PaginationParams
    {
        public bool? HasInsurance { get; set; }

        public string? SearchTerm { get; set; }
    }
}