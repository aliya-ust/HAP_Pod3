using System.Net.Http.Headers;
using Microsoft.JSInterop;

namespace HealthCare.AdminBlazor.Services;

public class JwtService
{
    private readonly IJSRuntime _js;

    public JwtService(IJSRuntime js)
    {
        _js = js;
    }

    // ✅ Get Token
    public async Task<string?> GetToken()
    {
        return await _js.InvokeAsync<string>("localStorage.getItem", "token");
    }

    // ✅ Set Token in HttpClient
    public async Task SetAuthorizationHeader(HttpClient http)
    {
        var token = await GetToken();

        if (!string.IsNullOrWhiteSpace(token))
        {
            http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
        else
        {
            http.DefaultRequestHeaders.Authorization = null;
        }
    }

    // ✅ Clear token (logout)
    public async Task ClearToken()
    {
        await _js.InvokeVoidAsync("localStorage.removeItem", "token");
        await _js.InvokeVoidAsync("localStorage.removeItem", "tokenExpiry");
    }
}