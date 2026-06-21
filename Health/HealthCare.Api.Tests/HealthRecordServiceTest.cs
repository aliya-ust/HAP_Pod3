using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace HealthCare.Tests.Services
{
    public class HealthRecordServiceTest
    {
        private readonly Mock<IHealthRecordRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<HealthCareDbContext> _contextMock;
        private readonly HealthRecordService _service;

        public HealthRecordServiceTest()
        {
            _repositoryMock = new Mock<IHealthRecordRepository>();
            _mapperMock = new Mock<IMapper>();

            var options = new DbContextOptions<HealthCareDbContext>();
            _contextMock = new Mock<HealthCareDbContext>(options);

            _service = new HealthRecordService(
                _repositoryMock.Object,
                _contextMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnHealthRecord_WhenFound()
        {
            // Arrange
            var record = new HealthRecord { RecordId = 1 };
            var dto = new HealthRecordListDto();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(record);

            _mapperMock
                .Setup(m => m.Map<HealthRecordListDto>(record))
                .Returns(dto);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(dto, result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrow_WhenRecordNotFound()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.GetByIdAsync(1));
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnPagedResult()
        {
            // Arrange
            var filter = new HealthRecordFilter
            {
                PageNumber = 1,
                PageSize = 10
            };

            var pagedRecords = new PagedResult<HealthRecord>
            {
                Items = new List<HealthRecord>
                {
                    new HealthRecord(),
                    new HealthRecord()
                },
                PageNumber = 1,
                PageSize = 10,
                TotalCount = 2
            };

            var mappedDtos = new List<HealthRecordListDto>
            {
                new HealthRecordListDto(),
                new HealthRecordListDto()
            };

            _repositoryMock
                .Setup(r => r.GetAllAsync(
                    filter.PageNumber,
                    filter.PageSize,
                    It.IsAny<System.Linq.Expressions.Expression<Func<HealthRecord, bool>>>(),
                    It.IsAny<Func<IQueryable<HealthRecord>, IOrderedQueryable<HealthRecord>>>()))
                .ReturnsAsync(pagedRecords);

            _mapperMock
                .Setup(m => m.Map<IEnumerable<HealthRecordListDto>>(pagedRecords.Items))
                .Returns(mappedDtos);

            // Act
            var result = await _service.GetAllAsync(filter);

            // Assert
            Assert.Equal(2, result.TotalCount);
            Assert.Equal(2, result.Items.Count());
        }

        [Fact]
        public async Task AddAsync_ShouldAddRecord_AndAssignDoctorId()
        {
            // Arrange
            var dto = new CreateHealthRecordDto();
            var record = new HealthRecord();

            _mapperMock
                .Setup(m => m.Map<HealthRecord>(dto))
                .Returns(record);

            _repositoryMock
                .Setup(r => r.AddAsync(record))
                .Returns(Task.CompletedTask);

            // Act
            await _service.AddAsync(5, dto);

            // Assert
            Assert.Equal(5, record.DoctorId);

            _repositoryMock.Verify(
                r => r.AddAsync(record),
                Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateRecord_WhenFound()
        {
            // Arrange
            var record = new HealthRecord();
            var dto = new UpdateHealthRecordDto();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(record);

            // Act
            await _service.UpdateAsync(1, dto);

            // Assert
            _mapperMock.Verify(
                m => m.Map(dto, record),
                Times.Once);

            _repositoryMock.Verify(
                r => r.UpdateAsync(record),
                Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrow_WhenRecordNotFound()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.UpdateAsync(1, new UpdateHealthRecordDto()));
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteRecord_WhenFound()
        {
            // Arrange
            var record = new HealthRecord();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(record);

            // Act
            await _service.DeleteAsync(1);

            // Assert
            _repositoryMock.Verify(
                r => r.DeleteAsync(1),
                Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenRecordNotFound()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord?)null);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.DeleteAsync(1));
        }

        [Fact]
        public async Task GetHealthRecordByPatient_ShouldReturnRecords()
        {
            // Arrange
            var expected = new List<HealthRecordListDto>
            {
                new HealthRecordListDto(),
                new HealthRecordListDto()
            };

            _repositoryMock
                .Setup(r => r.GetHealthRecordByPatient(1))
                .ReturnsAsync(expected);

            // Act
            var result = await _service.GetHealthRecordByPatient(1);

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetHealthRecordByPatient_ShouldReturnEmptyList_WhenNoRecordsExist()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetHealthRecordByPatient(1))
                .ReturnsAsync(new List<HealthRecordListDto>());

            // Act
            var result = await _service.GetHealthRecordByPatient(1);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetHealthRecordByAppointment_ShouldReturnRecords()
        {
            // Arrange
            var expected = new List<HealthRecordListDto>
            {
                new HealthRecordListDto()
            };

            _repositoryMock
                .Setup(r => r.GetHealthRecordByAppointment(1))
                .ReturnsAsync(expected);

            // Act
            var result = await _service.GetHealthRecordByAppointment(1);

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public async Task GetHealthRecordByAppointment_ShouldReturnEmptyList_WhenNoRecordsExist()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetHealthRecordByAppointment(1))
                .ReturnsAsync(new List<HealthRecordListDto>());

            // Act
            var result = await _service.GetHealthRecordByAppointment(1);

            // Assert
            Assert.Empty(result);
        }
    }
}