using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Api.Models
{
    public class AvailableSlots
    {
        [Key]
        public int Id { get; set; }

        public int DoctorId { get; set; }

        [Required]
        [MaxLength(20)]
        public string TimeSlot { get; set; } = null!;

        public bool IsBooked { get; set; } = false;

        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;
    }
}
