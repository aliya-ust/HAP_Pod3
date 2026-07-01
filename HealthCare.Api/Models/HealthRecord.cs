using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Api.Models
{
    public class HealthRecord // Health Record model with necessary constraints
    {
        [Key]
        public int RecordId { get; set; }

        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        [Required]
        public DateOnly VisitDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string Diagnosis { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Prescription { get; set; } = null!;

        [MaxLength(1000)]
        public string? Notes { get; set; }

        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

        // Navigation
        [ForeignKey(nameof(AppointmentId))]
        public Appointment Appointment { get; set; } = null!;

        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; } = null!;

        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;
    }
}