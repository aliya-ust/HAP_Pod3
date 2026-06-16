using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Api.Models
{

    [Index(nameof(Specialisation), Name = "IX_Doctors_Specialisation")]
    public class Doctor // Doctor model with necessary constraints
    {
        [Key]
        public int DoctorId { get; set; }

        public string? UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Specialisation { get; set; } = null!;

        [Required]
        [Range(0, 60)]
        public int YearsOfExperience { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 100000)]
        public decimal ConsultationFee { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTimeOffset CreatedDate { get; set; }

        // Navigation
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = [];
        public ICollection<HealthRecord> HealthRecords { get; set; } = [];
        public ICollection<AvailableSlots> AvailableSlots { get; set; } = [];
        public ICollection<DoctorLeaves> Leaves { get; set; } = [];
    }
}