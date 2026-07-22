using HealthCare.Admin.Services;
using Microsoft.JSInterop;
using System.Net;
using System.Net.Http.Headers;

namespace HealthCare.Admin.Handlers
{
    public class JwtAuthorizationHandler : DelegatingHandler
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly SessionExpirationService
            _sessionExpirationService;

        public JwtAuthorizationHandler(
            IJSRuntime jsRuntime,
            SessionExpirationService sessionExpirationService)
        {
            _jsRuntime = jsRuntime;
            _sessionExpirationService = sessionExpirationService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var token = await _jsRuntime.InvokeAsync<string?>(
                "localStorage.getItem",
                cancellationToken,
                "accesstoken");

            var hasToken = !string.IsNullOrWhiteSpace(token);

            if (hasToken)
            {
                request.Headers.Authorization =
                    new AuthenticationHeaderValue(
                        "Bearer",
                        token);
            }
            else
            {
                request.Headers.Authorization = null;
            }

            var response = await base.SendAsync(
                request,
                cancellationToken);

            if (response.StatusCode ==
                    HttpStatusCode.Unauthorized &&
                hasToken &&
                !IsLoginRequest(request))
            {
                Console.WriteLine(
                    "401 detected. Notifying session expiration.");

                await _sessionExpirationService
                    .NotifySessionExpiredAsync();
            }

            return response;
        }

        private static bool IsLoginRequest(
            HttpRequestMessage request)
        {
            var path = request.RequestUri?
                .AbsolutePath
                .TrimEnd('/');

            return string.Equals(
                path,
                "/api/auth/login",
                StringComparison.OrdinalIgnoreCase);
        }
    }
}