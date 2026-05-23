using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.Tests.Repositories
{
    public class HealthRecordRepositoryTests
    {
        private HealthRecordDb _db;
        private HealthRecordRepository _repository;

        public HealthRecordRepositoryTests()
        {
            _db = new HealthRecordDb();
            _repository = new HealthRecordRepository(_db);
        }

        [Fact]
        public void GetByPatientIdOrderByVisitDateDesc_ValidId_ReturnsMatchingRecords()
        {
            var result = _repository.GetByPatientIdOrderByVisitDateDesc(101);

            Assert.NotEmpty(result);
            Assert.All(result, r => Assert.Equal(101, r.Patient.Id));
        }

        [Fact]
        public void GetByDoctorIdOrderByVisitDateDesc_ValidId_ReturnsMatchingRecords()
        {
            var result = _repository.GetByDoctorIdOrderByVisitDateDesc(201);

            Assert.NotEmpty(result);
            Assert.All(result, r => Assert.Equal(201, r.Doctor.DoctorId));
        }

        [Fact]
        public void GetByRecordId_ValidId_ReturnsRecord()
        {
            var result = _repository.GetByRecordId(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.RecordId);
        }
    }
}