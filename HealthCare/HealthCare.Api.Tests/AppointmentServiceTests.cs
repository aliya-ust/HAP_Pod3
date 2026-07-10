//using AutoMapper;
//using HealthCare.Api.Data;
//using HealthCare.Api.DTOs.Appointment;
//using HealthCare.Api.Models;
//using HealthCare.Api.Repositories.Interfaces;
//using HealthCare.Api.Services.Implementations;
//using HealthCare.Api.Services.Interfaces;
//using HealthCare.Shared.DTOs;
//using HealthCare.Shared.DTOs.Appointment;
//using Microsoft.EntityFrameworkCore;
//using Moq;

//namespace HealthCare.Api.Tests;

//public class AppointmentServiceTests
//{
//    private readonly Mock<IAppointmentRepository> _repositoryMock;
//    private readonly Mock<IDoctorService> _doctorServiceMock;
//    private readonly Mock<IMapper> _mapperMock;
//    private readonly Mock<HealthCareDbContext> _contextMock;

//    private readonly AppointmentService _service;

//    public AppointmentServiceTests()
//    {
//        _repositoryMock = new Mock<IAppointmentRepository>();
//        _doctorServiceMock = new Mock<IDoctorService>();
//        _mapperMock = new Mock<IMapper>();

//        var options = new DbContextOptions<HealthCareDbContext>();

//        _contextMock = new Mock<HealthCareDbContext>(options);

//        _service = new AppointmentService(
//            _repositoryMock.Object,
//            _doctorServiceMock.Object,
//            _contextMock.Object,
//            _mapperMock.Object);
//    }

//    [Fact]
//    public async Task GetByIdAsync_ShouldReturnAppointment()
//    {
//        var appointment = new Appointment
//        {
//            AppointmentId = 1,
//            PatientId = 1,
//            Status = "Confirmed",
//            Patient = new Patient { FullName = "Patient" },
//            Doctor = new Doctor { FullName = "Doctor" }
//        };

//        _repositoryMock
//            .Setup(x => x.GetByIdAsync(1))
//            .ReturnsAsync(appointment);

//        var result = await _service.GetByIdAsync(1);

//        Assert.NotNull(result);
//        Assert.Equal(1, result.AppointmentId);
//    }

//    [Fact]
//    public async Task GetByIdAsync_ShouldThrow_WhenNotFound()
//    {
//        _repositoryMock
//            .Setup(x => x.GetByIdAsync(1))
//            .ReturnsAsync((Appointment?)null);

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.GetByIdAsync(1));
//    }

//    [Fact]
//    public async Task AddAsync_ShouldAddAppointment()
//    {
//        var dto = new CreateAppointmentDto
//        {
//            DoctorId = 1,
//            ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
//            TimeSlot = "10:00 AM"
//        };

//        var appointment = new Appointment();

//        _repositoryMock
//            .Setup(x => x.IsAvailable(
//                dto.ScheduledDate,
//                dto.DoctorId,
//                dto.TimeSlot))
//            .ReturnsAsync(true);

//        _mapperMock
//            .Setup(x => x.Map<Appointment>(dto))
//            .Returns(appointment);

//        await _service.AddAsync(dto, 5);

//        _repositoryMock.Verify(
//            x => x.AddAsync(appointment),
//            Times.Once);
//    }

//    [Fact]
//    public async Task AddAsync_ShouldThrow_ForPastDate()
//    {
//        var dto = new CreateAppointmentDto
//        {
//            ScheduledDate =
//                DateOnly.FromDateTime(DateTime.Today.AddDays(-1))
//        };

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.AddAsync(dto, 1));
//    }

//    [Fact]
//    public async Task AddAsync_ShouldThrow_WhenSlotNotAvailable()
//    {
//        var dto = new CreateAppointmentDto
//        {
//            DoctorId = 1,
//            TimeSlot = "10:00 AM",
//            ScheduledDate =
//                DateOnly.FromDateTime(DateTime.Today.AddDays(1))
//        };

//        _repositoryMock
//            .Setup(x => x.IsAvailable(
//                dto.ScheduledDate,
//                dto.DoctorId,
//                dto.TimeSlot))
//            .ReturnsAsync(false);

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.AddAsync(dto, 1));
//    }

//    [Fact]
//    public async Task UpdateAsync_ShouldUpdateAppointment()
//    {
//        var appointment = new Appointment();

//        _repositoryMock
//            .Setup(x => x.GetByIdAsync(1))
//            .ReturnsAsync(appointment);

//        await _service.UpdateAsync(
//            1,
//            new UpdateAppointmentDto());

//        _repositoryMock.Verify(
//            x => x.UpdateAsync(appointment),
//            Times.Once);
//    }

//    [Fact]
//    public async Task UpdateAsync_ShouldThrow_WhenAppointmentNotFound()
//    {
//        _repositoryMock
//            .Setup(x => x.GetByIdAsync(1))
//            .ReturnsAsync((Appointment?)null);

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.UpdateAsync(
//                1,
//                new UpdateAppointmentDto()));
//    }

//    [Fact]
//    public async Task UpdateStatusAsync_ShouldUpdateStatus()
//    {
//        var appointment = new Appointment();

//        _repositoryMock
//            .Setup(x => x.GetByIdAsync(1))
//            .ReturnsAsync(appointment);

//        await _service.UpdateStatusAsync(
//            1,
//            new UpdateAppointmentDto
//            {
//                Status = "Cancelled",
//                CancellationReason = "Test"
//            });

//        Assert.Equal("Cancelled", appointment.Status);

//        _repositoryMock.Verify(
//            x => x.UpdateAsync(appointment),
//            Times.Once);
//    }

//    [Fact]
//    public async Task UpdateStatusAsync_ShouldThrow_WhenNotFound()
//    {
//        _repositoryMock
//            .Setup(x => x.GetByIdAsync(1))
//            .ReturnsAsync((Appointment?)null);

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.UpdateStatusAsync(
//                1,
//                new UpdateAppointmentDto()));
//    }

//    [Fact]
//    public async Task DeleteAsync_ShouldDelete()
//    {
//        _repositoryMock
//            .Setup(x => x.GetByIdAsync(1))
//            .ReturnsAsync(new Appointment());

//        await _service.DeleteAsync(1);

//        _repositoryMock.Verify(
//            x => x.DeleteAsync(1),
//            Times.Once);
//    }

//    [Fact]
//    public async Task DeleteAsync_ShouldThrow_WhenNotFound()
//    {
//        _repositoryMock
//            .Setup(x => x.GetByIdAsync(1))
//            .ReturnsAsync((Appointment?)null);

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.DeleteAsync(1));
//    }

//    [Fact]
//    public async Task DeleteAsync_ShouldThrow_WhenDeleteFails()
//    {
//        _repositoryMock
//            .Setup(x => x.GetByIdAsync(1))
//            .ReturnsAsync(new Appointment());

//        _repositoryMock
//            .Setup(x => x.DeleteAsync(1))
//            .ThrowsAsync(new DbUpdateException());

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.DeleteAsync(1));
//    }

//    [Fact]
//    public async Task AvailableTimeSlots_ShouldReturnFreeSlots()
//    {
//        var date =
//            DateOnly.FromDateTime(DateTime.Today.AddDays(1));

//        _doctorServiceMock
//            .Setup(x => x.GetSlots(1))
//            .ReturnsAsync(new List<string>
//            {
//                "09:00",
//                "10:00",
//                "11:00"
//            });

//        _repositoryMock
//            .Setup(x => x.BookedTimeSlots(date, 1))
//            .ReturnsAsync(new List<string>
//            {
//                "10:00"
//            });

//        var result =
//            await _service.AvailableTimeSlots(date, 1);

//        Assert.Equal(2, result.Count);
//    }

//    [Fact]
//    public async Task AvailableTimeSlots_ShouldThrow_ForPastDate()
//    {
//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.AvailableTimeSlots(
//                DateOnly.FromDateTime(DateTime.Today.AddDays(-1)),
//                1));
//    }

//    [Fact]
//    public async Task IsAvailable_ShouldReturnTrue()
//    {
//        _repositoryMock
//            .Setup(x => x.IsAvailable(
//                It.IsAny<DateOnly>(),
//                It.IsAny<int>(),
//                It.IsAny<string>()))
//            .ReturnsAsync(true);

//        var result = await _service.IsAvailable(
//            DateOnly.FromDateTime(DateTime.Today),
//            1,
//            "10:00");

//        Assert.True(result);
//    }

//    [Fact]
//    public async Task IsAvailable_ShouldThrow()
//    {
//        _repositoryMock
//            .Setup(x => x.IsAvailable(
//                It.IsAny<DateOnly>(),
//                It.IsAny<int>(),
//                It.IsAny<string>()))
//            .ReturnsAsync(false);

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.IsAvailable(
//                DateOnly.FromDateTime(DateTime.Today),
//                1,
//                "10:00"));
//    }

//    [Fact]
//    public async Task GetReport_ShouldReturnReport()
//    {
//        _repositoryMock
//            .Setup(x => x.GetReport(
//                It.IsAny<DateOnly>(),
//                It.IsAny<DateOnly>()))
//            .ReturnsAsync(new List<AppointmentReportDto>
//            {
//                new()
//            });

//        var result =
//            await _service.GetReport(
//                new AppointmentReportFilter());

//        Assert.Single(result);
//    }

//    [Fact]
//    public async Task GetReport_ShouldReturnEmptyList()
//    {
//        _repositoryMock
//            .Setup(x => x.GetReport(
//                It.IsAny<DateOnly>(),
//                It.IsAny<DateOnly>()))
//            .ReturnsAsync(new List<AppointmentReportDto>());

//        var result =
//            await _service.GetReport(
//                new AppointmentReportFilter());

//        Assert.Empty(result);
//    }

//    [Fact]
//    public async Task GetDoctorSchedule_ShouldReturnSchedule()
//    {
//        _repositoryMock
//            .Setup(x => x.GetDoctorSchedule(
//                It.IsAny<DateOnly>(),
//                1))
//            .ReturnsAsync(new List<AppointmentListDto>
//            {
//                new()
//            });

//        var result =
//            await _service.GetDoctorSchedule(
//                DateOnly.FromDateTime(DateTime.Today),
//                1);

//        Assert.Single(result);
//    }

//    [Fact]
//    public async Task GetPatientSchedule_ShouldReturnSchedule()
//    {
//        _repositoryMock
//            .Setup(x => x.GetPatientSchedule(
//                It.IsAny<DateOnly>(),
//                1))
//            .ReturnsAsync(new List<AppointmentListDto>
//            {
//                new()
//            });

//        var result =
//            await _service.GetPatientSchedule(
//                DateOnly.FromDateTime(DateTime.Today),
//                1);

//        Assert.Single(result);
//    }

//    [Fact]
//    public async Task GetAppointmentByPatient_ShouldReturnAppointments()
//    {
//        _repositoryMock
//            .Setup(x => x.GetAppointmentByPatient(1))
//            .ReturnsAsync(new List<AppointmentListDto>
//            {
//                new()
//            });

//        var result =
//            await _service.GetAppointmentByPatient(1);

//        Assert.Single(result);
//    }

//    [Fact]
//    public async Task GetAppointmentByDoctor_ShouldReturnAppointments()
//    {
//        _repositoryMock
//            .Setup(x => x.GetAppointmentByDoctor(1))
//            .ReturnsAsync(new List<AppointmentListDto>
//            {
//                new()
//            });

//        var result =
//            await _service.GetAppointmentByDoctor(1);

//        Assert.Single(result);
//    }

//    [Fact]
//    public async Task CancelAppointmentsByDoctorDate_ShouldCallRepository()
//    {
//        await _service.CancelAppointmentsByDoctorDate(
//            1,
//            DateOnly.FromDateTime(DateTime.Today));

//        _repositoryMock.Verify(
//            x => x.CancelAppointmentsByDoctorDate(
//                1,
//                It.IsAny<DateOnly>()),
//            Times.Once);
//    }

//    [Fact]
//    public async Task GetSummaryAsync_ShouldReturnSummary()
//    {
//        _repositoryMock
//            .Setup(x => x.GetSummaryAsync())
//            .ReturnsAsync(new AppointmentSummaryDto());

//        var result = await _service.GetSummaryAsync();

//        Assert.NotNull(result);
//    }

//    [Fact]
//    public async Task GetDashboardSummaryAsync_ShouldReturnSummary()
//    {
//        _repositoryMock
//            .Setup(x => x.GetDashboardSummaryAsync())
//            .ReturnsAsync(new AppointmentSummaryDto());

//        var result = await _service.GetDashboardSummaryAsync();

//        Assert.NotNull(result);
//    }
//    [Fact]
//    public async Task GetDoctorSchedule_ShouldReturnEmptyList()
//    {
//        _repositoryMock
//            .Setup(x => x.GetDoctorSchedule(
//                It.IsAny<DateOnly>(),
//                1))
//            .ReturnsAsync(new List<AppointmentListDto>());

//        var result = await _service.GetDoctorSchedule(
//            DateOnly.FromDateTime(DateTime.Today),
//            1);

//        Assert.NotNull(result);
//        Assert.Empty(result);
//    }
//    [Fact]
//    public async Task GetPatientSchedule_ShouldReturnEmptyList()
//    {
//        _repositoryMock
//            .Setup(x => x.GetPatientSchedule(
//                It.IsAny<DateOnly>(),
//                1))
//            .ReturnsAsync(new List<AppointmentListDto>());

//        var result = await _service.GetPatientSchedule(
//            DateOnly.FromDateTime(DateTime.Today),
//            1);

//        Assert.NotNull(result);
//        Assert.Empty(result);
//    }
//    [Fact]
//    public async Task GetAppointmentByPatient_ShouldReturnEmptyList()
//    {
//        _repositoryMock
//            .Setup(x => x.GetAppointmentByPatient(1))
//            .ReturnsAsync(new List<AppointmentListDto>());

//        var result = await _service.GetAppointmentByPatient(1);

//        Assert.NotNull(result);
//        Assert.Empty(result);
//    }
//    [Fact]
//    public async Task GetAppointmentByDoctor_ShouldReturnEmptyList()
//    {
//        _repositoryMock
//            .Setup(x => x.GetAppointmentByDoctor(1))
//            .ReturnsAsync(new List<AppointmentListDto>());

//        var result = await _service.GetAppointmentByDoctor(1);

//        Assert.NotNull(result);
//        Assert.Empty(result);
//    }
//    [Fact]
//    public async Task GetReport_ShouldUseDefaultDateRange()
//    {
//        _repositoryMock
//            .Setup(x => x.GetReport(
//                It.IsAny<DateOnly>(),
//                It.IsAny<DateOnly>()))
//            .ReturnsAsync(new List<AppointmentReportDto>());

//        await _service.GetReport(
//            new AppointmentReportFilter());

//        _repositoryMock.Verify(
//            x => x.GetReport(
//                It.IsAny<DateOnly>(),
//                It.IsAny<DateOnly>()),
//            Times.Once);
//    }
//    [Fact]
//    public async Task AddAsync_ShouldThrow_WhenRepositoryAddFails()
//    {
//        var dto = new CreateAppointmentDto
//        {
//            DoctorId = 1,
//            ScheduledDate =
//                DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
//            TimeSlot = "09:00 AM"
//        };

//        var appointment = new Appointment();

//        _repositoryMock
//            .Setup(x => x.IsAvailable(
//                dto.ScheduledDate,
//                dto.DoctorId,
//                dto.TimeSlot))
//            .ReturnsAsync(true);

//        _mapperMock
//            .Setup(x => x.Map<Appointment>(dto))
//            .Returns(appointment);

//        _repositoryMock
//            .Setup(x => x.AddAsync(It.IsAny<Appointment>()))
//            .ThrowsAsync(new DbUpdateException());

//        await Assert.ThrowsAsync<InvalidOperationException>(
//            () => _service.AddAsync(dto, 1));
//    }
//    [Fact]
//    public async Task UpdateStatusAsync_ShouldSetCancellationReason()
//    {
//        var appointment = new Appointment();

//        _repositoryMock
//            .Setup(x => x.GetByIdAsync(1))
//            .ReturnsAsync(appointment);

//        var dto = new UpdateAppointmentDto
//        {
//            Status = "Cancelled",
//            CancellationReason = "Patient Request"
//        };

//        await _service.UpdateStatusAsync(1, dto);

//        Assert.Equal("Cancelled", appointment.Status);
//        Assert.Equal("Patient Request", appointment.CancellationReason);
//    }

//    [Fact]
//    public async Task AddAsync_ShouldSetPatientId()
//    {
//        var dto = new CreateAppointmentDto
//        {
//            DoctorId = 1,
//            ScheduledDate =
//                DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
//            TimeSlot = "10:00 AM"
//        };

//        var appointment = new Appointment();

//        _repositoryMock
//            .Setup(x => x.IsAvailable(
//                dto.ScheduledDate,
//                dto.DoctorId,
//                dto.TimeSlot))
//            .ReturnsAsync(true);

//        _mapperMock
//            .Setup(x => x.Map<Appointment>(dto))
//            .Returns(appointment);

//        await _service.AddAsync(dto, 50);

//        Assert.Equal(50, appointment.PatientId);
//    }
//    [Fact]
//    public async Task IsAvailable_ShouldCallRepositoryOnce()
//    {
//        _repositoryMock
//            .Setup(x => x.IsAvailable(
//                It.IsAny<DateOnly>(),
//                It.IsAny<int>(),
//                It.IsAny<string>()))
//            .ReturnsAsync(true);

//        await _service.IsAvailable(
//            DateOnly.FromDateTime(DateTime.Today),
//            1,
//            "09:00 AM");

//        _repositoryMock.Verify(
//            x => x.IsAvailable(
//                It.IsAny<DateOnly>(),
//                It.IsAny<int>(),
//                It.IsAny<string>()),
//            Times.Once);
//    }



//}