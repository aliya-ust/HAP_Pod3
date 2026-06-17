using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;

namespace HealthCare.Api.Services.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public Task<Patient> CreateAsync(Patient patient, CancellationToken ct = default)
            => _patientRepository.CreateAsync(patient, ct);

        public Task<Patient> UpdateAsync(int id, Patient patient, CancellationToken ct = default)
            => _patientRepository.UpdateAsync(id, patient, ct);

        public Task<Patient> DeleteAsync(Patient patient, CancellationToken ct = default)
            => _patientRepository.DeleteAsync(patient, ct);

        public Task<List<Patient>> GetAllAsync(CancellationToken ct = default)
            => _patientRepository.GetAllAsync(ct);

        public Task<Patient> GetByIdAsync(int id, CancellationToken ct = default)
            => _patientRepository.GetByIdAsync(id, ct);

        public Task<List<Patient>> SearchPatientsByNameAsync(string name, CancellationToken ct = default)
            => _patientRepository.SearchPatientsByNameAsync(name, ct);

        public Task<List<Patient>> GetPatientsByGenderAsync(string gender, CancellationToken ct = default)
            => _patientRepository.GetPatientsByGenderAsync(gender, ct);
    }
}
