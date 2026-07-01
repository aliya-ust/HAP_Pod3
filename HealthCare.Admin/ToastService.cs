namespace HealthCare.Admin
{
    public enum NotificationType { Info, Success, Warning, Error }

    public record NotificationMessage(string Title, string Message, NotificationType Type);

    public class ToastService
    {
        // Event that components will subscribe to
        public event Action<NotificationMessage>? OnNotificationReceived;

        // Public method to trigger the notification
        public void Show(string title, string message, NotificationType type = NotificationType.Info)
        {
            OnNotificationReceived?.Invoke(new NotificationMessage(title, message, type));
        }
    }
}
