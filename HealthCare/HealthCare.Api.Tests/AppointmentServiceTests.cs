using AutoMapper;
using Moq;
using Microsoft.EntityFrameworkCore;
using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;

namespace HealthCare.Api.Tests
{
    public class AppointmentServiceTests
    {
        private readonly Mock<IAppointmentRepository> _repoMock;
        private readonly Mock<IDoctorService> _doctorServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<HealthCareDbContext> _contextMock;
        private readonly AppointmentService _service;

        public AppointmentServiceTests()
        {
            _repoMock = new Mock<IAppointmentRepository>();
            _doctorServiceMock = new Mock<IDoctorService>();
            _mapperMock = new Mock<IMapper>();

            var options = new DbContextOptions<HealthCareDbContext>();
            _contextMock = new Mock<HealthCareDbContext>(options);

            _service = new AppointmentService(
                _repoMock.Object,
                _doctorServiceMock.Object,
                _contextMock.Object,
                _mapperMock.Object
            );
        }

        //  GetById
        [Fact]
        public async Task GetByIdAsync_ShouldReturnAppointment()
        {
            var appointment = new Appointment();
            var dto = new AppointmentListDto();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(appointment);
            _mapperMock.Setup(m => m.Map<AppointmentListDto>(appointment)).Returns(dto);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldThrow_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Appointment?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.GetByIdAsync(1));
        }

        //  AddAsync - success
        [Fact]
        public async Task AddAsync_ShouldCreateAppointment()
        {
            var dto = new CreateAppointmentDto
            {
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                DoctorId = 1,
                TimeSlot = "09:00-10:00"
            };

            _repoMock.Setup(r => r.IsAvailable(dto.ScheduledDate, 1, dto.TimeSlot))
                .ReturnsAsync(true);

            var appointment = new Appointment();
            _mapperMock.Setup(m => m.Map<Appointment>(dto)).Returns(appointment);

            await _service.AddAsync(dto, 5);

            _repoMock.Verify(r => r.AddAsync(appointment), Times.Once);
        }

        //  AddAsync - past date
        [Fact]
        public async Task AddAsync_ShouldThrow_WhenPastDate()
        {
            var dto = new CreateAppointmentDto
            {
                DoctorId = 1,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1))
            };

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.AddAsync(dto, 1));
        }

        //  AddAsync - slot not available
        [Fact]
        public async Task AddAsync_ShouldThrow_WhenSlotUnavailable()
        {
            var dto = new CreateAppointmentDto
            {
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                DoctorId = 1,
                TimeSlot = "09:00-10:00"
            };

            _repoMock.Setup(r => r.IsAvailable(dto.ScheduledDate, 1, dto.TimeSlot))
                .ReturnsAsync(false);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.AddAsync(dto, 1));
        }

        //  UpdateAsync
        [Fact]
        public async Task UpdateAsync_ShouldUpdateAppointment()
        {
            var appointment = new Appointment();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(appointment);

            await _service.UpdateAsync(1, new UpdateAppointmentDto());

            _repoMock.Verify(r => r.UpdateAsync(appointment), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrow_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Appointment?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.UpdateAsync(1, new UpdateAppointmentDto()));
        }

        //  UpdateStatus
        [Fact]
        public async Task UpdateStatusAsync_ShouldUpdateStatus()
        {
            var appointment = new Appointment();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(appointment);

            var dto = new UpdateAppointmentDto
            {
                Status = "Cancelled",
                CancellationReason = "Test"
            };

            await _service.UpdateStatusAsync(1, dto);

            Assert.Equal("Cancelled", appointment.Status);
        }

        //  Delete
        [Fact]
        public async Task DeleteAsync_ShouldDeleteAppointment()
        {
            var appointment = new Appointment();

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(appointment);

            await _service.DeleteAsync(1);

            _repoMock.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenNotFound()
        {
            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Appointment?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.DeleteAsync(1));
        }

        //  AvailableTimeSlots
        [Fact]
        public async Task AvailableTimeSlots_ShouldReturnFreeSlots()
        {
            var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

            _doctorServiceMock.Setup(d => d.GetSlots(1))
                .ReturnsAsync(new List<string> { "09:00", "10:00" });

            _repoMock.Setup(r => r.BookedTimeSlots(date, 1))
                .ReturnsAsync(new List<string> { "09:00" });

            var result = await _service.AvailableTimeSlots(date, 1);

            Assert.Single(result);
            Assert.Contains("10:00", result);
        }

        //  AvailableTimeSlots - past date
        [Fact]
        public async Task AvailableTimeSlots_ShouldThrow_WhenPast()
        {
            var date = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.AvailableTimeSlots(date, 1));
        }

        //  IsAvailable
        [Fact]
        public async Task IsAvailable_ShouldReturnTrue()
        {
            _repoMock.Setup(r => r.IsAvailable(It.IsAny<DateOnly>(), 1, "09:00"))
                .ReturnsAsync(true);

            var result = await _service.IsAvailable(DateOnly.FromDateTime(DateTime.Today), 1, "09:00");

            Assert.True(result);
        }

        [Fact]
        public async Task IsAvailable_ShouldThrow_WhenFalse()
        {
            _repoMock.Setup(r => r.IsAvailable(It.IsAny<DateOnly>(), 1, "09:00"))
                .ReturnsAsync(false);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _service.IsAvailable(DateOnly.FromDateTime(DateTime.Today), 1, "09:00"));
        }

        //  GetDailyReport
        [Fact]
        public async Task GetDailyReport_ShouldReturnList()
        {
            _repoMock.Setup(r => r.GetDailyReport())
                .ReturnsAsync(new List<AppointmentReportDto>());

            var result = await _service.GetDailyReport();

            Assert.NotNull(result);
        }

        //  Schedule methods
        [Fact]
        public async Task GetDoctorSchedule_ShouldReturnList()
        {
            _repoMock.Setup(r => r.GetDoctorSchedule(It.IsAny<DateOnly>(), 1))
                .ReturnsAsync(new List<AppointmentListDto>());

            var result = await _service.GetDoctorSchedule(DateOnly.FromDateTime(DateTime.Today), 1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetPatientSchedule_ShouldReturnList()
        {
            _repoMock.Setup(r => r.GetPatientSchedule(It.IsAny<DateOnly>(), 1))
                .ReturnsAsync(new List<AppointmentListDto>());

            var result = await _service.GetPatientSchedule(DateOnly.FromDateTime(DateTime.Today), 1);

            Assert.NotNull(result);
        }

        //  CancelAppointments
        [Fact]
        public async Task CancelAppointments_ShouldCallRepository()
        {
            await _service.CancelAppointmentsByDoctorDate(1, DateOnly.FromDateTime(DateTime.Today));

            _repoMock.Verify(r =>
                r.CancelAppointmentsByDoctorDate(1, It.IsAny<DateOnly>()),
                Times.Once);
        }
    }
}