using Xunit;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.Tests
{
    public class AppointmentRepositoryTests
    {
        private readonly AppointmentRepository _repo;

        public AppointmentRepositoryTests()
        {
            var doctorDb = new DoctorDb();
            var patientDb = new PatientDb();
            var appointmentDb = new AppointmentDb(doctorDb, patientDb);

            _repo = new AppointmentRepository(appointmentDb);
        }

        [Fact]
        public void GetAllAppointments_ShouldReturnList()
        {
            // Act
            var result = _repo.GetAllAppointments();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetAppointmentById_ShouldReturnAppointment()
        {
            // Arrange
            int id = 301;

            // Act
            var result = _repo.GetAppointmentById(id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteAppointment_ShouldRemove()
        {
            // Arrange
            int id = 301;

            // Act
            _repo.DeleteAppointment(id);
            var result = _repo.GetAppointmentById(id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void UpdateAppointment_ShouldUpdate()
        {
            // Arrange
            var appt = _repo.GetAppointmentById(301);
            appt.TimeSlot = "05:00 PM";

            // Act
            _repo.UpdateAppointment(appt);
            var updated = _repo.GetAppointmentById(301);

            // Assert
            Assert.Equal("05:00 PM", updated.TimeSlot);
        }
    }
}