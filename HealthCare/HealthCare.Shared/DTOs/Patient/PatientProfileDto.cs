namespace HealthCare.Shared.DTOs.Patient
{
    public class PatientProfileDto
    {
        public int PatientId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public DateOnly? DateOfBirth { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string? InsuranceId { get; set; }
    }
}