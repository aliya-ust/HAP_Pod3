using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Models;

namespace HealthApp_Testing
{
    public class PatientRepositoryTests
    {
     
        private PatientDb _db;
        private PatientRepository _repository;


        public PatientRepositoryTests()
        {

            _db = new();
            _repository = new ();

        }
        [Fact]
        public void GetAll_WhenCalled_ShouldReturnAllPatients()
        {
            var patients = _repository.GetAll();
            Assert.NotNull(patients);
            Assert.Equal(3, patients.Count);
            Assert.Equal("Arjun", patients[0].Name);
        }

        [Fact]
        public void GetById_ExistingId_ShouldReturnPatient()
        {
            var patient = _repository.GetById(1);
            Assert.NotNull(patient);
            Assert.Equal("Arjun", patient.Name);
        }

        [Fact]
        public void GetById_NonExistingId_ShouldReturnNull()
        {
            var patient = _repository.GetById(999);
            Assert.Null(patient);
        }

        [Fact]
        public void Add_ValidPatient_ShouldAddPatient()
        {
            var newPatient = new Patient
            {
                Id = 4,
                Name = "Test",
                Dob = new DateTime(2000, 1, 1),
                Gender = "Other",
                InsuranceId = 1
            };
            var initialCount = _repository.GetAll().Count;
            Assert.True("Patient added successfully", _repository.Add(newPatient));
        }
        [Fact]
        public void Update_ExistingPatient_ShouldUpdatePatient()
        {
            var patient = _repository.GetById(1);
            patient.Name = "Aarick";
            var result = _repository.Update(patient);
            Assert.True(result);
            var updatedPatient = _repository.GetById(1);
            Assert.Equal("Updated Name", updatedPatient.Name);
        }
        [Fact]
        public void Update_NonExistingPatient_ShouldReturnFalse()
        {
            var nonExistingPatient = new Patient
            {
                Id = 999,
                Name = "Non Existing",
                Dob = new DateTime(1990, 1, 1),
            };
            Assert.False(_repository.Update(nonExistingPatient));
        }
        [Fact]
        public void delete_ExistingPatient_ShouldDeletePatient()
        {
            var result = _repository.Delete(1);
            Assert.True(result);
            var deletedPatient = _repository.GetById(1);
            Assert.Null(deletedPatient);
            Assert.Equal(2, _repository.GetAll().Count);

        }
    }
}
