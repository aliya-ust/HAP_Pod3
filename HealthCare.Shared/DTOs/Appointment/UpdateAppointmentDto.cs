using System.ComponentModel.DataAnnotations;

namespace HealthCare.Shared.DTOs.Appointment
{
    public class UpdateAppointmentDto
    {
        [Required]
        [MaxLength(20)]
        [AllowedValues("Confirmed", "Cancelled",
            ErrorMessage = "Status must be Confirmed or Cancelled")]
        public string Status { get; set; } = null!;

        // CancellationReason only matters when Status = Cancelled
        [MaxLength(500)]
        public string? CancellationReason { get; set; }
    }
}
