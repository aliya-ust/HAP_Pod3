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
        public List<DateTime> Appointments { get; set; } = new List<DateTime>();

        public bool IsAvailable(DateTime date)
        {
            if (!IsActive)
            {
                return false;
            }

            int count = Appointments.Count(a => a.Date == date.Date);

            if (count >= 6)
            {
                return false;
            }

            return true;
        }

        // Count of upcoming appointments
        public string GetScheduleSummary()
        {
            int count = Appointments.Count(a => a.Date >= DateTime.Today);

            if (count == 0)
            {
                return "No upcoming appointments";
            }

            return $"Upcoming appointments count: {count}";
        }

        // Formatted string of doctor details
        public override string ToString()
        {
            return $"Doctor ID: {DoctorId} \nFull Name: {FullName} \nSpecialisation: {Specialisation} \nExperience: {YearsOfExperience} years \nConsultation Fee: Rs. {ConsultationFee} \nActive: {(IsActive ? "Yes" : "No")}";
        }
    }
}
