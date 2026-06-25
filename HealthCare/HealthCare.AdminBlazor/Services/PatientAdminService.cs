using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Patient;

namespace HealthCare.AdminBlazor.Services;

public class PatientAdminService
{
    private readonly HttpClient _http;
    private readonly JwtService _jwt;

    public PatientAdminService(HttpClient http, JwtService jwt)
    {
        _http = http;
        _jwt = jwt;
    }

    public async Task<PagedResult<PatientListDto>> GetAllPatients(PatientFilter filter)
    {
        await _jwt.SetAuthorizationHeader(_http);

        var query = $"api/admin/patients?PageNumber={filter.PageNumber}&PageSize={filter.PageSize}";

        var result = await _http.GetFromJsonAsync<PagedResult<PatientListDto>>(query);

        return result ?? new PagedResult<PatientListDto>();
    }

    public async Task<PagedResult<PatientListDto>> FilterPatients(PatientFilter filter)
    {
        await _jwt.SetAuthorizationHeader(_http);

        var query = "api/admin/patients?";

        if (!string.IsNullOrWhiteSpace(filter.FullName))
            query += $"FullName={filter.FullName}&";

        if (filter.HasInsurance.HasValue)
            query += $"HasInsurance={filter.HasInsurance}&";

        query += $"PageNumber={filter.PageNumber}&PageSize={filter.PageSize}";

        var result = await _http.GetFromJsonAsync<PagedResult<PatientListDto>>(query);

        return result ?? new PagedResult<PatientListDto>();
    }

    public async Task UpdatePatient(int id, UpdatePatientDto dto)
    {
        await _jwt.SetAuthorizationHeader(_http);
        await _http.PutAsJsonAsync($"api/admin/patients/{id}", dto);
    }

    public async Task DeletePatient(int id)
    {
        await _jwt.SetAuthorizationHeader(_http);
        await _http.DeleteAsync($"api/admin/patients/{id}");
    }

    public async Task ToggleStatus(int id, bool status)
    {
        await _jwt.SetAuthorizationHeader(_http);
        await _http.PatchAsJsonAsync($"api/admin/patients/{id}/status", status);
    }
}
