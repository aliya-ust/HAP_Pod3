using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HealthCare.Shared.DTOs.CreateDoctorDto
{
    [ExcludeFromCodeCoverage]
    public class CreateDoctorDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Only letters allowed")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Specialisation is required")]
        [StringLength(50)]
        public string Specialisation { get; set; }

        [Range(0, 60, ErrorMessage = "Experience must be between 0 and 60")]
        public int YearsOfExperience { get; set; }

        [Range(0, 100000, ErrorMessage = "Invalid fee")]
        public decimal ConsultationFee { get; set; }

        public List<string> AvailableSlots { get; set; }
    }
}
