namespace HealthApp.ConsoleApp.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public required string FullName { get; set; }
        public required string Specialisation { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal ConsultationFee { get; set; }
        public bool IsActive { get; set; }

        //Availability method
        // public string IsAvailable(DateTime date)
        // {
        //     if (!IsActive)
        //     {
        //         return "Doctor is not available";
        //     }

        //     int count = Appointments.Count(a => a.Date == date.Date);

        //     if (count >= 5)
        //     {
        //         return "Appointment limit reached, doctor is not available";
        //     }

        //     return "Doctor is available today";
        // }

        //Upcoming count
        // public string GetScheduleSummary()
        // {
        //     int count = Appointments.Count(a => a.Date >= DateTime.Today);

        //     if (count == 0)
        //     {
        //         return "No upcoming appointments";
        //     }

        //     return $"Upcoming appointments count: {count}";
        // }

        //Upcoming list
        // public List<DateTime> GetUpcomingAppointments()
        // {
        //     return Appointments
        //         .Where(a => a.Date >= DateTime.Today)
        //         .OrderBy(a => a)
        //         .ToList();
        // }

        // public string GetDoctorDetails()
        // {
        //     return $"Doctor ID: {DoctorId}, Full Name: {FullName}, Specialisation: {Specialisation}, Experience: {YearsOfExperience} years, Consultation Fee: Rs. {ConsultationFee}, Active: {(IsActive ? "Yes" : "No")}";
        // }
    }
}
