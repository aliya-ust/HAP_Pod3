using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.Models
{

    public class Patient // Patient model with necessary constraints
    {
        [Key]
        public int PatientId { get; set; }

        public string? UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [MaxLength(10)]
        [AllowedValues("Male", "Female", "Other", ErrorMessage = "Gender must be Male, Female, or Other.")]
        public string Gender { get; set; } = null!;  // Male / Female / Other

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = null!;

        [MaxLength(50)]
        public string? InsuranceId { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTimeOffset CreatedDate { get; set; }

        // Navigation
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<HealthRecord> HealthRecords { get; set; } = new List<HealthRecord>();
    }
}