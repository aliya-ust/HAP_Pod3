using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace HealthCare.Tests.Services
{
    public class AppointmentServiceTest
    {
        private readonly Mock<IAppointmentRepository> _repositoryMock;
        private readonly Mock<IDoctorService> _doctorServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<HealthCareDbContext> _contextMock;
        private readonly AppointmentService _service;

        public AppointmentServiceTest()
        {
            _repositoryMock = new Mock<IAppointmentRepository>();
            _doctorServiceMock = new Mock<IDoctorService>();
            _mapperMock = new Mock<IMapper>();

            var options = new DbContextOptions<HealthCareDbContext>();
            _contextMock = new Mock<HealthCareDbContext>(options);

            _service = new AppointmentService(
                _repositoryMock.Object,
                _doctorServiceMock.Object,
                _contextMock.Object,
                _mapperMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnAppointment_WhenExists()
        {
            var appointment = new Appointment { AppointmentId = 1 };
            var dto = new AppointmentListDto();

            _repositoryMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(appointment);

            _mapperMock.Setup(m => m.Map<AppointmentListDto>(appointment))
                .Returns(dto);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(dto, result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Appointment?)null);

            var result = await _service.GetByIdAsync(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task AddAsync_ShouldThrow_WhenScheduledDateIsInPast()
        {
            var dto = new CreateAppointmentDto
            {
                DoctorId = 1,
                TimeSlot = "09:00",
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1))
            };

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.AddAsync(dto, 10));
        }

        [Fact]
        public async Task AddAsync_ShouldAddAppointment_WhenValid()
        {
            var dto = new CreateAppointmentDto
            {
                DoctorId = 1,
                TimeSlot = "09:00",
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1))
            };

            var appointment = new Appointment();

            _repositoryMock
                .Setup(r => r.IsAvailable(dto.ScheduledDate, dto.DoctorId, dto.TimeSlot))
                .ReturnsAsync(true);

            _mapperMock
                .Setup(m => m.Map<Appointment>(dto))
                .Returns(appointment);

            _repositoryMock
                .Setup(r => r.AddAsync(appointment))
                .Returns(Task.CompletedTask);

            await _service.AddAsync(dto, 25);

            Assert.Equal(25, appointment.PatientId);

            _repositoryMock.Verify(r => r.AddAsync(appointment), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrow_WhenAppointmentNotFound()
        {
            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Appointment?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.UpdateAsync(1, new UpdateAppointmentDto()));
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateAppointment_WhenFound()
        {
            var appointment = new Appointment();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(appointment);

            var dto = new UpdateAppointmentDto();

            await _service.UpdateAsync(1, dto);

            _mapperMock.Verify(m => m.Map(dto, appointment), Times.Once);

            _repositoryMock.Verify(r => r.UpdateAsync(appointment), Times.Once);
        }

        [Fact]
        public async Task UpdateStatusAsync_ShouldUpdateStatus()
        {
            var appointment = new Appointment();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(appointment);

            var dto = new UpdateAppointmentDto
            {
                Status = "Cancelled",
                CancellationReason = "Doctor unavailable"
            };

            await _service.UpdateStatusAsync(1, dto);

            Assert.Equal("Cancelled", appointment.Status);
            Assert.Equal("Doctor unavailable", appointment.CancellationReason);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrow_WhenAppointmentMissing()
        {
            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Appointment?)null);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.DeleteAsync(1));
        }

        [Fact]
        public async Task DeleteAsync_ShouldDelete_WhenAppointmentExists()
        {
            var appointment = new Appointment();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(appointment);

            await _service.DeleteAsync(1);

            _repositoryMock.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task AvailableTimeSlots_ShouldReturnFreeSlots()
        {
            var date = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

            _doctorServiceMock
                .Setup(d => d.GetSlots(1))
                .ReturnsAsync(new List<string>
                {
                    "09:00",
                    "10:00",
                    "11:00"
                });

            _repositoryMock
                .Setup(r => r.BookedTimeSlots(date, 1))
                .ReturnsAsync(new List<string>
                {
                    "10:00"
                });

            var result = await _service.AvailableTimeSlots(date, 1);

            Assert.Equal(2, result.Count);
            Assert.Contains("09:00", result);
            Assert.Contains("11:00", result);
            Assert.DoesNotContain("10:00", result);
        }

        [Fact]
        public async Task IsAvailable_ShouldReturnTrue_WhenSlotAvailable()
        {
            _repositoryMock
                .Setup(r => r.IsAvailable(It.IsAny<DateOnly>(), 1, "09:00"))
                .ReturnsAsync(true);

            var result = await _service.IsAvailable(
                DateOnly.FromDateTime(DateTime.Today),
                1,
                "09:00");

            Assert.True(result);
        }

        [Fact]
        public async Task IsAvailable_ShouldThrow_WhenSlotBooked()
        {
            _repositoryMock
                .Setup(r => r.IsAvailable(It.IsAny<DateOnly>(), 1, "09:00"))
                .ReturnsAsync(false);

            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _service.IsAvailable(
                    DateOnly.FromDateTime(DateTime.Today),
                    1,
                    "09:00"));
        }

        [Fact]
        public async Task GetDailyReport_ShouldReturnEmptyList_WhenNoData()
        {
            _repositoryMock
                .Setup(r => r.GetDailyReport())
                .ReturnsAsync(new List<AppointmentReportDto>());

            var result = await _service.GetDailyReport();

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetDoctorSchedule_ShouldReturnSchedule()
        {
            var expected = new List<AppointmentListDto>
            {
                new AppointmentListDto()
            };

            _repositoryMock
                .Setup(r => r.GetDoctorSchedule(It.IsAny<DateOnly>(), 1))
                .ReturnsAsync(expected);

            var result = await _service.GetDoctorSchedule(
                DateOnly.FromDateTime(DateTime.Today),
                1);

            Assert.Single(result);
        }

        [Fact]
        public async Task GetPatientSchedule_ShouldReturnSchedule()
        {
            var expected = new List<AppointmentListDto>
            {
                new AppointmentListDto()
            };

            _repositoryMock
                .Setup(r => r.GetPatientSchedule(It.IsAny<DateOnly>(), 1))
                .ReturnsAsync(expected);

            var result = await _service.GetPatientSchedule(
                DateOnly.FromDateTime(DateTime.Today),
                1);

            Assert.Single(result);
        }

        [Fact]
        public async Task GetAppointmentByPatient_ShouldReturnAppointments()
        {
            var expected = new List<AppointmentListDto>
            {
                new AppointmentListDto()
            };

            _repositoryMock
                .Setup(r => r.GetAppointmentByPatient(1))
                .ReturnsAsync(expected);

            var result = await _service.GetAppointmentByPatient(1);

            Assert.Single(result);
        }

        [Fact]
        public async Task GetAppointmentByDoctor_ShouldReturnAppointments()
        {
            var expected = new List<AppointmentListDto>
            {
                new AppointmentListDto()
            };

            _repositoryMock
                .Setup(r => r.GetAppointmentByDoctor(1))
                .ReturnsAsync(expected);

            var result = await _service.GetAppointmentByDoctor(1);

            Assert.Single(result);
        }
    }
}