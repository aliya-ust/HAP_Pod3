using HealthCare.Api.Data;
using HealthCare.Api.Exceptions;
using HealthCare.Shared.DTOs.Notification;
using HealthCare.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly HealthCareDbContext _context;

        public NotificationService(HealthCareDbContext context)
        {
            _context = context;
        }

        public async Task<List<NotificationListDto>> GetNotificationsForDoctor(int doctorId)
        {
            var userId = doctorId.ToString();

            return await _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .Select(n => new NotificationListDto
                {
                    NotificationId = n.NotificationId,
                    Message = n.Message,
                    CreatedAt = n.CreatedAt,
                    IsRead = n.IsRead
                })
                .ToListAsync();
        }

        public async Task MarkAsRead(int notificationId, int doctorId)
        {
            var userId = doctorId.ToString();

            var notification = await _context.Notifications
                .FirstOrDefaultAsync(n => n.NotificationId == notificationId
                                       && n.UserId == userId);

            if (notification is null)
                return;

            notification.IsRead = true;
            await _context.SaveChangesAsync();
        }

        public async Task MarkAllAsRead(int doctorId)
        {
            var userId = doctorId.ToString();

            await _context.Notifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .ExecuteUpdateAsync(s => s.SetProperty(n => n.IsRead, true));
        }
    }
}
