namespace HealthCare.Shared.DTOs.Doctor
{
    public class DoctorDashboardDto
    {
        public int UpcomingAppointments { get; set; }

        public int PatientsTreated { get; set; }

        public int UpcomingLeaves { get; set; }

        public List<string> TodaysSchedule { get; set; } = [];
    }
}