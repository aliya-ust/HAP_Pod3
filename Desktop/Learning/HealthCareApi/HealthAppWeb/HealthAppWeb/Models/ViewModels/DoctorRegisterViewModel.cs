using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthAppWeb.Models.ViewModels
{
    public class DoctorRegisterViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Passwords do not match.")]
        //[Display(Name = "Confirm Password")]
        //public string ConfirmPassword { get; set; }

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
    }
}