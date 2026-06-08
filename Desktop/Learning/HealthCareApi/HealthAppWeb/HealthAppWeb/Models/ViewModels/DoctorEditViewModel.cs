using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthAppWeb.Models.ViewModels
{
    public class DoctorEditViewModel
    {
        public int DoctorId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Specialisation { get; set; }

        [Required]
        [Range(0, 60)]
        [Display(Name = "Years of Experience")]
        public int YearsOfExperience { get; set; }

        [Required]
        [Range(0, 100000)]
        [Display(Name = "Consultation Fee")]
        public decimal ConsultationFee { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}