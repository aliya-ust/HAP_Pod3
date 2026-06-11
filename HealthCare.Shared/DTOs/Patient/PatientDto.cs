using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Shared.DTOs.Patient
{
    public class PatientDto
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(PatientDto), nameof(ValidateDOB))]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [RegularExpression("Male|Female|Other", ErrorMessage = "Select a valid gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter a valid 10-digit phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Insurance ID cannot exceed 50 characters")]
        public string InsuranceId { get; set; }

        //  Custom DOB validation
        public static ValidationResult ValidateDOB(DateTime dob, ValidationContext context)
        {
            if (dob > DateTime.Today)
            {
                return new ValidationResult("Date of Birth cannot be in the future");
            }

            if (dob > DateTime.Today.AddYears(-1))
            {
                return new ValidationResult("Patient must be at least 1 year old");
            }

            if (dob < DateTime.Today.AddYears(-120))
            {
                return new ValidationResult("Enter a valid Date of Birth");
            }

            return ValidationResult.Success;
        }
    }
}