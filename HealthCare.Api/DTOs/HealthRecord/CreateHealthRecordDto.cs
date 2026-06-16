using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.HealthRecord
{
    public class CreateHealthRecordDto
    {
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        [PastOrTodayDateValidation]
        public DateTime VisitDate { get; set; }

        [Required]
        [MaxLength(500)]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Diagnosis must contain only letters and numbers.")]]
        public string Diagnosis { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Prescription must contain only letters and numbers.")]]
        public string Prescription { get; set; } = null!;

        [MaxLength(1000)]
        [RegularExpression(@"^[A-Za-z0-9\s]+$", ErrorMessage = "Notes must contain only letters and numbers.")]]
        public string? Notes { get; set; }
    }


    public class PastOrTodayDateValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            if (value is DateTime visitDate)
            {
                // Compare only the date part (ignore time)
                var today = DateTime.Today;

                if (visitDate.Date > today)
                {
                    return new ValidationResult("Visit date must be today or in the past.");

                }

            }

            return ValidationResult.Success;
        }
    }
}

