using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.HealthRecord
{
    public class CreateHealthRecordDto
    {
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string Diagnosis { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string Prescription { get; set; } = null!;

        [MaxLength(1000)]
        public string? Notes { get; set; }
    }
}
