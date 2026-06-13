using HealthCare.Shared;
using HealthCare.Shared.DTOs.HealthRecord;
using HealthCare.Web.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Web.Services
{
    [ExcludeFromCodeCoverage]
    public class HealthRecordService : IHealthRecordService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string baseUrl = "https://localhost:44326/api/healthrecords";

        // GET PAGINATED HISTORY
        public async Task<PagedResult<HealthRecordDto>> GetPatientHealthHistoryAsync(
            int patientId,
            int pageNumber,
            int pageSize)
        {
            string url = $"{baseUrl}/patient/{patientId}?pageNumber={pageNumber}&pageSize={pageSize}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new PagedResult<HealthRecordDto>();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PagedResult<HealthRecordDto>>(json);
        }

        // CREATE RECORD
        public async Task<bool> CreateAsync(HealthRecordDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(baseUrl, content);

            if (res.IsSuccessStatusCode)
                return true;

            var error = await res.Content.ReadAsStringAsync();

            throw new Exception(error); 
        }

        // GET BY APPOINTMENT ID

        public async Task<HealthRecordDto> GetByIdAsync(int appointmentId)
        {
            var response = await client.GetAsync($"{baseUrl}/{appointmentId}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<HealthRecordDto>(json);
        }

        // GET ALL RECORDS

        public async Task<PagedResult<HealthRecordDto>> GetAllAsync(int pageNumber, int pageSize)
        {
            var response = await client.GetAsync(baseUrl);

            if (!response.IsSuccessStatusCode)
                return new PagedResult<HealthRecordDto>();

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<HealthRecordDto>>(json);

           
            var items = data
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<HealthRecordDto>
            {
                Items = items,
                TotalCount = data.Count,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}