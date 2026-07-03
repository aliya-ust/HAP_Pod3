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
    public class HealthRecordServiceTests
    {
        private readonly Mock<IHealthRecordRepository> _repository = new();
        private readonly Mock<IMapper> _mapper = new();

        private readonly HealthCareDbContext _context;
        private readonly HealthRecordService _service;

        public HealthRecordServiceTests()
        {
            var options = new DbContextOptionsBuilder<HealthCareDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new HealthCareDbContext(options);

            _service = new HealthRecordService(
                _repository.Object,
                _context,
                _mapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Record()
        {
            var entity = new HealthRecord { RecordId = 1 };
            var dto = new HealthRecordListDto { RecordId = 1 };

            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(entity);

            _mapper.Setup(x => x.Map<HealthRecordListDto>(entity))
                .Returns(dto);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.RecordId);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Throw_When_NotFound()
        {
            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.GetByIdAsync(1));
        }

        [Fact]
        public async Task AddAsync_Should_Add_Record()
        {
            var dto = new CreateHealthRecordDto
            {
                AppointmentId = 1
            };

            var entity = new HealthRecord();

            _mapper.Setup(x => x.Map<HealthRecord>(dto))
                .Returns(entity);

            _context.Appointments.Add(new Appointment
            {
                AppointmentId = 1,
                PatientId = 1,
                DoctorId = 1,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "09:00 AM",
                Status = "Confirmed"
            });

            await _context.SaveChangesAsync();

            await _service.AddAsync(5, dto);

            Assert.Equal(5, entity.DoctorId);

            _repository.Verify(r => r.AddAsync(entity), Times.Once);

            var appointment = _context.Appointments.First(a => a.AppointmentId == 1);

            Assert.Equal("Completed", appointment.Status);
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Record()
        {
            var entity = new HealthRecord();

            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(entity);

            await _service.UpdateAsync(1, new UpdateHealthRecordDto());

            _repository.Verify(x => x.UpdateAsync(entity), Times.Once);
        }


        [Fact]
        public async Task UpdateAsync_Should_Throw_When_NotFound()
        {
            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.UpdateAsync(1, new UpdateHealthRecordDto()));
        }

        [Fact]
        public async Task DeleteAsync_Should_Delete_Record()
        {
            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(new HealthRecord());

            await _service.DeleteAsync(1);

            _repository.Verify(x => x.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_Should_Throw_When_Record_NotFound()
        {
            _repository.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((HealthRecord)null!);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.DeleteAsync(1));
        }

        [Fact]
        public async Task GetHealthRecordByPatient_Should_Return_List()
        {
            var records = new List<HealthRecordListDto>
            {
                new HealthRecordListDto
                {
                    RecordId = 1
                }
            };

            _repository.Setup(x => x.GetPatientHealthRecords(2))
                .ReturnsAsync(records);

            var result = await _service.GetHealthRecordByPatient(2);

            Assert.Single(result);
        }

        [Fact]
        public async Task GetHealthRecordByPatient_Should_Return_Empty_List()
        {
            _repository.Setup(x => x.GetPatientHealthRecords(2))
                .ReturnsAsync(new List<HealthRecordListDto>());

            var result = await _service.GetHealthRecordByPatient(2);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetHealthRecordByAppointment_Should_Return_List()
        {
            var records = new List<HealthRecordListDto>
            {
                new HealthRecordListDto
                {
                    RecordId = 10
                }
            };

            _repository.Setup(x => x.GetHealthRecordByAppointment(5))
                .ReturnsAsync(records);

            var result = await _service.GetHealthRecordByAppointment(5);

            Assert.Single(result);
            Assert.Equal(10, result[0].RecordId);
        }
    }
}