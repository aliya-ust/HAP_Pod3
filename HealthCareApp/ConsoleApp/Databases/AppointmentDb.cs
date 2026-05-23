using System;
using System.Collections.Generic;
using System.Linq;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases
{
    public class AppointmentDb
    {
        private readonly DoctorDb _doctorDb;
        private readonly PatientDb _patientDb;

        public List<Appointment> appointments;   // ✅ DECLARE HERE

        // ✅ SINGLE constructor (DI version)
        public AppointmentDb(DoctorDb doctorDb, PatientDb patientDb)
        {
            _doctorDb = doctorDb;
            _patientDb = patientDb;

            appointments = new List<Appointment>
            {
                new Appointment
                {
                    AppointmentId = 301,

                    Patient = _patientDb.Patients
                        .FirstOrDefault(p => p.PatientId == 101),

                    Doctor = new Doctor
                    {
                        DoctorId = 201,
                        FullName = "Dr. John Smith",
                        Specialisation = "Cardiology"
                    },

                    ScheduledDate = DateTime.Today.AddDays(1),
                    TimeSlot = "10:00 AM",
                    Status = AppointmentStatus.Confirmed
                },

                new Appointment
                {
                    AppointmentId = 302,

                    Patient = _patientDb.Patients
                        .FirstOrDefault(p => p.PatientId == 102),

                    Doctor = new Doctor
                    {
                        DoctorId = 202,
                        FullName = "Dr. Emily Davis",
                        Specialisation = "Dermatology"
                    },

                    ScheduledDate = DateTime.Today.AddDays(2),
                    TimeSlot = "12:00 PM",
                    Status = AppointmentStatus.Confirmed   // ✅ changed from Pending
                }
            };
        }
    }
}