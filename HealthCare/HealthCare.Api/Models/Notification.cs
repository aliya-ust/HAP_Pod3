using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Api.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        public int DoctorId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; } = string.Empty;

        public bool IsRead { get; set; } = false;

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;
    }
}