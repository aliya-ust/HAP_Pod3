using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.Patient
{
    public class CreatePatientDto
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [MaxLength(50)]
        public string? InsuranceId { get; set; }
    }
}