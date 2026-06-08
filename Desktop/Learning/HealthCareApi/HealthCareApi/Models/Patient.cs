using HealthCareApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareApi.Models
{
    [Table("Patients")]
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public int? UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } // "Male" | "Female" | "Other"

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string InsuranceId { get; set; }

        public DateTime CreatedDate { get; set; }

        // Navigation
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}