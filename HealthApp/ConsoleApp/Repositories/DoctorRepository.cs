using System;
using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Database;
using HealthApp.ConsoleApp.Interfaces;

namespace HealthApp.ConsoleApp.Repositories.impl
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorDb doctorDb;

        public DoctorRepository(DoctorDb doctorDb)
        {
            this.doctorDb = doctorDb;
        }

        public void AddDoctor(Doctor doctor)
        {
            doctorDb.Doctors.Add(doctor);
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctorDb.Doctors;
        }

        public List<Doctor> GetDoctorsBySpecialisation(string specialisation)
        {
            return doctorDb.Doctors
                .Where(d => d.Specialisation.Equals(specialisation, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}