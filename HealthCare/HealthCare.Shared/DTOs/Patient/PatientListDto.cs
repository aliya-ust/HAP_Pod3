namespace HealthCare.Shared.DTOs.Patient
{
    public class PatientListDto
    {
        public int PatientId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string InsuranceId { get; set; } = null!;
        public bool IsActive { get; set; }

        public DateOnly? DateOfBirth { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public string UserId { get; set; } = null!;

        public bool HasInsurance => !string.IsNullOrWhiteSpace(InsuranceId);
    }
}