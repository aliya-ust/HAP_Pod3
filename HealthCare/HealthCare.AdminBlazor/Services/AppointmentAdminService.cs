using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Appointment;
using System.Net.Http.Json;

namespace HealthCare.AdminBlazor.Services;

public class AppointmentAdminService
{
    private readonly HttpClient _http;
    private readonly JwtService _jwt;

    public AppointmentAdminService(HttpClient http, JwtService jwt)
    {
        _http = http;
        _jwt = jwt;
    }

    public async Task<PagedResult<AppointmentReportDto>> GetReports(
        DateOnly startDate,
        DateOnly endDate,
        int pageNumber,
        int pageSize)
    {
        // ✅ Set token using JwtService
        await _jwt.SetAuthorizationHeader(_http);

        var start = startDate.ToString("yyyy-MM-dd");
        var end = endDate.ToString("yyyy-MM-dd");

        // ✅ API call
        var response = await _http.GetAsync(
            $"api/admin/appointments/report?startDate={start}&endDate={end}");

        // ✅ Handle failure safely
        if (!response.IsSuccessStatusCode)
        {
            return new PagedResult<AppointmentReportDto>
            {
                Items = new List<AppointmentReportDto>(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 0
            };
        }

        // ✅ Read response
        var data = await response.Content
            .ReadFromJsonAsync<List<AppointmentReportDto>>()
            ?? new List<AppointmentReportDto>();

        // ✅ Frontend pagination
        var totalCount = data.Count;

        var items = data
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PagedResult<AppointmentReportDto>
        {
            Items = items,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }
}