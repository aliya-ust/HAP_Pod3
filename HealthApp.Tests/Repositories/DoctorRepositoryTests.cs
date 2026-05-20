using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Databases;
namespace HealthApp.Tests.Repositories
{
    public class DoctorRepositoryTests
    {
        private DoctorDb _db;
        private DoctorRepository _repository;

        public DoctorRepositoryTests()
        {
            _db = new DoctorDb();
            _repository = new DoctorRepository(_db);
        }

        [Fact]
        public void GetAllDoctors_ReturnsAllDoctors()
        {
            var result = _repository.GetAllDoctors();

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void GetByDoctorId_ValidId_ReturnsDoctor()
        {
            var result = _repository.GetByDoctorId(201);

            Assert.NotNull(result);
            Assert.Equal(201, result.DoctorId);
        }

        [Fact]
        public void GetDoctorsBySpecialisation_ValidSpecialisation_ReturnsMatchingDoctors()
        {
            var result = _repository.GetDoctorsBySpecialisation("Cardiology");

            Assert.NotEmpty(result);
            Assert.All(result, d => Assert.Equal("Cardiology", d.Specialisation));
        }
    }
}