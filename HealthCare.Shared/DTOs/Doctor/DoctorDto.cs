using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HealthCare.Shared.DTOs.Doctor
{
    [ExcludeFromCodeCoverage]
    public class DoctorDto
    {
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Full Name is Required")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage ="Only Letters are allowed")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Specialisation is Required")]
        public string Specialisation { get; set; }

        [Required(ErrorMessage = "Years Of Experience is Required")]
        [Range(0,50)]
        public int YearsOfExperience { get; set; }

        [Required(ErrorMessage = "Consultation Fee is Required")]
        public decimal ConsultationFee { get; set; }
        public bool IsActive { get; set; }

        public List<string> DoctorAvailableSlots { get; set; }
    }
}