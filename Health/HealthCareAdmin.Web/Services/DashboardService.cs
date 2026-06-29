using HealthCare.Shared.DTOs;
using System.Net.Http.Headers;
using System.Net.Http.Json;

public class DashboardService
{
    private readonly HttpClient _http;
    private readonly TokenProvider _tokenProvider;

    public DashboardService(HttpClient http, TokenProvider tokenProvider)
    {
        _http = http;
        _tokenProvider = tokenProvider;
    }

    public async Task<DashboardSummaryDto?> GetSummaryAsync()
    {
        var token = await _tokenProvider.GetTokenAsync();

        _http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var response = await _http.GetAsync("api/dashboard");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DashboardSummaryDto>();
    }
}