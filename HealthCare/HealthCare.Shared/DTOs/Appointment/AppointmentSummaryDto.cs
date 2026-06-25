namespace HealthCare.Shared.DTOs
{
    public class AppointmentSummaryDto
    {
        public int PendingCount { get; set; }

        public int ConfirmedCount { get; set; }

        public int CancelledCount { get; set; }

        public int CompletedCount { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}