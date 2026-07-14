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
        }

        //[Fact]
        //public async Task GetAsync_Should_Return_Null_When_Cache_Is_Empty()
        //{
        //    var date = DateOnly.FromDateTime(DateTime.Today);

        //    _cache.Setup(x => x.GetStringAsync(
        //            It.IsAny<string>(),
        //            default))
        //        .ReturnsAsync((string?)null);

        //    var result = await _service.GetAsync("Cardiology", date);

        //    Assert.Null(result);
        //}

        //[Fact]
        //public async Task GetAsync_Should_Return_Doctors_When_Cache_Exists()
        //{
        //    var date = DateOnly.FromDateTime(DateTime.Today);

        //    var doctors = new List<DoctorListDto>
        //    {
        //        new DoctorListDto
        //        {
        //            DoctorId = 1,
        //            FullName = "John"
        //        }
        //    };

        //    _cache.Setup(x => x.GetStringAsync(
        //            It.IsAny<string>(),
        //            default))
        //        .ReturnsAsync(JsonSerializer.Serialize(doctors));

        //    var result = await _service.GetAsync("Cardiology", date);

        //    Assert.NotNull(result);
        //    Assert.Single(result!);
        //    Assert.Equal("John", result[0].FullName);
        //}

        //[Fact]
        //public async Task SetAsync_Should_Store_Data_In_Cache()
        //{
        //    var doctors = new List<DoctorListDto>
        //    {
        //        new DoctorListDto
        //        {
        //            DoctorId = 1,
        //            FullName = "John"
        //        }
        //    };

        //    var date = DateOnly.FromDateTime(DateTime.Today);

        //    await _service.SetAsync(
        //        "Cardiology",
        //        date,
        //        doctors);

        //    _cache.Verify(x =>
        //        x.SetStringAsync(
        //            It.IsAny<string>(),
        //            It.IsAny<string>(),
        //            It.IsAny<DistributedCacheEntryOptions>(),
        //            default),
        //        Times.Once);
        //}

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
    }
}