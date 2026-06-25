using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Doctor;

namespace HealthCare.AdminBlazor.Services;

public class DoctorAdminService
{
    private readonly HttpClient _http;
    private readonly JwtService _jwt;

    public DoctorAdminService(HttpClient http, JwtService jwt)
    {
        _http = http;
        _jwt = jwt;
    }

    public async Task<PagedResult<DoctorListDto>> GetAllDoctors(DoctorFilter filter)
    {
        await _jwt.SetAuthorizationHeader(_http);

        var query = $"api/admin/doctors?pageNumber={filter.PageNumber}&pageSize={filter.PageSize}";

        var result = await _http.GetFromJsonAsync<PagedResult<DoctorListDto>>(query);

        return result ?? new PagedResult<DoctorListDto>();
    }

    public async Task<DoctorListDto?> GetDoctor(int id)
    {
        await _jwt.SetAuthorizationHeader(_http);

        var response = await _http.GetAsync($"api/admin/doctors/{id}");

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<DoctorListDto>();

        return null;
    }

    public async Task UpdateDoctor(int id, UpdateDoctorDto dto)
    {
        await _jwt.SetAuthorizationHeader(_http);
        await _http.PutAsJsonAsync($"api/admin/doctors/{id}", dto);
    }

    public async Task DeleteDoctor(int id)
    {
        await _jwt.SetAuthorizationHeader(_http);
        await _http.DeleteAsync($"api/admin/doctors/{id}");
    }

    public async Task ToggleStatus(int id, bool status)
    {
        await _jwt.SetAuthorizationHeader(_http);
        await _http.PatchAsJsonAsync($"api/admin/doctors/{id}/status", status);
    }

    public async Task RegisterDoctor(CreateDoctorDto dto)
    {
        await _jwt.SetAuthorizationHeader(_http);
        await _http.PostAsJsonAsync("api/Auth/register/doctor", dto);
    }

    public async Task<PagedResult<DoctorListDto>> FilterDoctors(DoctorFilter filter)
    {
        await _jwt.SetAuthorizationHeader(_http);

        var query = "api/admin/doctors?";

        if (!string.IsNullOrWhiteSpace(filter.Name))
            query += $"Name={filter.Name}&";

        if (!string.IsNullOrWhiteSpace(filter.Specialisation))
            query += $"Specialisation={filter.Specialisation}&";

        if (filter.IsActive.HasValue)
            query += $"IsActive={filter.IsActive}&";

        if (!string.IsNullOrWhiteSpace(filter.ExperienceOrder))
            query += $"ExperienceOrder={filter.ExperienceOrder}&";

        query += $"PageNumber={filter.PageNumber}&PageSize={filter.PageSize}";

        var result = await _http.GetFromJsonAsync<PagedResult<DoctorListDto>>(query);

        return result ?? new PagedResult<DoctorListDto>();
    }
}
