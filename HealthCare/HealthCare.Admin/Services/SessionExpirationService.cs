
namespace HealthCare.Admin.Services
{
    public class SessionExpirationService
    {
        private bool _isSessionExpirationBeingHandled;

        public event Func<Task>? SessionExpired;

        public async Task NotifySessionExpiredAsync()
        {
            if (_isSessionExpirationBeingHandled)
            {
                return;
            }

            var handlers = SessionExpired;

            if (handlers is null)
            {
                Console.WriteLine(
                    "Session expiration has no subscribers.");

                return;
            }

            _isSessionExpirationBeingHandled = true;

            try
            {
                foreach (var handler in handlers
                             .GetInvocationList()
                             .Cast<Func<Task>>())
                {
                    await handler();
                }
            }
            catch
            {
                _isSessionExpirationBeingHandled = false;
                throw;
            }
        }

        public void Reset()
        {
            _isSessionExpirationBeingHandled = false;
        }
    }
}