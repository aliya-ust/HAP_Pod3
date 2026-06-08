using HealthCareApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareApi.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } // "Patient" | "Doctor" | "Admin"

        // Navigation (logically 1-to-1, enforced by UNIQUE in DB)
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}