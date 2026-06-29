namespace HealthCare.Shared.DTOs
{
    public class DashboardPatientDto
    {
        public int UpcomingAppointments { get; set; }

        public int HealthRecordCount { get; set; }

        public string PatientName { get; set; } = string.Empty;
    }
}