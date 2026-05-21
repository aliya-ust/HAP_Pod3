using System.Collections.Generic;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.ConsoleApp.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null)
                throw new DoctorInvalidException("Doctor data is invalid.");

            var doctors = _doctorRepository.GetAllDoctors();

            foreach (var d in doctors)
            {
                if (d.FullName == doctor.FullName &&
                    d.Specialisation == doctor.Specialisation)
                {
                    throw new DoctorAlreadyExistsException("Doctor already exists with same name & specialisation!");
                }
            }

            _doctorRepository.AddDoctor(doctor);
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAllDoctors();
        }

        public Doctor GetDoctorById(int id)
        {
            return _doctorRepository.GetDoctorById(id);
        }

        public List<Doctor> SearchBySpecialisation(string specialisation)
        {
            if (string.IsNullOrWhiteSpace(specialisation))
                throw new DoctorInvalidException("Specialisation cannot be empty.");

            var doctors = _doctorRepository.GetDoctorsBySpecialisation(specialisation);

            if (doctors == null || doctors.Count == 0)
                throw new SpecialisationNotFoundException("No doctors found for this specialisation.");

            return doctors;
        }
    }
}
