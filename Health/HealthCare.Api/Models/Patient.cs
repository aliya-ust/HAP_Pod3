using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Api.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
        [Required]        
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        //[Required]
        //[MaxLength(100)]
        //[EmailAddress]
        //public string Email { get; set; } = null!;
        [MaxLength(50)]
        public string InsuranceId { get; set; }

        public bool IsActive { get; set; } = true;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        public ICollection<Appointment> Appointments { get; set; } = [];
        public ICollection<HealthRecord> HealthRecords { get; set; } = [];

    }
}
