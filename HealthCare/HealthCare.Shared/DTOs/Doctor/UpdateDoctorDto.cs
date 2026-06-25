using System.ComponentModel.DataAnnotations;
using HealthCare.Shared.Enums;

namespace HealthCare.Shared.DTOs.Doctor
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
        public DoctorSpecialization Specialisation { get; set; }

        [Required(ErrorMessage = "Years of experience is required.")]
        [Range(0, 60, ErrorMessage = "Years of experience must be between 0 and 60.")]
        public int? YearsOfExperience { get; set; }
    }
}