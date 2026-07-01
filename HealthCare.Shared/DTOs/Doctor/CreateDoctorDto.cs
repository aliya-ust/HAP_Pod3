using System.ComponentModel.DataAnnotations;

namespace HealthCare.Shared.DTOs.Doctor
{
    public class CreateDoctorDto : IValidatableObject
    {
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Full name must contain only alphabets.")]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Specialisation { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "Enter a valid email address with domain (e.g., name@example.com).")]
        public string Email { get; set; } = null!;

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "Password must be at least 8 characters with uppercase, lowercase, digit, and special character.")]
        public string Password { get; set; } = null!;

        [Required]
        [Range(0, 60)]
        public int YearsOfExperience { get; set; }

        [Required]
        [Range(0.01, 5000, ErrorMessage = "Consultation fee must be between ₹1 and ₹5,000.")]
        public decimal ConsultationFee { get; set; }

        [Required]
        public List<string> TimeSlots { get; set; } = new();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (TimeSlots == null || TimeSlots.Count == 0)
            {
                yield return new ValidationResult("At least one time slot must be selected.", [nameof(TimeSlots)]);
            }
        }
    }
}