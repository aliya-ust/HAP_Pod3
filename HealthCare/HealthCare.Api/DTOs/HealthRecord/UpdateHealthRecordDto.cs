using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.HealthRecord
{
    public class UpdateHealthRecordDto
    {
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