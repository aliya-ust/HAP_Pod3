namespace HealthCare.Shared.DTOs
{
    public class DashboardDoctorDto
    {
        public int UpcomingAppointments { get; set; }

        public int CompletedAppointments { get; set; }

        public int UpcomingLeaves { get; set; }

        public List<TodayAppointmentSlotDto> TodayAppointments { get; set; } = new();
    }
}