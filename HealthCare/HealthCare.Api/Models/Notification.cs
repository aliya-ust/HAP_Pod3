using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;

        public bool IsRead { get; set; } = false;

        public DateTime CreatedDate { get; set; }
            = DateTime.UtcNow;
    }
}