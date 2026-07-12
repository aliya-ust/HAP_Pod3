using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Services.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace HealthCare.Api.Services.Implementations
{
    public class DoctorAvailabilityCacheService
        : IDoctorAvailabilityCacheService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<DoctorAvailabilityCacheService> _logger;

        public DoctorAvailabilityCacheService(
            IDistributedCache cache,
            ILogger<DoctorAvailabilityCacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        private string GetKey(string specialization, DateOnly date)
        {
            return $"doctors:availability:{specialization}:{date:yyyy-MM-dd}";
        }

        public async Task<List<DoctorListDto>?> GetAsync(
            string specialization,
            DateOnly date)
        {
            var key = GetKey(specialization, date);

            var json = await _cache.GetStringAsync(key);

            if (json == null)
                return null;

            _logger.LogInformation(
                "Doctor availability served from cache.");

            return JsonSerializer.Deserialize<List<DoctorListDto>>(json);
        }

        public async Task SetAsync(
            string specialization,
            DateOnly date,
            List<DoctorListDto> doctors)
        {
            var key = GetKey(specialization, date);

            await _cache.SetStringAsync(
                key,
                JsonSerializer.Serialize(doctors),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromMinutes(5)
                });

            _logger.LogInformation(
                "Doctor availability cached.");
        }

        public async Task RefreshSpecializationAsync(string specialization)
        {
            for (int i = 0; i < 30; i++)
            {
                var date = DateOnly.FromDateTime(DateTime.Today.AddDays(i));

                await RemoveAsync(specialization, date);
            }

            _logger.LogInformation(
                "Availability cache refreshed for specialization {Specialization}",
                specialization);
        }

        public async Task RemoveAsync(
            string specialization,
            DateOnly date)
        {
            var key = GetKey(specialization, date);

            await _cache.RemoveAsync(key);

            _logger.LogInformation(
                "Cache removed for {Specialization} on {Date}",
                specialization,
                date);
        }

        public async Task RefreshAsync(
            string specialization,
            DateOnly date)
        {
            await RemoveAsync(specialization, date);
        }
    }
}