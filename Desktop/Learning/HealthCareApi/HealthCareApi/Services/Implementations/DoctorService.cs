using HealthCareApi.Data.Repositories.Interfaces;
using HealthCareApi.Services.Interfaces;
using HealthCareApi.Models;
using System.Collections.Generic;

namespace HealthCareApi.Services.Implementations
{
    public class DoctorService : IDoctorService
    {

        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAll();
        }

    }
}
