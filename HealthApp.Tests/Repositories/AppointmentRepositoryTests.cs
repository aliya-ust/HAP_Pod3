using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Databases;
namespace HealthApp.Tests.Repositories
{
    public class AppointmentRepositoryTests
    {
        private AppointmentDb _db;
        private AppointmentRepository _repository;

        public AppointmentRepositoryTests()
        {
            _db = new AppointmentDb();
            _repository = new AppointmentRepository(_db);
        }

        [Fact]
        public void GetAllAppointments_ReturnsAllAppointments()
        {
            var result = _repository.GetAllAppointments();

            Assert.Equal(4, result.Count);
        }

        [Fact]
        public void GetAppointmentById_ValidId_ReturnsAppointment()
        {
            var result = _repository.GetAppointmentById(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.AppointmentId);
        }

        [Fact]
        public void GetAppointmentById_InvalidId_ReturnsNull()
        {
            var result = _repository.GetAppointmentById(999);

            Assert.Null(result);
        }
    }
}