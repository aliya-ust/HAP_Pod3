namespace HealthCare.Admin
{
    public class NotificationService
    {
        // This is the event definition
        public event Action<string>? OnErrorReceived;

        // This is the public method you call to trigger the event
        public void ShowError(string message)
        {
            // Use the 'Invoke' method on the event
            OnErrorReceived?.Invoke(message);
        }
    }
}
