using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Services;

namespace HealthApp.Tests
{
    public class AppointmentServiceTests
    {
        private readonly Mock<IAppointmentRepository> _mockRepo;
        private readonly AppointmentService _service;

        public AppointmentServiceTests()
        {
            _mockRepo = new Mock<IAppointmentRepository>();
            _service = new AppointmentService(_mockRepo.Object);
        }

        [Fact]
        public void BookAppointment_ShouldSucceed()
        {
            // Arrange
            var patient = new Patient
            {
                PatientId = 101,
                Name = "John",
                Gender = "Male",
                PhoneNumber = "9999999999",
                Email = "john@test.com",
                InsuranceId = "INS101",
                Dob = DateTime.Now.AddYears(-25)
            };

            var doctor = new Doctor
            {
                DoctorId = 201,
                FullName = "Dr.Test",
                Specialisation = "General",
                IsActive = true,
                AvailableDates = new List<DateTime> { DateTime.Now.AddDays(1) },
                AvailableSlots = new List<string> { "10:00 AM" }
            };

            _mockRepo.Setup(r => r.GetAllAppointments())
                     .Returns(new List<Appointment>());

            _mockRepo.Setup(r => r.AddAppointment(It.IsAny<Appointment>()));

            // Act
            var result = _service.BookAppointment(
                patient,
                doctor,
                DateTime.Now.AddDays(1),
                "10:00 AM"
            );

            // Assert
            Assert.NotNull(result);
            Assert.Equal(AppointmentStatus.Confirmed, result.Status);
        }

        [Fact]
        public void BookAppointment_PastDate_ShouldThrow()
        {
            // Arrange
            var patient = new Patient
            {
                PatientId = 101,
                Name = "John",
                Gender = "Male",
                PhoneNumber = "9999999999",
                Email = "john@test.com",
                InsuranceId = "INS101",
                Dob = DateTime.Now.AddYears(-25)
            };

            var doctor = new Doctor
            {
                DoctorId = 201,
                FullName = "Dr.Test",
                Specialisation = "General",
                IsActive = true
            };

            // Act & Assert
            Assert.Throws<PastDateException>(() =>
                _service.BookAppointment(
                    patient,
                    doctor,
                    DateTime.Now.AddDays(-1),
                    "10:00 AM"
                ));
        }
    }
}