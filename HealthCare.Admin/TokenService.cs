using Microsoft.JSInterop;

namespace HealthCare.Admin
{
    public class TokenService
    {
        private readonly IJSRuntime _js;
        public TokenService(IJSRuntime js) => _js = js;

        public async Task SetToken(string token) =>
            await _js.InvokeVoidAsync("localStorage.setItem", "authToken", token);

        public async Task<string?> GetToken() =>
            await _js.InvokeAsync<string>("localStorage.getItem", "authToken");

        public async Task RemoveToken() =>
            await _js.InvokeVoidAsync("localStorage.removeItem", "authToken");
    }
}
