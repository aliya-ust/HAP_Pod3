namespace HealthCare.Shared.DTOs.Doctor
{
    public class DoctorDashboardSummaryDto
    {
        public int UpcomingAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int UpcomingLeaves { get; set; }
        public int TodaysAppointments { get; set; }
    }
} 