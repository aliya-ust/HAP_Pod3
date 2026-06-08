using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAppWeb.Models
{
    public class DoctorAvailableSlot
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string TimeSlot { get; set; }
    }
}