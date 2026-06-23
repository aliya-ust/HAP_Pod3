using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Api.DTOs.Doctor
{
    public class DoctorSummaryDto
    {
        public int TotalDoctors { get; set; }
        public int ActiveDoctors { get; set; }
        public int InactiveDoctors { get; set; }
    }
}
