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
        [Range(0, 60)]
        public int YearsOfExperience { get; set; }

        [Required]
        [Range(0.01, 5000, ErrorMessage = "Consultation fee cannot exceed 5000.")]
        public decimal ConsultationFee { get; set; }
    }
}