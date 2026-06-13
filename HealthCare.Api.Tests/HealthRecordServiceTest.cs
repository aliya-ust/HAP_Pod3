using HealthCare.Api;
using HealthCare.Shared;
using HealthCareApi.Repositories.Interfaces;
using HealthCareApi.Services.Implementations;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HealthCareApi.Tests.Services
{
    public class HealthRecordServiceTest
    {
        private readonly Mock<IHealthRecordRepository> _repoMock;
        private readonly HealthRecordService _service;

        public HealthRecordServiceTest()
        {
            _repoMock = new Mock<IHealthRecordRepository>();

            _service = new HealthRecordService(
                _repoMock.Object);
        }

        // CREATE SUCCESS 
        [Fact]
        public async Task CreateAsync_Should_Add_Record_When_Not_Exists()
        {
            // Arrange
            var record = new HealthRecord
            {
                AppointmentId = 1
            };

            _repoMock
                .Setup(r => r.HealthRecordExistsAsync(1))
                .ReturnsAsync(false);

            _repoMock
                .Setup(r => r.AddAsync(record))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _service.CreateAsync(record);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.AppointmentId);

            _repoMock.Verify(r => r.AddAsync(record), Times.Once);
        }

        // ✅ TEST 2: Duplicate record should throw
        [Fact]
        public async Task CreateAsync_Should_Throw_When_Record_Already_Exists()
        {
            // Arrange
            var record = new HealthRecord
            {
                AppointmentId = 1
            };

            _repoMock
                .Setup(r => r.HealthRecordExistsAsync(1))
                .ReturnsAsync(true);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => _service.CreateAsync(record));

            Assert.Equal("Health record already exists for this appointment", ex.Message);

            _repoMock.Verify(r => r.AddAsync(It.IsAny<HealthRecord>()), Times.Never);
        }

        // GET HISTORY 
        [Fact]
        public async Task GetPatientHealthHistoryAsync_ShouldReturnData()
        {
            // Arrange
            var resultData = new PagedResult<vw_PatientHealthHistory>
            {
                Items = new List<vw_PatientHealthHistory>
                {
                    new vw_PatientHealthHistory(),
                    new vw_PatientHealthHistory()
                }
            };

            _repoMock
                .Setup(r => r.GetPatientHealthHistoryAsync(1, 1, 10))
                .ReturnsAsync(resultData);

            // Act
            var result = await _service.GetPatientHealthHistoryAsync(1, 1, 10);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Items.Count);
        }

        // GET BY APPOINTMENT
        [Fact]
        public async Task GetByAppointmentIdAsync_ShouldReturnRecord()
        {
            // Arrange
            var record = new HealthRecord { AppointmentId = 1 };

            _repoMock
                .Setup(r => r.GetByAppointmentIdAsync(1))
                .ReturnsAsync(record);

            // Act
            var result = await _service.GetByAppointmentIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.AppointmentId);
        }

        // GET ALL 
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllRecords()
        {
            // Arrange
            var list = new List<HealthRecord>
            {
                new HealthRecord(),
                new HealthRecord()
            };

            _repoMock
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(list);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, ((List<HealthRecord>)result).Count);
        }
    }
}