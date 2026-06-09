using HealthCare.Shared;
using HealthCare.Shared.DTOs.Appointment;
using HealthCare.Web.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Web.Services
{
    public class AppointmentService : IAppointmentService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string baseUrl = "https://localhost:5001/api/appointments";

        // ✅ GET PATIENT APPOINTMENTS (PAGED)
        public async Task<PagedResult<AppointmentDto>> GetPatientAppointmentsAsync(
            int patientId,
            string status,
            int pageNumber,
            int pageSize)
        {
            string url = $"{baseUrl}/patient/{patientId}?status={status}&pageNumber={pageNumber}&pageSize={pageSize}";

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new PagedResult<AppointmentDto>();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PagedResult<AppointmentDto>>(json);
        }

        // ✅ DOCTOR TODAY
        public async Task<IEnumerable<AppointmentDto>> GetTodayAppointmentsAsync(int doctorId)
        {
            var res = await client.GetAsync($"{baseUrl}/doctor/{doctorId}/today");

            if (!res.IsSuccessStatusCode) return new List<AppointmentDto>();

            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<AppointmentDto>>(json);
        }

        // ✅ DOCTOR WEEK
        public async Task<IEnumerable<AppointmentDto>> GetWeeklyAppointmentsAsync(int doctorId)
        {
            var res = await client.GetAsync($"{baseUrl}/doctor/{doctorId}/week");

            if (!res.IsSuccessStatusCode) return new List<AppointmentDto>();

            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<AppointmentDto>>(json);
        }

        // ✅ BY DATE
        public async Task<IEnumerable<AppointmentDto>> GetByDateAsync(DateTime date)
        {
            var res = await client.GetAsync($"{baseUrl}/date?date={date:yyyy-MM-dd}");

            if (!res.IsSuccessStatusCode) return new List<AppointmentDto>();

            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<AppointmentDto>>(json);
        }

        // ✅ BOOK
        public async Task<bool> BookAsync(AppointmentDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(baseUrl, content);

            return res.IsSuccessStatusCode;
        }

        // ✅ CONFIRM
        public async Task<bool> ConfirmAsync(int id)
        {
            var res = await client.PutAsync($"{baseUrl}/{id}/confirm", null);
            return res.IsSuccessStatusCode;
        }

        // ✅ CANCEL
        public async Task<bool> CancelAsync(int id, string reason)
        {
            var obj = new { Reason = reason };
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PutAsync($"{baseUrl}/{id}/cancel", content);
            return res.IsSuccessStatusCode;
        }
    }
}