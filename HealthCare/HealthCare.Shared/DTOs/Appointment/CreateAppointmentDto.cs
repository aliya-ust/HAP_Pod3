using System.ComponentModel.DataAnnotations;

namespace HealthCare.Shared.DTOs.Appointment
{
    public class CreateAppointmentDto
    {
        

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateOnly ScheduledDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string TimeSlot { get; set; } = null!;
    }
} 