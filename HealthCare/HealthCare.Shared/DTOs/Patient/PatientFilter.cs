namespace HealthCare.Shared.DTOs.Patient
{
    public class PatientFilter : PaginationParams
    {
        public bool? HasInsurance { get; set; }
        public string? FullName { get; set; }
    }
}
