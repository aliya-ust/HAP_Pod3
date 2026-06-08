using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAppWeb.Models
{
    public class DoctorLeave
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime LeaveDate { get; set; }
        public string Reason { get; set; }
    }
}