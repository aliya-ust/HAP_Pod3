using HealthCare.Shared.DTOs;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

public class DashboardService
{
    private readonly HttpClient _http;
    public DashboardService(HttpClient http)
    {
        _http = http;
    }

    public async Task<DashboardSummaryDto?> GetSummaryAsync()
    {
        var response = await _http.GetAsync("api/admin/dashboard");

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<DashboardSummaryDto>();
    }
}