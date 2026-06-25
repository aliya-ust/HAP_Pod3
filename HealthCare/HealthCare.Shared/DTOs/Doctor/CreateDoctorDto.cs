using System.ComponentModel.DataAnnotations;

namespace HealthCare.Shared.DTOs.Doctor
{
    public class CreateDoctorDto
    {
        [Required(ErrorMessage = "Full name is required.")]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Full name must contain only alphabets.")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Specialisation is required.")]
        public string Specialisation { get; set; } = null!;

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "Enter a valid email (e.g., priya@gmail.com)"
        )]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters with uppercase, lowercase, number and special character.")]
       
        public string Password { get; set; } = null!;

        // ✅ FIXED: nullable
        [Required(ErrorMessage = "Experience is required.")]
        [Range(0, 60, ErrorMessage = "Experience must be between 0 and 60.")]
        public int? YearsOfExperience { get; set; }

        // ✅ FIXED: nullable
        [Required(ErrorMessage = "Consultation fee is required.")]
        [Range(1, 5000, ErrorMessage = "Consultation fee must be between 1 and 5000.")]
        public decimal? ConsultationFee { get; set; }

        [Required(ErrorMessage = "Select at least one time slot.")]
        [MinLength(1, ErrorMessage = "Select at least one time slot.")]
        public List<string> TimeSlots { get; set; } = new();
    }
}
