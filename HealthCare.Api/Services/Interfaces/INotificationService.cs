using HealthCare.Shared.DTOs.Notification;

namespace HealthCare.Api.Services.Interfaces
{
    public interface INotificationService
    {
        Task<List<NotificationListDto>> GetNotificationsForDoctor(int doctorId);
        Task MarkAsRead(int notificationId, int doctorId);
        Task MarkAllAsRead(int doctorId);
    }
}
