using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace HealthCare.Admin
{
    public class GlobalExceptionHandler : DelegatingHandler
    {
        private readonly NavigationManager _navigation;
        private readonly ToastService _toastService;
        private readonly IConfiguration _configuration;

        public GlobalExceptionHandler(NavigationManager navigation, ToastService toastService, IConfiguration configuration)
        {
            _navigation = navigation;
            _toastService = toastService;
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigation.NavigateTo(_configuration["LoginUrl"]!);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                _navigation.NavigateTo("/access-denied");
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                var body = await response.Content.ReadAsStringAsync(cancellationToken);
                var message = ExtractErrorMessage(body) ?? "An unexpected error occurred. Please try again.";

                _toastService.Show("Error", message, NotificationType.Error);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("{\"success\":true}", Encoding.UTF8, "application/json")
                };
            }
            else if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync(cancellationToken);

                if (string.IsNullOrWhiteSpace(body))
                {
                    body = $"Error: {response.StatusCode}";
                }

                _toastService.Show("Action Failed", body, NotificationType.Error);
            }

            return response;
        }

        private static string? ExtractErrorMessage(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) return null;

            try
            {
                using var doc = JsonDocument.Parse(json);

                if (doc.RootElement.TryGetProperty("message", out var msgProp))
                {
                    var msg = msgProp.GetString();
                    if (!string.IsNullOrWhiteSpace(msg)) return msg;
                }
            }
            catch { /* Ignore JSON parse errors — fall through to return null */ }

            return null;
        }
    }
}
