using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.Appointment
{
    public class CreateAppointmentDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        [FutureDateValidation]
        public DateOnly ScheduledDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string TimeSlot { get; set; } = null!;
    }

    public class FutureDateValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            if (value is DateOnly date)
            {
                if (date <= DateOnly.FromDateTime(DateTime.Today))
                {
                    return new ValidationResult("Scheduled date must be in the future.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
