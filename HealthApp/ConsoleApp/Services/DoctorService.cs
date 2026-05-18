using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.ConsoleApp.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public void AddDoctor(Doctor doctor)
        {
            List<Doctor> doctors = doctorRepository.GetAllDoctors();

            // Check duplicate ID
            foreach (var d in doctors)
            {
                if (d.DoctorId == doctor.DoctorId)
                {
                    throw new DoctorAlreadyExistsException("Doctor ID already exists!");
                }
            }

            //Add if no duplicate
            doctorRepository.AddDoctor(doctor);
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctorRepository.GetAllDoctors();
        }

        public List<Doctor> SearchBySpecialisation(string specialisation)
        {
            var doctors = doctorRepository.GetDoctorsBySpecialisation(specialisation);

            //Throw exception if not found
            if (doctors == null || doctors.Count == 0)
            {
                throw new SpecialisationNotFoundException("No doctors found for this specialisation!");
            }

            return doctors;
        }
    }
}
