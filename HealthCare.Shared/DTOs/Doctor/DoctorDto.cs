using System;
using System.Collections.Generic;

namespace HealthCare.Shared.DTOs.Doctor
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string Specialisation { get; set; }

        public int YearsOfExperience { get; set; }
        public decimal ConsultationFee { get; set; }
        public bool IsActive { get; set; }

        public List<string> DoctorAvailableSlots { get; set; }
        public List<DateTime> LeaveDates { get; set; }
    }
}