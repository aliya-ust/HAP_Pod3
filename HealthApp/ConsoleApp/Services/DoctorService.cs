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
            List<Doctor> doctors = _doctorRepo.GetAllDoctors();
            doctor.DoctorId = DoctorIdGenerator(doctors);

            return _doctorRepo.AddDoctor(doctor);
        }

        public Doctor? GetDoctorById(int doctorId)
        {
            Doctor? doctor = _doctorRepo.GetDoctorById(doctorId);

            if (doctor is null)
            {
                throw new DoctorNotFoundException($"Doctor of ID {doctorId} does not exist");
            }
            return doctor;
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
            Doctor? existingDoctor = GetDoctorById(doctor.DoctorId);

            if (existingDoctor is null)
            {
                throw new DoctorNotFoundException($"Doctor of ID {doctor.DoctorId} does not exist");
            }
            return _doctorRepo.UpdateDoctor(existingDoctor, doctor);
        }

        public string DeleteDoctor(int id)
        {
            return _doctorRepo.DeleteDoctor(id);
        }

        public int DoctorIdGenerator(List<Doctor> doctors)
        {
            return doctors.Any()
                ? doctors.Max(d => d.DoctorId) + 1
                : 101;
        }

        // public List<Doctor> GetAllDoctors()
        // {
        //     return doctorRepository.GetAllDoctors();
        // }
    }
}
