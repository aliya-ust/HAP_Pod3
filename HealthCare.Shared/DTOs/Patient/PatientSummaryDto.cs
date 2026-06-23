using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Api.DTOs.Patient
{
    public class PatientSummaryDto
    {
        public int TotalPatients { get; set; }
        public int ActivePatients { get; set; }
    }

}
