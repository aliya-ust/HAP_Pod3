using System;
using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Interfaces;

namespace HealthApp.ConsoleApp.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorDb _doctorDb;

        public DoctorRepository(DoctorDb doctorDb)
        {
            _doctorDb = doctorDb;
        }

        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor));

            doctor.DoctorId = _doctorDb.Doctors.Count > 0
                ? _doctorDb.Doctors.Max(d => d.DoctorId) + 1
                : 1;

            _doctorDb.Doctors.Add(doctor);
        }

        public List<Doctor> GetAllDoctors()
        {
            return new List<Doctor>(_doctorDb.Doctors);
        }

        public List<Doctor> GetDoctorsBySpecialisation(string specialisation)
        {
            if (string.IsNullOrWhiteSpace(specialisation))
                return new List<Doctor>();

            return _doctorDb.Doctors
                .Where(d => d.Specialisation.Equals(specialisation, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Doctor GetDoctorById(int id)

        {

            return _doctorDb.Doctors.FirstOrDefault(d => d.DoctorId == id);

        }
    }
}
