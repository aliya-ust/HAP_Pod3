using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.ConsoleApp.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepo;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepo = doctorRepository;
        }

        public string AddDoctor(Doctor doctor)
        {
            var existingDoctor = GetDoctorById(doctor.DoctorId);

            if (existingDoctor != null)
            {
                throw new DoctorAlreadyExistsException("Doctor already exists.");
            }

            return _doctorRepo.AddDoctor(doctor);
        }

        public Doctor? GetDoctorById(int doctorId)
        {
            return _doctorRepo.GetDoctorById(doctorId);
        }

        public List<Doctor> GetDoctorsBySpecialisation(string specialisation)
        {
            var result = _doctorRepo.GetDoctorsBySpecialisation(specialisation);

            if (result == null || result.Count == 0)
            {
                throw new SpecialisationNotFoundException($"Doctor with specialisation in {specialisation} does not exist");
            }

            return result;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            return _doctorRepo.UpdateDoctor(doctor);
        }

        public string DeleteDoctor(int id)
        {
            return _doctorRepo.DeleteDoctor(id);
        }

        // public List<Doctor> GetAllDoctors()
        // {
        //     return doctorRepository.GetAllDoctors();
        // }
    }
}
