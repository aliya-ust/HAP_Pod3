using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthApp.ConsoleApp.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Specialisation { get; set; } = string.Empty;

        public int YearsOfExperience { get; set; }

        public decimal ConsultationFee { get; set; }

        public bool IsActive { get; set; } = true;

        public List<DateTime> Appointments { get; set; } = new List<DateTime>();

        public bool IsAvailable(DateTime date)
        {
            if (!IsActive)
            {
                return false;
            }
 
            int count = Appointments.Count(a => a.Date == date.Date);
 
            if (count >= 8)
            {
                return false;
            }
 
            return true;
        }


        public string CheckAvailability(DateTime date)
        {
            if (!IsActive)
                return "Doctor is not active.";

            int count = Appointments.Count(a => a.Date == date.Date);

            if (count >= 5)
                return "Appointment limit reached for the day.";

            return "Doctor is available.";
        }

        public string GetScheduleSummary()
        {
            int count = Appointments.Count(a => a.Date >= DateTime.Today);

            return count == 0
                ? "No upcoming appointments."
                : $"Upcoming appointments count: {count}";
        }

        public List<DateTime> GetUpcomingAppointments()
        {
            return Appointments
                .Where(a => a.Date >= DateTime.Today)
                .OrderBy(a => a)
                .ToList();
        }

        public string GetDoctorDetails()
        {
            return $"Doctor ID: {DoctorId} | Name: {FullName} | Specialisation: {Specialisation} | Experience: {YearsOfExperience} years | Fee: ₹{ConsultationFee} | Active: {(IsActive ? "Yes" : "No")}";
        }
    }
}