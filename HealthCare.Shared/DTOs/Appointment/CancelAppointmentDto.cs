using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace HealthCare.Shared.DTOs.Appointment
{
    [ExcludeFromCodeCoverage]
    public class CancelAppointmentDto
    {
        public string Reason { get; set; }
    }
}