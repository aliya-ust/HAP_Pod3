namespace HealthCare.Api.DTOs.Patient
{
    public class PatientProfileDto
    {
        public int PatientId { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string? InsuranceId { get; set; }
    }
}