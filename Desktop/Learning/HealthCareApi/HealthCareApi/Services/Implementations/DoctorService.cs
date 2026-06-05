using HealthCareApi.Data.Repositories.Interfaces;
using HealthCareApi.Service.Interfaces;
using HealthCareApi.Models;
using System.Collections.Generic;

namespace HealthCareApi.Service.Implementations
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
