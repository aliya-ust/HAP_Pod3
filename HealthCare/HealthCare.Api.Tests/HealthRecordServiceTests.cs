using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.HealthRecord;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;

namespace HealthCare.Api.Tests
{
    public class HealthRecordServiceTests
    {
        private readonly Mock<IHealthRecordRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<HealthCareDbContext> _contextMock;

        private readonly HealthRecordService _service;

        public HealthRecordServiceTests()
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
        public async Task GetByIdAsync_ShouldReturnRecord_WhenExists()
        {
            var record = new HealthRecord
            {
                HealthRecordId = 1
            };

            var dto = new HealthRecordListDto();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(record);

            _mapperMock
                .Setup(m => m.Map<HealthRecordListDto>(record))
                .Returns(dto);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrow_WhenNotFound()
        {
            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.GetByIdAsync(1));
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnPagedResult()
        {
            var records = new List<HealthRecord>
            {
                new()
                {
                    HealthRecordId = 1
                }
            };

            var paged = new PagedResult<HealthRecord>
            {
                Items = records,
                PageNumber = 1,
                PageSize = 10,
                TotalCount = 1
            };

            _repositoryMock
                .Setup(r => r.GetAllAsync(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<Expression<Func<HealthRecord, bool>>?>(),
                    It.IsAny<Func<IQueryable<HealthRecord>,
                    IOrderedQueryable<HealthRecord>>>()))
                .ReturnsAsync(paged);

            _mapperMock
                .Setup(m => m.Map<IEnumerable<HealthRecordListDto>>(records))
                .Returns(new List<HealthRecordListDto>
                {
                    new()
                });

            var result = await _service.GetAllAsync(
                new HealthRecordFilter());

            Assert.NotNull(result);
            Assert.Equal(1, result.TotalCount);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateRecord()
        {
            var record = new HealthRecord();

            var dto = new UpdateHealthRecordDto();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(record);

            await _service.UpdateAsync(1, dto);

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
            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.UpdateAsync(
                    1,
                    new UpdateHealthRecordDto()));
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteRecord()
        {
            var record = new HealthRecord();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(record);

            await _service.DeleteAsync(1);

            _repositoryMock.Verify(
                r => r.DeleteAsync(1),
                Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenRecordNotFound()
        {
            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.DeleteAsync(1));
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenDeleteFails()
        {
            var record = new HealthRecord();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(record);

            _repositoryMock
                .Setup(r => r.DeleteAsync(1))
                .ThrowsAsync(new DbUpdateException());

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.DeleteAsync(1));
        }

        [Fact]
        public async Task GetHealthRecordByPatient_ShouldReturnRecords()
        {
            var records = new List<HealthRecordListDto>
            {
                new()
            };

            _repositoryMock
                .Setup(r => r.GetHealthRecordByPatient(1))
                .ReturnsAsync(records);

            var result = await _service.GetHealthRecordByPatient(1);

            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetHealthRecordByPatient_ShouldReturnEmptyList()
        {
            _repositoryMock
                .Setup(r => r.GetHealthRecordByPatient(1))
                .ReturnsAsync(new List<HealthRecordListDto>());

            var result = await _service.GetHealthRecordByPatient(1);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetHealthRecordByAppointment_ShouldReturnRecords()
        {
            var records = new List<HealthRecordListDto>
            {
                new()
            };

            _repositoryMock
                .Setup(r => r.GetHealthRecordByAppointment(1))
                .ReturnsAsync(records);

            var result = await _service.GetHealthRecordByAppointment(1);

            Assert.Single(result);
        }

        [Fact]
        public async Task GetHealthRecordByAppointment_ShouldReturnEmptyList_WhenNoRecords()
        {
            _repositoryMock
                .Setup(r => r.GetHealthRecordByAppointment(1))
                .ReturnsAsync(new List<HealthRecordListDto>());

            var result = await _service.GetHealthRecordByAppointment(1);

            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}