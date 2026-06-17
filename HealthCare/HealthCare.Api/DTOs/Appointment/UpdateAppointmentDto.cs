using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.Appointment
{
    public class UpdateAppointmentDto
    {
        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = null!;

        // CancellationReason only matters when Status = Cancelled
        [MaxLength(500)]
        public string? CancellationReason { get; set; }
    }
} 