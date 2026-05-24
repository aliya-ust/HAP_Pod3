using System;
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

            if (string.IsNullOrWhiteSpace(doctor.FullName))
                throw new DoctorInvalidException("Doctor name required.");

            if (string.IsNullOrWhiteSpace(doctor.Specialisation))
                throw new DoctorInvalidException("Specialisation required.");

            if (doctor.YearsOfExperience < 0)
                throw new DoctorInvalidException("Invalid experience.");

            if (doctor.ConsultationFee < 0)
                throw new DoctorInvalidException("Invalid fee.");

            var doctors = _doctorRepository.GetAllDoctors();

            foreach (var d in doctors)
            {
                if (d.FullName.Equals(doctor.FullName, StringComparison.OrdinalIgnoreCase) &&
                    d.Specialisation.Equals(doctor.Specialisation, StringComparison.OrdinalIgnoreCase))
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
            if (id <= 0)
                throw new DoctorInvalidException("Invalid Doctor ID.");

            var doctor = _doctorRepository.GetDoctorById(id);

            if (doctor == null)
                throw new DoctorNotFoundException($"Doctor with ID {id} not found.");

            return doctor;
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

        public void UpdateDoctor(Doctor doctor)
        {
            if (doctor == null)
                throw new DoctorInvalidException("Invalid doctor data.");

            if (doctor.DoctorId <= 0)
                throw new DoctorInvalidException("Invalid Doctor ID.");

            var existing = _doctorRepository.GetDoctorById(doctor.DoctorId);

            if (existing == null)
                throw new DoctorNotFoundException($"Doctor with ID {doctor.DoctorId} not found.");

            if (string.IsNullOrWhiteSpace(doctor.FullName))
                throw new DoctorInvalidException("Doctor name cannot be empty.");

            if (string.IsNullOrWhiteSpace(doctor.Specialisation))
                throw new DoctorInvalidException("Specialisation cannot be empty.");

            if (doctor.YearsOfExperience < 0)
                throw new DoctorInvalidException("Invalid experience.");

            if (doctor.ConsultationFee < 0)
                throw new DoctorInvalidException("Invalid fee.");

            _doctorRepository.UpdateDoctor(doctor);
        }
    }
}