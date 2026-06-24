using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.Doctor
{
    public class CreateLeaveDto
    {
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateOnly LeaveDate { get; set; }

        [Required]
        [StringLength(250)]
        public string Reason { get; set; } = string.Empty;
    }
}