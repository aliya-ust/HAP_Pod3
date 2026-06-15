using HealthCare.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Api.Models
{

    public class Patient // Patient model with necessary constraints
    {
        [Key]
        public int PatientId { get; set; }

        public int UserId { get; set; }

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

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Navigation
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = [];
        public ICollection<HealthRecord> HealthRecords { get; set; } = [];
    }
}