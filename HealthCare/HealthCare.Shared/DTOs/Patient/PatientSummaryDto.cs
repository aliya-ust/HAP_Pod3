using System;
using System.Collections.Generic;
using System.Text;
using HealthCare.Api.DTOs;
namespace HealthCare.Shared.DTOs.Patient
{
    public class PatientSummaryDto
    {
        public int TotalPatients { get; set; }
        public int ActivePatients { get; set; }
    }

}