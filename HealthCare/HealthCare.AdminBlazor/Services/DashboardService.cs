using HealthCare.Shared.DTOs;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HealthCare.AdminBlazor.Services;

public class DashboardService
{
    private readonly HttpClient _http;
    private readonly JwtService _jwt;

    public DashboardService(HttpClient http, JwtService jwt)
    {
        _http = http;
        _jwt = jwt;
    }

    public async Task<DoctorSummaryDto> GetDoctorSummary()
    {
        await _jwt.SetAuthorizationHeader(_http);

        var result = await _http.GetFromJsonAsync<DoctorSummaryDto>(
            "api/admin/doctors/summary");

        return result ?? new DoctorSummaryDto();
    }

    public async Task<AppointmentSummaryDto> GetAppointmentSummary()
    {
        await _jwt.SetAuthorizationHeader(_http);

        var result = await _http.GetFromJsonAsync<AppointmentSummaryDto>(
            "api/admin/appointments/summary");

        return result ?? new AppointmentSummaryDto();
    }

    public async Task<int> GetRecentPatients()
    {
        await _jwt.SetAuthorizationHeader(_http);

        return await _http.GetFromJsonAsync<int>(
            "api/admin/patients/count/recent");
    }
}