
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Models;

namespace HealthApp_Testing
{
    public class PatientRepositoryTests
    {
        private readonly PatientDb _db;
        private readonly PatientRepository _repository;

        //  Dependency Injection
        public PatientRepositoryTests()
        {
            _db = new PatientDb();                   
            _repository = new PatientRepository(_db); 
        }

        [Fact]
        public void GetAll_WhenCalled_ShouldReturnAllPatients()
        {
            var patients = _repository.GetAllPatients();

            Assert.NotNull(patients);
            Assert.Equal(3, patients.Count);
            Assert.Equal("Arjun", patients[0].Name);
        }

        [Fact]
        public void GetById_ExistingId_ShouldReturnPatient()
        {
            var patient = _repository.GetPatientById(1);

            Assert.NotNull(patient);
            Assert.Equal("Arjun", patient.Name);
        }

        [Fact]
        public void GetById_NonExistingId_ShouldReturnNull()
        {
            var patient = _repository.GetPatientById(999);

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
                Gender = Patient.GenderType.Male,
                InsuranceId = "A123"
            };

            _repository.AddPatient(newPatient);

            Assert.Equal(4, _repository.GetAllPatients().Count);
        }

        [Fact]
        public void Update_ExistingPatient_ShouldUpdatePatient()
        {
            var patient = _repository.GetPatientById(1);

            patient.Name = "Aarick";
            _repository.UpdatePatient(patient);
            var updatedPatient = _repository.GetPatientById(1);

            Assert.Equal("Aarick", updatedPatient.Name);  
        }

        [Fact]
        public void Update_NonExistingPatient_ShouldReturnFalse()
        {
            var nonExistingPatient = new Patient
            {
                Id = 999,
                Name = "Non Existing",
                Dob = new DateTime(1990, 1, 1),
                Gender = Patient.GenderType.Other,
                InsuranceId = "A1"
            };

            _repository.UpdatePatient(nonExistingPatient);

            var result = _repository.GetPatientById(999);
            Assert.Null(result);

        }

        [Fact]
        public void Delete_ExistingPatient_ShouldDeletePatient()
        {
            _repository.DeletePatient(1);
            var deletedPatient = _repository.GetPatientById(1);

            Assert.Null(deletedPatient);
            Assert.Equal(2, _repository.GetAllPatients().Count);
        }
    }
}
