using Microsoft.AspNetCore.Components;
using System.Net;

namespace HealthCare.Admin
{
    public class GlobalExceptionHandler : DelegatingHandler
    {
        private readonly NavigationManager _navigation;
        private readonly ToastService _toastService; // Inject service

        public GlobalExceptionHandler(NavigationManager navigation, ToastService toastService)
        {
            _navigation = navigation;
            _toastService = toastService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            // Handle specific redirection cases
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigation.NavigateTo("http://localhost:4200/login");
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                _navigation.NavigateTo("/access-denied");
            }
            // Handle all other errors with a Toast
            else if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();

                // Fallback if the API returns an empty body
                if (string.IsNullOrWhiteSpace(errorMessage))
                {
                    errorMessage = $"Error: {response.StatusCode}";
                }

                _toastService.Show("Action Failed", errorMessage, NotificationType.Error);
            }

            return response;
        }
    }
}
