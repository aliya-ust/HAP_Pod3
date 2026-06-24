using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.JSInterop;

public class PatientService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _js;

    public PatientService(HttpClient httpClient, IJSRuntime js)
    {
        _httpClient = httpClient;
        _js = js;
    }

    //Common method to attach token
    private async Task AddAuthHeader()
    {
        var token = await _js.InvokeAsync<string>(
            "localStorage.getItem",
            "accesstoken");

        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<PagedResult<PatientListDto>?> GetPatients(
        string? searchTerm,
        bool? hasInsurance)
    {
        await AddAuthHeader(); // attach token

        var url = "api/admin/patients?pageNumber=1&pageSize=100";

        if (!string.IsNullOrWhiteSpace(searchTerm))
            url += $"&searchTerm={Uri.EscapeDataString(searchTerm)}";

        if (hasInsurance.HasValue)
            url += $"&hasInsurance={hasInsurance.Value}";

        return await _httpClient.GetFromJsonAsync<PagedResult<PatientListDto>>(url);
    }

    public async Task<UpdatePatientDto?> GetPatientById(int id)
    {
        await AddAuthHeader();

        return await _httpClient.GetFromJsonAsync<UpdatePatientDto>(
            $"api/admin/patients/{id}");
    }

    public async Task RegisterPatient(CreatePatientDto dto)
    {
        await AddAuthHeader();

        var response = await _httpClient.PostAsJsonAsync(
            "api/auth/register/patient",
            dto);

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdatePatient(int id, UpdatePatientDto dto)
    {
        await AddAuthHeader();

        var response = await _httpClient.PutAsJsonAsync(
            $"api/admin/patients/{id}",
            dto);

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateStatus(int id, bool isActive)
    {
        await AddAuthHeader();

        var response = await _httpClient.PatchAsync(
            $"api/admin/patients/{id}/status?isActive={isActive}",
            null);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeletePatient(int id)
    {
        await AddAuthHeader();

        var response = await _httpClient.DeleteAsync(
            $"api/admin/patients/{id}");

        response.EnsureSuccessStatusCode();
    }
}
