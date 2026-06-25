using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Shared.DTOs
{
    public class DashboardSummaryDto
    {
        public int TotalDoctors { get; set; }
        public int ActiveDoctors { get; set; }
        public int TotalPatients { get; set; }

        public int TotalAppointments { get; set; }

        public int PendingAppointments { get; set; }
        public int ConfirmedAppointments { get; set; }
        public int CancelledAppointments { get; set; }
        public int CompletedAppointments { get; set; }

        public decimal TotalRevenue { get; set; }
    }
}
