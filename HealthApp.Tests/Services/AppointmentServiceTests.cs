using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Xunit;

public class AppointmentServiceTests
{
    private readonly Mock<IAppointmentRepository> _appointmentRepoMock;
    private readonly AppointmentService _appointmentService;

    public AppointmentServiceTests()
    {
        // Arrange (Create Mock Repository)
        _appointmentRepoMock = new Mock<IAppointmentRepository>();

        // Inject mock into service
        _appointmentService = new AppointmentService(_appointmentRepoMock.Object);
    }

    private Patient GetPatient() => new Patient { PatientId = 1, FullName = "John Doe" };

    private Doctor GetDoctor() =>
        new Doctor
        {
            DoctorId = 10,
            FullName = "Dr. Smith",
            Specialisation = "Cardiology"
        };

    // Test: Successful Booking
    [Fact]
    public void BookAppointment_Should_Create_Appointment_When_Valid()
    {
        // Arrange
        var patient = GetPatient();
        var doctor = GetDoctor();
        var date = DateTime.Now.AddDays(1);
        var slot = "10 AM";

        _appointmentRepoMock.Setup(r => r.GetAll())
            .Returns(new List<Appointment>());

        // Act
        var result = _appointmentService.BookAppointment(patient, doctor, date, slot);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(patient, result.Patient);
        Assert.Equal(AppointmentStatus.Pending, result.Status);

        _appointmentRepoMock.Verify(r => r.Add(It.IsAny<Appointment>()), Times.Once);
    }

    //  Test: Past Date Exception
    [Fact]
    public void BookAppointment_Should_Throw_PastDateException()
    {
        var patient = GetPatient();
        var doctor = GetDoctor();
        var pastDate = DateTime.Now.AddDays(-1);

        Assert.Throws<PastDateException>(() =>
            _appointmentService.BookAppointment(patient, doctor, pastDate, "10 AM"));
    }

    // Test: Slot Conflict
    [Fact]
    public void BookAppointment_Should_Throw_Conflict_When_Slot_Exists()
    {
        var patient = GetPatient();
        var doctor = GetDoctor();
        var date = DateTime.Now.AddDays(1);

        var existingAppointments = new List<Appointment>
        {
            new Appointment
            {
                Doctor = doctor,
                ScheduledDate = date,
                TimeSlot = "10 AM",
                Status = AppointmentStatus.Confirmed
            }
        };

        _appointmentRepoMock.Setup(r => r.GetAll())
            .Returns(existingAppointments);

        Assert.Throws<AppointmentConflictException>(() =>
            _appointmentService.BookAppointment(patient, doctor, date, "10 AM"));
    }

    //  Test: Cancel Appointment
    [Fact]
    public void CancelAppointment_Should_Update_Status()
    {
        var appointment = new Appointment
        {
            AppointmentId = 1,
            Status = AppointmentStatus.Pending
        };

        _appointmentRepoMock.Setup(r => r.GetById(1))
            .Returns(appointment);

        // Act
        _appointmentService.CancelAppointment(1, "Not available");

        // Assert
        Assert.Equal(AppointmentStatus.Cancelled, appointment.Status);

        _appointmentRepoMock.Verify(r => r.Update(appointment), Times.Once);
    }

    // Test: GetAppointmentsByPatient
    [Fact]
    public void GetAppointmentsByPatient_Should_Return_List()
    {
        var expectedList = new List<Appointment> { new Appointment() };

        _appointmentRepoMock.Setup(r => r.GetByPatientId(1))
            .Returns(expectedList);

        var result = _appointmentService.GetAppointmentsByPatient(1);

        Assert.Single(result);
    }

    // Test: GetUpcomingAppointments
    [Fact]
    public void GetUpcomingAppointments_Should_Return_Future_Confirmed()
    {
        var appointments = new List<Appointment>
        {
            new Appointment
            {
                ScheduledDate = DateTime.Now.AddDays(1),
                Status = AppointmentStatus.Confirmed
            },
            new Appointment
            {
                ScheduledDate = DateTime.Now.AddDays(-1),
                Status = AppointmentStatus.Confirmed
            }
        };

        _appointmentRepoMock.Setup(r => r.GetAll())
            .Returns(appointments);

        var result = _appointmentService.GetUpcomingAppointments();

        Assert.Single(result);
    }
}