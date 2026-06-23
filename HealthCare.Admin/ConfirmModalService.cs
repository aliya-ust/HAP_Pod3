namespace HealthCare.Admin
{
    public class ConfirmModalService
    {
        public event Func<string, string, Task<bool>>? OnShow;

        public Task<bool> ShowAsync(string title, string message)
        {
            return OnShow is null
                ? Task.FromResult(false)
                : OnShow.Invoke(title, message);
        }
    }
}
