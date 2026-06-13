using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HealthCare.Shared.DTOs.Appointment
{
    [ExcludeFromCodeCoverage]
    public class AppointmentDto : IValidatableObject
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Patient ID is required")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Doctor is required")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime ScheduledDate { get; set; }

        [Required(ErrorMessage = "Time Slot is required")]
        public string TimeSlot { get; set; }

        public string Status { get; set; }

        // ✅ Global validation
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (ScheduledDate < DateTime.Today)
            {
                yield return new ValidationResult(
                    "Appointment date cannot be in the past",
                    new[] { nameof(ScheduledDate) }
                );
            }
        }
    }
}