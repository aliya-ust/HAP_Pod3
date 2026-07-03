using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace HealthCareAdmin.Web.Services;

public class PatientService
{
    private readonly HttpClient _httpClient;

    public PatientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PagedResult<PatientListDto>> GetPatients(
    string? searchTerm,
    bool? hasInsurance,
    int pageNumber,
    int pageSize)
    {
        string url =
            $"api/admin/patients?pageNumber={pageNumber}&pageSize={pageSize}";

        if (!string.IsNullOrWhiteSpace(searchTerm))
            url += $"&searchTerm={searchTerm}";

        if (hasInsurance.HasValue)
            url += $"&hasInsurance={hasInsurance.Value}";

        return await _httpClient.GetFromJsonAsync<PagedResult<PatientListDto>>(url);
    }

    public async Task<UpdatePatientDto?> GetPatientById(int id)
    {

        return await _httpClient.GetFromJsonAsync<UpdatePatientDto>(
            $"api/admin/patients/{id}");
    }

    public async Task RegisterPatient(CreatePatientDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/auth/register/patient",
            dto);

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdatePatient(int id, UpdatePatientDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync(
            $"api/admin/patients/{id}",
            dto);

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateStatus(int id, bool isActive)
    {

        var response = await _httpClient.PatchAsync(
            $"api/admin/patients/{id}/status?isActive={isActive}",
            null);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeletePatient(int id)
    {

        var response = await _httpClient.DeleteAsync(
            $"api/admin/patients/{id}");

        response.EnsureSuccessStatusCode();
    }
}
