using AutoMapper;
using FluentAssertions;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace HealthCare.Api.Tests;

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
            .ReturnsAsync((Appointment)null!);

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
            .ReturnsAsync((Appointment)null!);

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
            .ReturnsAsync((Appointment)null!);

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

    [Fact]
    public async Task GetAllAsync_ShouldFilterByStatusAndDate()
    {
        var filter = new AppointmentFilter
        {
            Status = "Confirmed",
            ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
            PageNumber = 1,
            PageSize = 10
        };

        var paged = new PagedResult<Appointment>
        {
            Items = new List<Appointment> { new Appointment() },
            PageNumber = 1,
            PageSize = 10,
            TotalCount = 1
        };

        _repositoryMock
            .Setup(r => r.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                It.IsAny<System.Linq.Expressions.Expression<Func<Appointment, bool>>>(),
                It.IsAny<Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>>>()))
            .ReturnsAsync(paged);

        _mapperMock.Setup(m => m.Map<IEnumerable<AppointmentListDto>>(paged.Items))
            .Returns(new List<AppointmentListDto>
            {
            new AppointmentListDto()
            });

        var result = await _service.GetAllAsync(filter);

        result.TotalCount.Should().Be(1);
    }

    [Fact]
    public async Task GetAllAsync_ShouldFilterOnlyStatus()
    {
        var filter = new AppointmentFilter
        {
            Status = "Pending",
            PageNumber = 1,
            PageSize = 10
        };

        _repositoryMock.Setup(r =>
            r.GetAllAsync(
                1,
                10,
                It.IsAny<Expression<Func<Appointment, bool>>>(),
                It.IsAny<Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>>>()))
            .ReturnsAsync(new PagedResult<Appointment>());

        _mapperMock.Setup(x => x.Map<IEnumerable<AppointmentListDto>>(It.IsAny<IEnumerable<Appointment>>()))
            .Returns(new List<AppointmentListDto>());

        await _service.GetAllAsync(filter);

        _repositoryMock.VerifyAll();
    }

    [Fact]
    public async Task GetAllAsync_ShouldFilterOnlyDate()
    {
        var filter = new AppointmentFilter
        {
            ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
            PageNumber = 1,
            PageSize = 10
        };

        _repositoryMock.Setup(r =>
            r.GetAllAsync(
                1,
                10,
                It.IsAny<Expression<Func<Appointment, bool>>>(),
                It.IsAny<Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>>>()))
            .ReturnsAsync(new PagedResult<Appointment>());

        _mapperMock.Setup(x => x.Map<IEnumerable<AppointmentListDto>>(It.IsAny<IEnumerable<Appointment>>()))
            .Returns(new List<AppointmentListDto>());

        await _service.GetAllAsync(filter);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllAppointments()
    {
        var filter = new AppointmentFilter
        {
            PageNumber = 1,
            PageSize = 10
        };

        _repositoryMock.Setup(r =>
            r.GetAllAsync(
                1,
                10,
                null,
                It.IsAny<Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>>>()))
            .ReturnsAsync(new PagedResult<Appointment>());

        _mapperMock.Setup(x => x.Map<IEnumerable<AppointmentListDto>>(It.IsAny<IEnumerable<Appointment>>()))
            .Returns(new List<AppointmentListDto>());

        await _service.GetAllAsync(filter);
    }

    [Fact]
    public async Task UpdateStatusAsync_ShouldThrow_WhenAppointmentMissing()
    {
        _repositoryMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync((Appointment)null!);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.UpdateStatusAsync(1, new UpdateAppointmentDto()));
    }

    [Fact]
    public async Task UpdateStatusAsync_ShouldUpdateStatus()
    {
        var appointment = new Appointment();

        _repositoryMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(appointment);

        var dto = new UpdateAppointmentDto
        {
            Status = "Completed",
            CancellationReason = "None"
        };

        await _service.UpdateStatusAsync(1, dto);

        appointment.Status.Should().Be("Completed");
        appointment.CancellationReason.Should().Be("None");

        _repositoryMock.Verify(x => x.UpdateAsync(appointment), Times.Once);
    }

    [Fact]
    public async Task DeleteAsync_ShouldThrow_WhenRepositoryThrowsDbUpdateException()
    {
        var appointment = new Appointment();

        _repositoryMock.Setup(x => x.GetByIdAsync(1))
            .ReturnsAsync(appointment);

        _repositoryMock.Setup(x => x.DeleteAsync(1))
            .ThrowsAsync(new DbUpdateException());

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.DeleteAsync(1));
    }

    [Fact]
    public async Task AvailableTimeSlots_ShouldThrow_WhenDateIsPast()
    {
        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            _service.AvailableTimeSlots(
                DateOnly.FromDateTime(DateTime.Today.AddDays(-1)),
                1));
    }

    [Fact]
    public async Task GetDoctorSchedule_ShouldReturnEmptyList()
    {
        _repositoryMock.Setup(x =>
            x.GetDoctorSchedule(It.IsAny<DateOnly>(), 1))
            .ReturnsAsync(new List<AppointmentListDto>());

        var result = await _service.GetDoctorSchedule(
            DateOnly.FromDateTime(DateTime.Today),
            1);

        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetDoctorSchedule_ShouldReturnAppointments()
    {
        var list = new List<AppointmentListDto>
    {
        new AppointmentListDto()
    };

        _repositoryMock.Setup(x =>
            x.GetDoctorSchedule(It.IsAny<DateOnly>(), 1))
            .ReturnsAsync(list);

        var result = await _service.GetDoctorSchedule(
            DateOnly.FromDateTime(DateTime.Today),
            1);

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetAvailableDoctorsAsync_ShouldReturnEmpty_WhenNoSlots()
    {
        var date = DateOnly.FromDateTime(DateTime.Today);

        _context.Doctors.Add(new Doctor
        {
            DoctorId = 1,
            FullName = "Doctor",
            IsActive = true,
            Specialisation = "Cardiology"
        });

        await _context.SaveChangesAsync();

        _doctorServiceMock.Setup(x =>
            x.AvailableTimeSlotsCheck(date, 1))
            .ReturnsAsync(new List<string>());

        var result = await _service.GetAvailableDoctorsAsync(date, "Cardiology");

        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAvailableDoctorsAsync_ShouldReturnDoctor()
    {
        var date = DateOnly.FromDateTime(DateTime.Today);

        _context.Doctors.Add(new Doctor
        {
            DoctorId = 2,
            FullName = "Dr Smith",
            IsActive = true,
            Specialisation = "Cardiology"
        });

        await _context.SaveChangesAsync();

        _doctorServiceMock.Setup(x =>
            x.AvailableTimeSlotsCheck(date, 2))
            .ReturnsAsync(new List<string>
            {
            "9"
            });

        var result = await _service.GetAvailableDoctorsAsync(date, "Cardiology");

        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetAvailableSlotsAsync_ShouldRemoveBookedSlots()
    {
        var date = DateOnly.FromDateTime(DateTime.Today);

        _doctorServiceMock.Setup(x =>
            x.AvailableTimeSlotsCheck(date, 1))
            .ReturnsAsync(new List<string>
            {
            "9","10","11"
            });

        _context.Appointments.Add(new Appointment
        {
            DoctorId = 1,
            ScheduledDate = date,
            TimeSlot = "10"
        });

        await _context.SaveChangesAsync();

        var result = await _service.GetAvailableSlotsAsync(1, date);

        result.Should().Contain("9");
        result.Should().Contain("11");
        result.Should().NotContain("10");
    }
}