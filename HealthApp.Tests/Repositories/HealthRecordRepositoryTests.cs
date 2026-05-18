using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.Tests
{
    public class HealthRecordRepositoryTests
    {
        private HealthRecordDb _db;
        private HealthRecordRepositoryTests _repository;

        public HealthRecordRepositoryTests()
        {
            _db = new ProductDb();
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
        public void GetByPatientIdOrderByVisitDateDesc_NoMatchingRecords_ReturnsEmptyList()
        {
            var result = _repository.GetByPatientIdOrderByVisitDateDesc(999);

            Assert.Empty(result);
        }

        [Fact]
        public void GetByPatientIdOrderByVisitDateDesc_MultiplePatients_ReturnsOnlyMatchingRecords()
        {
            var result = _repository.GetByPatientIdOrderByVisitDateDesc(102);

            Assert.Single(result);
            Assert.All(result, r => Assert.Equal(102, r.Patient.Id));
        }

        [Fact]
        public void GetByPatientIdOrderByVisitDateDesc_MultipleRecords_SortedDescending()
        {
            var result = _repository.GetByPatientIdOrderByVisitDateDesc(101);

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.True(result[i].VisitDate >= result[i + 1].VisitDate);
            }
        }

        [Fact]
        public void GetByPatientIdOrderByVisitDateDesc_RecordWithNullPatient_Ignored()
        {
            var result = _repository.GetByPatientIdOrderByVisitDateDesc(101);

            Assert.DoesNotContain(result, r => r.Patient == null);
        }

        [Fact]
        public void GetByPatientIdOrderByVisitDateDesc_SameDates_ReturnsAll()
        {
            var result = _repository.GetByPatientIdOrderByVisitDateDesc(101);

            var count = result.Count(r => r.VisitDate == new DateTime(2026, 5, 12));

            Assert.Equal(2, count);
        }

        [Fact]
        public void GetByPatientIdOrderByVisitDateDesc_OneRecord_ReturnsSingle()
        {
            var result = _repository.GetByPatientIdOrderByVisitDateDesc(102);

            Assert.Single(result);
        }

        [Fact]
        public void GetByDoctorIdOrderByVisitDateDesc_ValidId_ReturnsMatchingRecords()
        {
            var result = _repository.GetByDoctorIdOrderByVisitDateDesc(201);

            Assert.NotEmpty(result);
            Assert.All(result, r => Assert.Equal(201, r.Doctor.DoctorId));
        }

        [Fact]
        public void GetByDoctorIdOrderByVisitDateDesc_NoMatchingRecords_ReturnsEmptyList()
        {
            var result = _repository.GetByDoctorIdOrderByVisitDateDesc(999);

            Assert.Empty(result);
        }

        [Fact]
        public void GetByDoctorIdOrderByVisitDateDesc_Filtering_Works()
        {
            var result = _repository.GetByDoctorIdOrderByVisitDateDesc(202);

            Assert.All(result, r => Assert.Equal(202, r.Doctor.DoctorId));
        }

        [Fact]
        public void GetByDoctorIdOrderByVisitDateDesc_SortedDescending()
        {
            var result = _repository.GetByDoctorIdOrderByVisitDateDesc(201);

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.True(result[i].VisitDate >= result[i + 1].VisitDate);
            }
        }

        [Fact]
        public void GetByDoctorIdOrderByVisitDateDesc_NullDoctor_Ignored()
        {
            var result = _repository.GetByDoctorIdOrderByVisitDateDesc(201);

            Assert.DoesNotContain(result, r => r.Doctor == null);
        }

        [Fact]
        public void GetByDoctorIdOrderByVisitDateDesc_OneRecord_ReturnsSingle()
        {
            var result = _repository.GetByDoctorIdOrderByVisitDateDesc(203);

            Assert.Single(result);
        }

        [Fact]
        public void GetByRecordId_ValidId_ReturnsRecord()
        {
            var result = _repository.GetByRecordId(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.RecordId);
        }

        [Fact]
        public void GetByRecordId_InvalidId_ThrowsHealthRecordNotFoundException()
        {
            Assert.Throws<HealthRecordNotFoundException>(() =>
                _repository.GetByRecordId(999)
            );
        }

        [Fact]
        public void GetByRecordId_InvalidId_ThrowsExceptionWithCorrectMessage()
        {
            var exception = Assert.Throws<HealthRecordNotFoundException>(() =>
                _repository.GetByRecordId(999)
            );

            Assert.Equal("There is no Health Records Available", exception.Message);
        }
    }
}