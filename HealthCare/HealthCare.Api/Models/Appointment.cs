using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Api.Models
{

    public class Appointment // Appointment model with necessary constraints
    {
        [Key]
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        [Required]
        public DateOnly ScheduledDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string TimeSlot { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        [AllowedValues("Pending", "Confirmed", "Cancelled", "Completed",
            ErrorMessage = "Status must be Pending, Confirmed, Cancelled, or Completed.")]
        public string Status { get; set; } = "Pending";

        [MaxLength(500)]
        public string? CancellationReason { get; set; }

        public DateTimeOffset CreatedDate { get; set; } 

        // Navigation
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; } = null!;

        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;

        public HealthRecord? HealthRecord { get; set; }
    }
}