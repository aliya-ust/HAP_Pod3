//using HealthCare.Api.Models;
//using HealthCare.Api.Repositories.Interfaces;
//using HealthCare.Api.Services.Interfaces;

//namespace HealthCare.Api.Services.Implementation
//{
//    public class DoctorService : IDoctorService
//    {
//        private readonly IDoctorRepository _doctorRepository;

//        public DoctorService(IDoctorRepository doctorRepository)
//        {
//            _doctorRepository = doctorRepository;
//        }

//        public Task<Doctor> CreateAsync(Doctor doctor, CancellationToken ct = default)
//            => _doctorRepository.CreateAsync(doctor, ct);

//        public Task<Doctor> UpdateAsync(int id, Doctor doctor, CancellationToken ct = default)
//            => _doctorRepository.UpdateAsync(id, doctor, ct);

//        public Task<Doctor> DeleteAsync(Doctor doctor, CancellationToken ct = default)
//            => _doctorRepository.DeleteAsync(doctor, ct);

//        public Task<List<Doctor>> GetAllAsync(CancellationToken ct = default)
//            => _doctorRepository.GetAllAsync(ct);

//        public Task<Doctor> GetByIdAsync(int id, CancellationToken ct = default)
//            => _doctorRepository.GetByIdAsync(id, ct);

//        public Task<List<Doctor>> GetDoctorsBySpecializationAsync(string specialization, CancellationToken ct = default)
//            => _doctorRepository.GetDoctorsBySpecializationAsync(specialization, ct);
//    }
//}
