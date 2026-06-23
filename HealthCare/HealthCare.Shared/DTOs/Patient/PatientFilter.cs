namespace HealthCare.Api.DTOs.Patient
{
    public class PatientFilter : PaginationParams
    {
        public string? SearchByName { get; set; }
        public bool? HasInsurance { get; set; }

    }
} 