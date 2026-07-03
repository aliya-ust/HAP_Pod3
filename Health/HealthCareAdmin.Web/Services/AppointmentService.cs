using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Appointment;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HealthCareAdmin.Web.Services;

public class AppointmentService
{
    private readonly HttpClient _httpClient;

    public AppointmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PagedResult<AppointmentReportDto>> GetReport(
     DateOnly? startDate,
     DateOnly? endDate,
     int pageNumber,
     int pageSize)
    {

        var url =
            $"api/admin/appointmentadmin/daily-report?pageNumber={pageNumber}&pageSize={pageSize}";

        if (startDate.HasValue && endDate.HasValue)
        {
            url += $"&startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";
        }

        return await _httpClient.GetFromJsonAsync<PagedResult<AppointmentReportDto>>(url)
               ?? new PagedResult<AppointmentReportDto>();
    }
}