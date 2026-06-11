using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareApi.Models
{
    [Table("DoctorLeaves")]
    public class DoctorLeave
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime LeaveDate { get; set; }

        [MaxLength(500)]
        public string Reason { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
    }
}