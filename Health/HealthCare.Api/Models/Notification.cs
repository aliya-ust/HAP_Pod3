namespace HealthCare.Api.Models;

public class Notification
{
    public int NotificationId { get; set; }

    public int DoctorId { get; set; }

    public string Message { get; set; } = string.Empty;

    public bool IsRead { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}