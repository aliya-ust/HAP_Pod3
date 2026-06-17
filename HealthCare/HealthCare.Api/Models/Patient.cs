using HealthCare.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Api.Models;

public class Patient
{
    [Key]
    public int PatientId { get; set; }

    public int? UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = null!;
   

    [Required] 
    public DateOnly DateOfBirth { get; set; }

    [Required]
    [MaxLength(10)]
    
    public string? Gender { get; set; }
 
    [Required]
    [MaxLength(20)]
    
    public string?PhoneNumber { get; set; }

   

    [MaxLength(50)]
    public string? InsuranceId { get; set; }
    

    
    public bool IsActive { get; set; } = true;

    // Navigation
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = [];
    public ICollection<HealthRecord> HealthRecords { get; set; } = [];
}