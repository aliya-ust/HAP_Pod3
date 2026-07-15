using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Doctor;
using Microsoft.JSInterop;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HealthCareAdmin.Web.Services;

public class DoctorService
{
    private readonly HttpClient _http;
    public DoctorService(HttpClient http)
    {
        _http = http;
    }

    public async Task<PagedResult<DoctorListDto>?> GetDoctorsAsync(DoctorFilter filter)
    {
        var query = BuildQuery(filter);

        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"api/admin/doctoradmin?{query}"
        );

        var response = await _http.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            Console.WriteLine("❗ Unauthorized - Token missing or invalid");
            return null;
        }

        response.EnsureSuccessStatusCode();

        return await response.Content
            .ReadFromJsonAsync<PagedResult<DoctorListDto>>();
    }

    public async Task<UpdateDoctorDto?> GetDoctorByIdAsync(int id)
    {

        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"api/admin/doctoradmin/{id}"
        );

        var response = await _http.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<UpdateDoctorDto>();
    }
    public async Task<string?> CreateDoctorAsync(CreateDoctorDto dto)
    {

        var request = new HttpRequestMessage(HttpMethod.Post, "api/auth/register/doctor")
        {
            Content = JsonContent.Create(dto)
        };

        var response = await _http.SendAsync(request);

        var result = await response.Content.ReadFromJsonAsync<ApiResponse>();

        if (!response.IsSuccessStatusCode)
        {
            return result?.Message ?? "Something went wrong";
        }

        return null;
    }
    public class ApiResponse
    {
        public string? Message { get; set; }
    }

    public async Task<string?> UpdateDoctorAsync(int id, UpdateDoctorDto dto)
    {

        var request = new HttpRequestMessage(HttpMethod.Put,
            $"api/admin/doctoradmin/{id}")
        {
            Content = JsonContent.Create(dto)
        };

        var response = await _http.SendAsync(request);

        if (response.IsSuccessStatusCode)
            return null;

        var error = await response.Content.ReadAsStringAsync();
        return error;
    }

    public async Task DeleteDoctorAsync(int id)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Delete,
            $"api/admin/doctoradmin/{id}");

        var response = await _http.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var message = await response.Content.ReadAsStringAsync();

            throw new HttpRequestException(
                    $"Doctor API request failed. StatusCode: {response.StatusCode}, Message: {message}");

        }
    }
    public async Task ToggleStatusAsync(int id, bool isActive)
    { 

        var request = new HttpRequestMessage(
            HttpMethod.Patch,
            $"api/admin/doctoradmin/{id}/status?isActive={isActive}"
        );

        request.Content = null;

        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    //FIXED: proper query builder
    private static string BuildQuery(DoctorFilter filter)
    {
        var q = new List<string>();

        if (!string.IsNullOrWhiteSpace(filter.FullName))
            q.Add($"fullname={Uri.EscapeDataString(filter.FullName)}");

        if (!string.IsNullOrWhiteSpace(filter.Specialisation))
            q.Add($"specialisation={Uri.EscapeDataString(filter.Specialisation)}");

        if (!string.IsNullOrWhiteSpace(filter.Status))
            q.Add($"status={Uri.EscapeDataString(filter.Status)}");

        if (!string.IsNullOrWhiteSpace(filter.ExperienceSort))
            q.Add($"experienceSort={Uri.EscapeDataString(filter.ExperienceSort)}");

        q.Add($"pageNumber={filter.PageNumber}");
        q.Add($"pageSize={filter.PageSize}");

        return string.Join("&", q);
    }
}