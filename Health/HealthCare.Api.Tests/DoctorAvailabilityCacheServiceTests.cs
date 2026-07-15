using System.Text.Json;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Services.Implementations;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HealthCare.Tests.Services
{
    public class DoctorAvailabilityCacheServiceTests
    {
        private readonly Mock<IDistributedCache> _cache = new();
        private readonly Mock<ILogger<DoctorAvailabilityCacheService>> _logger = new();

        private readonly DoctorAvailabilityCacheService _service;

        public DoctorAvailabilityCacheServiceTests()
        {
            _service = new DoctorAvailabilityCacheService(
                _cache.Object,
                _logger.Object);

            _logger.Setup(x =>
                x.IsEnabled(It.IsAny<LogLevel>()))
                .Returns(true);
        }

        [Fact]
        public async Task RemoveAsync_Should_Remove_Cache()
        {
            var date = DateOnly.FromDateTime(DateTime.Today);

            await _service.RemoveAsync(
                "Cardiology",
                date);

            _cache.Verify(x =>
                x.RemoveAsync(
                    It.IsAny<string>(),
                    default),
                Times.Once);
        }

        [Fact]
        public async Task RefreshAsync_Should_Remove_Cache()
        {
            var date = DateOnly.FromDateTime(DateTime.Today);

            await _service.RefreshAsync(
                "Cardiology",
                date);

            _cache.Verify(x =>
                x.RemoveAsync(
                    It.IsAny<string>(),
                    default),
                Times.Once);
        }

        [Fact]
        public async Task RefreshSpecializationAsync_Should_Remove_30_Days_Cache()
        {
            await _service.RefreshSpecializationAsync("Cardiology");

            _cache.Verify(x =>
                x.RemoveAsync(
                    It.IsAny<string>(),
                    default),
                Times.Exactly(30));
        }

        [Fact]
        public async Task GetAsync_Should_Return_Doctors_When_Cache_Exists()
        {
            var json = "[]";

            _cache.Setup(x => x.GetAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(System.Text.Encoding.UTF8.GetBytes(json));

            var result = await _service.GetAsync(
                "Cardiology",
                DateOnly.FromDateTime(DateTime.Today));

            Assert.NotNull(result);
        }

        [Fact]
        public async Task SetAsync_Should_Store_Data_In_Cache()
        {
            var doctors = new List<DoctorListDto>();

            await _service.SetAsync(
                "Cardiology",
                DateOnly.FromDateTime(DateTime.Today),
                doctors);

            _cache.Verify(x => x.SetAsync(
                    It.IsAny<string>(),
                    It.IsAny<byte[]>(),
                    It.IsAny<DistributedCacheEntryOptions>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}