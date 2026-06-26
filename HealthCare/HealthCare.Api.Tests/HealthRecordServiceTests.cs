using AutoMapper;
using Moq;
using Microsoft.EntityFrameworkCore;
using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using System.Linq.Expressions;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.HealthRecord;

namespace HealthCare.Api.Tests
{
    public class HealthRecordServiceTests
    {
        private readonly Mock<IHealthRecordRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<HealthCareDbContext> _contextMock;

        private readonly HealthRecordService _service;

        public HealthRecordServiceTests()
        {
            _repoMock = new Mock<IHealthRecordRepository>();
            _mapperMock = new Mock<IMapper>();

            var options = new DbContextOptions<HealthCareDbContext>();
            _contextMock = new Mock<HealthCareDbContext>(options);

            _service = new HealthRecordService(
                _repoMock.Object,
                _contextMock.Object,
                _mapperMock.Object
            );
        }

        //  GetById
        [Fact]
        public async Task GetByIdAsync_ShouldReturnRecord()
        {
            var record = new HealthRecord();
            var dto = new HealthRecordListDto();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(record);
            _mapperMock.Setup(m => m.Map<HealthRecordListDto>(record)).Returns(dto);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrow_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.GetByIdAsync(1));
        }

        //  GetAll
        [Fact]
        public async Task GetAllAsync_ShouldReturnPagedResult()
        {
            var records = new List<HealthRecord> { new HealthRecord() };

            var paged = new PagedResult<HealthRecord>
            {
                Items = records,
                PageNumber = 1,
                PageSize = 10,
                TotalCount = 1
            };

            _repoMock.Setup(r => r.GetAllAsync(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<Expression<Func<HealthRecord, bool>>?>(),
                It.IsAny<Func<IQueryable<HealthRecord>, IOrderedQueryable<HealthRecord>>?>()
            ))
            .ReturnsAsync(paged);

            _mapperMock.Setup(m => m.Map<IEnumerable<HealthRecordListDto>>(records))
                .Returns(new List<HealthRecordListDto> { new HealthRecordListDto() });

            var result = await _service.GetAllAsync(new HealthRecordFilter());

            Assert.Equal(1, result.TotalCount);
        }

        //  AddAsync
        [Fact]
        public async Task AddAsync_ShouldAddRecord()
        {
            var dto = new CreateHealthRecordDto
            {
                AppointmentId = 1,
                PatientId = 1,
                VisitDate = DateTime.Now,
            };
            var record = new HealthRecord();

            _mapperMock.Setup(m => m.Map<HealthRecord>(dto)).Returns(record);
            int doctorId = 1;

            await _service.AddAsync(doctorId, dto);

            _repoMock.Verify(r => r.AddAsync(record), Times.Once);
        }

        //  UpdateAsync
        [Fact]
        public async Task UpdateAsync_ShouldUpdateRecord()
        {
            var record = new HealthRecord();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(record);

            await _service.UpdateAsync(1, new UpdateHealthRecordDto());

            _repoMock.Verify(r => r.UpdateAsync(record), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrow_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.UpdateAsync(1, new UpdateHealthRecordDto()));
        }

        //  Delete
        [Fact]
        public async Task DeleteAsync_ShouldDeleteRecord()
        {
            var record = new HealthRecord();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(record);

            await _service.DeleteAsync(1);

            _repoMock.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.DeleteAsync(1));
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenDbFails()
        {
            var record = new HealthRecord();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(record);

            _repoMock.Setup(r => r.DeleteAsync(1))
                .ThrowsAsync(new DbUpdateException());

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.DeleteAsync(1));
        }

        //  GetHealthRecordByPatient
        [Fact]
        public async Task GetHealthRecordByPatient_ShouldReturnList()
        {
            _repoMock.Setup(r => r.GetHealthRecordByPatient(1))
                .ReturnsAsync(new List<HealthRecordListDto>());

            var result = await _service.GetHealthRecordByPatient(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetHealthRecordByPatient_ShouldReturnEmptyList_WhenNone()
        {
            _repoMock.Setup(r => r.GetHealthRecordByPatient(1))
                .ReturnsAsync(new List<HealthRecordListDto>());

            var result = await _service.GetHealthRecordByPatient(1);

            Assert.Empty(result);
        }

        //  GetHealthRecordByAppointment
        [Fact]
        public async Task GetHealthRecordByAppointment_ShouldReturnList()
        {
            _repoMock.Setup(r => r.GetHealthRecordByAppointment(1))
                .ReturnsAsync(new List<HealthRecordListDto>());

            var result = await _service.GetHealthRecordByAppointment(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetHealthRecordByAppointment_ShouldReturnEmptyList_WhenNone()
        {
            _repoMock.Setup(r => r.GetHealthRecordByAppointment(1))
                .ReturnsAsync(new List<HealthRecordListDto>());

            var result = await _service.GetHealthRecordByAppointment(1);

            Assert.Empty(result);
        }
    }
}