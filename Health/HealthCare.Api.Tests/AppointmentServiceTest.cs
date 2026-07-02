using Xunit;
using Moq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HealthCare.Api.Data;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Api.Models;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Appointment;
using FluentAssertions;

public class AppointmentServiceTests
{
    private readonly Mock<IAppointmentRepository> _repositoryMock;
    private readonly Mock<IDoctorService> _doctorServiceMock;
    private readonly Mock<IMapper> _mapperMock;

    private readonly HealthCareDbContext _context;

    private readonly AppointmentService _service;

    public AppointmentServiceTests()
    {
        var options = new DbContextOptionsBuilder<HealthCareDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _context = new HealthCareDbContext(options);

        _repositoryMock = new Mock<IAppointmentRepository>();
        _doctorServiceMock = new Mock<IDoctorService>();
        _mapperMock = new Mock<IMapper>();

        _service = new AppointmentService(
            _repositoryMock.Object,
            _doctorServiceMock.Object,
            _context,
            _mapperMock.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsAppointment()
    {
        var appointment = new Appointment();

        var dto = new AppointmentListDto();

        _repositoryMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(appointment);

        _mapperMock.Setup(x => x.Map<AppointmentListDto>(appointment))
            .Returns(dto);

        var result = await _service.GetByIdAsync(1);

        result.Should().Be(dto);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsNull_WhenAppointmentNotFound()
    {
        _repositoryMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync((Appointment)null);

        var result = await _service.GetByIdAsync(1);

        result.Should().BeNull();
    }

    [Fact]
    public async Task AddAsync_ShouldThrow_WhenDateIsPast()
    {
        var dto = new CreateAppointmentDto
        {
            ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-1))
        };

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.AddAsync(dto, 1));
    }

    [Fact]
    public async Task AddAsync_ShouldBookAppointment()
    {
        _context.Doctors.Add(new Doctor
        {
            DoctorId = 1,
            FullName = "Doctor",
            IsActive = true,
            Specialisation = "Cardiology"
        });

        await _context.SaveChangesAsync();

        var dto = new CreateAppointmentDto
        {
            DoctorId = 1,
            ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            TimeSlot = "09:00 AM"
        };

        _repositoryMock.Setup(x =>
            x.IsAvailable(dto.ScheduledDate, 1, dto.TimeSlot))
            .ReturnsAsync(true);

        _mapperMock.Setup(x => x.Map<Appointment>(dto))
            .Returns(new Appointment());

        await _service.AddAsync(dto, 1);

        _repositoryMock.Verify(x => x.AddAsync(It.IsAny<Appointment>()), Times.Once);
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrow_WhenAppointmentNotFound()
    {
        _repositoryMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync((Appointment)null);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.UpdateAsync(1, new UpdateAppointmentDto()));
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateAppointment()
    {
        var appointment = new Appointment();

        _repositoryMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(appointment);

        await _service.UpdateAsync(1, new UpdateAppointmentDto());

        _repositoryMock.Verify(x => x.UpdateAsync(appointment), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrow_WhenAppointmentMissing()
    {
        _repositoryMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync((Appointment)null);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.DeleteAsync(1));
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteAppointment()
    {
        _repositoryMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(new Appointment());

        await _service.DeleteAsync(1);

        _repositoryMock.Verify(x => x.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task IsAvailable_ReturnsTrue()
    {
        _repositoryMock.Setup(x =>
            x.IsAvailable(It.IsAny<DateOnly>(), 1, "9"))
            .ReturnsAsync(true);

        var result = await _service.IsAvailable(
            DateOnly.FromDateTime(DateTime.Today),
            1,
            "9");

        result.Should().BeTrue();
    }

    [Fact]
    public async Task IsAvailable_ShouldThrow_WhenBooked()
    {
        _repositoryMock.Setup(x =>
            x.IsAvailable(It.IsAny<DateOnly>(), 1, "9"))
            .ReturnsAsync(false);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.IsAvailable(DateOnly.FromDateTime(DateTime.Today), 1, "9"));
    }

    [Fact]
    public async Task ValidateDoctorAvailability_ShouldThrow_WhenDoctorInactive()
    {
        _context.Doctors.Add(new Doctor
        {
            DoctorId = 1,
            FullName = "Dr John",
            Specialisation = "Cardiology",
            ConsultationFee = 500,
            YearsOfExperience = 5,
            IsActive = false
        });

        await _context.SaveChangesAsync();

        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.ValidateDoctorAvailability(
                1,
                DateOnly.FromDateTime(DateTime.Today)));

        Assert.Equal("Doctor is inactive.", ex.Message);
    }

    [Fact]
    public async Task ValidateDoctorAvailability_ShouldThrow_WhenDoctorOnLeave()
    {
        var date = DateOnly.FromDateTime(DateTime.Today);

        _context.Doctors.Add(new Doctor
        {
            DoctorId = 1,
            FullName = "Dr John",
            Specialisation = "Cardiology",
            ConsultationFee = 500,
            YearsOfExperience = 5,
            IsActive = true
        });

        _context.DoctorLeaves.Add(new DoctorLeaves
        {
            DoctorId = 1,
            LeaveDate = date,
            Reason = "Vacation"
        });

        await _context.SaveChangesAsync();

        var ex = await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.ValidateDoctorAvailability(1, date));

        Assert.Equal("Doctor is on leave on selected date.", ex.Message);
    }

    [Fact]
    public async Task AvailableTimeSlots_ReturnsAvailableSlots()
    {
        var date = DateOnly.FromDateTime(DateTime.Today);

        _doctorServiceMock.Setup(x => x.GetSlots(1))
            .ReturnsAsync(new List<string>
            {
            "9","10","11"
            });

        _repositoryMock.Setup(x => x.BookedTimeSlots(date, 1))
            .ReturnsAsync(new List<string> { "10" });

        var result = await _service.AvailableTimeSlots(date, 1);

        result.Should().Contain("9");
        result.Should().Contain("11");
        result.Should().NotContain("10");
    }

    [Fact]
    public async Task ConfirmAppointment_CallsRepository()
    {
        await _service.ConfirmAppointment(5);

        _repositoryMock.Verify(x =>
            x.ConfirmAppointment(5),
            Times.Once);
    }

    [Fact]
    public async Task CancelAppointment_CallsRepository()
    {
        await _service.CancelAppointment(5);

        _repositoryMock.Verify(x =>
            x.CancelAppointment(5),
            Times.Once);
    }
}