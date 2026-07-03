using System.ComponentModel.DataAnnotations;

namespace HealthCare.Shared.DTOs.Appointment
{
    public class CreateAppointmentDto
    {
        [Required]
        public required int DoctorId { get; set; }

        [Required]
        [FutureDateValidationAttribute]
        public required DateOnly ScheduledDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string TimeSlot { get; set; } = null!;
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class FutureDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is DateOnly date && date < DateOnly.FromDateTime(DateTime.Today))
            {
                return new ValidationResult("Scheduled date must be today or in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
