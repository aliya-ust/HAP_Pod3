using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases
{
    public class DoctorDb
    {
        private List<Doctor> _doctors = new List<Doctor>();

        public List<Doctor> Doctors
        {
            get { return _doctors; }
            set { _doctors = value; }
        }
    }
}