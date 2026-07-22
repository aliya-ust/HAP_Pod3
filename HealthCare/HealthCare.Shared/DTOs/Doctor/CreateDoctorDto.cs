using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.Doctor
{
    public class CreateDoctorDto
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
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;


        [Required(ErrorMessage = "Years Of Experience is required.")]
        [Range(0, 60, ErrorMessage = "Years Of Experience must be between 0 and 60.")]
        public int? YearsOfExperience { get; set; }


        [Required(ErrorMessage = "Consultation Fee is required.")]
        [Range(typeof(decimal), "0.01", "5000",
     ErrorMessage = "Consultation Fee must be between 0.01 and 5000.")]
        public decimal? ConsultationFee { get; set; }

        [Required]
        public List<string> TimeSlots { get; set; } = new();
    }
}