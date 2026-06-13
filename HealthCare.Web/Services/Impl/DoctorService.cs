using HealthCare.Shared;
using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Web.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Web.Services
{
    [ExcludeFromCodeCoverage]
    public class DoctorService : IDoctorService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string baseUrl = "https://localhost:44326/api/doctors";

        public async Task<PagedResult<DoctorDto>> GetDoctorsAsync(
            string specialisation,
            string searchTerm,
            bool orderByDescending,
            int pageNumber,
            int pageSize)
        {
            
            specialisation = specialisation ?? "";
            searchTerm = searchTerm ?? "";

            
            string url = $"{baseUrl}" +
                         $"?specialisation={Uri.EscapeDataString(specialisation)}" +
                         $"&searchTerm={Uri.EscapeDataString(searchTerm)}" +
                         $"&orderByDescending={orderByDescending}" +
                         $"&pageNumber={pageNumber}" +
                         $"&pageSize={pageSize}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new PagedResult<DoctorDto>();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PagedResult<DoctorDto>>(json);
        }

        public async Task<DoctorDto> GetByIdAsync(int id)
        {
            var response = await client.GetAsync($"{baseUrl}/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DoctorDto>(json);
        }

        public async Task<bool> CreateAsync(DoctorDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(baseUrl, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(DoctorDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/{dto.DoctorId}", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await client.DeleteAsync($"{baseUrl}/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}