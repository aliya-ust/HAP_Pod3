using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Doctor;
using Microsoft.JSInterop;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

public class DoctorService
{
    private readonly HttpClient _http;
    private readonly IJSRuntime _js;

    public DoctorService(HttpClient http, IJSRuntime js)
    {
        _http = http;
        _js = js;
    }

    //Get token from localStorage
    private async Task<string?> GetToken()
    {
        return await _js.InvokeAsync<string>(
            "localStorage.getItem",
            "accesstoken");
    }

    public async Task<PagedResult<DoctorListDto>?> GetDoctorsAsync(DoctorFilter filter)
    {
        var token = await GetToken();
        var query = BuildQuery(filter);

        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"api/admin/doctoradmin?{query}"
        );

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

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

    public async Task DeleteDoctorAsync(int id)
    {
        var token = await GetToken();

        var request = new HttpRequestMessage(
            HttpMethod.Delete,
            $"api/admin/doctoradmin/{id}"
        );

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    public async Task ToggleStatusAsync(int id, bool isActive)
    {
        var token = await GetToken();

        var request = new HttpRequestMessage(
            HttpMethod.Patch,
            $"api/admin/doctoradmin/{id}/status?isActive={isActive}"
        );

        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        request.Content = null;

        var response = await _http.SendAsync(request);
        response.EnsureSuccessStatusCode();
    }

    //FIXED: proper query builder
    private string BuildQuery(DoctorFilter filter)
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