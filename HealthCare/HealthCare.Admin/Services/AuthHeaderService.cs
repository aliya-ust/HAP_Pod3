using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace HealthCare.Admin.Services
{
    public class AuthHeaderService
    {
        private readonly IJSRuntime _jsRuntime;

        public AuthHeaderService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task AddAuthorizationHeaderAsync(HttpClient httpClient)
        {
            var token = await _jsRuntime.InvokeAsync<string>(
                "localStorage.getItem",
                "accesstoken");

            if (!string.IsNullOrWhiteSpace(token))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }
    }
}