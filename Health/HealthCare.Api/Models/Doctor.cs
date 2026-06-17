using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Api.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
        [Range(0,60)]
        public int YearsOfExperience { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, 100000)]
        public int ConsultationFee { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        [MaxLength(50)]
        public string Specialisation { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = [];
        public ICollection<HealthRecord> HealthRecords { get; set; } = [];
        public ICollection<AvailableSlots> AvailableSlots { get; set; } = [];
        public ICollection<DoctorLeaves> Leaves { get; set; } = [];
    }
}
