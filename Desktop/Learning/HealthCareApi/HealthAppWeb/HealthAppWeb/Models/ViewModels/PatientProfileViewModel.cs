using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAppWeb.Models.ViewModels
{
    public class PatientProfileViewModel
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string InsuranceId { get; set; }
    }
}