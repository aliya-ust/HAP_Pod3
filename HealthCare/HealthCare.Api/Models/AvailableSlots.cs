using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Api.Models
{
    public class AvailableSlots // Available slots model for doctor with necessary constraints
    {
        [Key]
        public int Id { get; set; }

        public int DoctorId { get; set; }

        [Required]
        [MaxLength(20)]
        public string TimeSlot { get; set; } = null!;

        public DateTimeOffset CreatedDate { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;
    }
}