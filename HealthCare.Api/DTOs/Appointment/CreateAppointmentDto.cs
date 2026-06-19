using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.Appointment
{
    public class CreateAppointmentDto
    {
        public required int DoctorId { get; set; }

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

            if (value is DateOnly date && date <= DateOnly.FromDateTime(DateTime.Today))
            {
                return new ValidationResult("Scheduled date must be in the future.");
            }

            return ValidationResult.Success;
        }
    }
}
