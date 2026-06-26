using HealthCare.Api.DTOs.Appointment;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

public class AppointmentService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;

    public AppointmentService(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
    }

    private async Task AddAuthorizationHeaderAsync()
    {
        var token = await _jsRuntime.InvokeAsync<string>(
            "localStorage.getItem",
            "accesstoken");

        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<List<AppointmentReportDto>> GetAppointmentReport(DateTime startDate, DateTime endDate)
    {
        await AddAuthorizationHeaderAsync();
        string url = $"api/admin/appointments/report?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";

        var response = await _httpClient.GetFromJsonAsync<List<AppointmentReportDto>>(url);

        return response ?? new List<AppointmentReportDto>();
    }
}