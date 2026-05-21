using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases
{
    public class AppointmentDb
    {
        public List<Appointment> Appointments = new List<Appointment>
        {
            new Appointment
            {
                AppointmentId = 1,
                Patient = new Patient { Id = 1, Name = "Priya" },
                Doctor = new Doctor { DoctorId = 1, FullName = "Dr. Ananya Iyer" },
                ScheduledDate = DateTime.Now.AddDays(1),
                TimeSlot = "09:30 AM",
                Status = AppointmentStatus.Confirmed
            },

            new Appointment
            {
                AppointmentId = 2,
                Patient = new Patient { Id = 2, Name = "Abu" },
                Doctor = new Doctor { DoctorId = 2, FullName = "Dr. Rohit Sharma" },
                ScheduledDate = DateTime.Now.AddDays(2),
                TimeSlot = "11:00 AM",
                Status = AppointmentStatus.Pending
            },
          
        };
    }
}