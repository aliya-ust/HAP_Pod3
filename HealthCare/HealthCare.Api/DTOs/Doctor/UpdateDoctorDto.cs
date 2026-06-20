using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.Doctor
{
    // IsActive not included here — admin toggles it via delete
    // TimeSlots not included here
    // ConsultationFee not included here
    public class UpdateDoctorDto
    {
        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Full name must contain only alphabets.")]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Specialisation { get; set; } = null!;

        [Range(0, 60)]
        public int YearsOfExperience { get; set; }
    }
}