using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.Models
{

    [Index(nameof(Email), IsUnique = true)]
    public class User // User model with necessary constraints
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        [AllowedValues("Patient", "Doctor", "Admin", ErrorMessage = "Role must be Patient, Doctor, or Admin.")]
        public string Role { get; set; } = null!;  // Patient / Doctor / Admin

        [MaxLength(512)]
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiry { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Navigation
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
    }
}