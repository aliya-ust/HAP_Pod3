using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthApp.ConsoleApp.Models
{
    // Represents a doctor in the healthcare system
    public class Doctor
    {

        public int DoctorId { get; set; }
        public string Name { get; set; } = "";
        public string Specialisation { get; set; } = "";
        public int YearsOfExperience { get; set; } = 0;
        public decimal ConsultationFee { get; set; } = 0;
        public bool IsActive { get; set; }
        public List<string> AvailableSlots { get; set; } = new List<string>();

        public List<DateTime> AvailableDates { get; set; } = new List<DateTime>();

        //Availability method
        public virtual bool IsAvailable(DateTime date)
        {
            if (!IsActive)
            {
                return false;
            }

            int count = AvailableDates.Count(d => d.Date == date.Date);

            if (count >= 8)
            {
                return false;
            }

            return true;
        }

        //Upcoming count
        public string GetScheduleSummary()
        {
            int count = AvailableDates.Count(d => d.Date >= DateTime.Today);

            if (count == 0)
            {
                return "No available slots";
            }

            return $"Available slots count: {count}";
        }

        //Upcoming list
        public List<DateTime> GetUpcomingAppointments()
        {
            return AvailableDates
                .Where(d => d.Date >= DateTime.Today)
                .OrderBy(d => d)
                .ToList();
        }

        public string GetDoctorDetails()
        {
            return $"Doctor ID: {DoctorId}, Full Name: {Name}, Specialisation: {Specialisation}, Experience: {YearsOfExperience} years, Consultation Fee: Rs. {ConsultationFee}, Active: {(IsActive ? "Yes" : "No")}";
        }
    }
}