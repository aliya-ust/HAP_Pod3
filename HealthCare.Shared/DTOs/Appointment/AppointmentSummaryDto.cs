using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Api.DTOs.Appointment
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
