using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.Patient
{
    public class CreatePatientDto
    {
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Full name must contain only alphabets.")]
        public string FullName { get; set; } = null!;

        [Required]
        [CustomDateOfBirthValidation]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Gender must be Male, Female, or Other.")]
        public string Gender { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Phone number must be 10 digits and start with 6, 7, 8, or 9.")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [MaxLength(50)]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "Insurance ID must be alphanumeric.")]
        public string? InsuranceId { get; set; }
    }

    public class CustomDateOfBirthValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateOnly dob)
            {
                if (dob >= DateOnly.FromDateTime(DateTime.Today))
                {
                    return new ValidationResult("Date of Birth must be in the past.");
                }
            }

            return ValidationResult.Success;
        }
    }
}