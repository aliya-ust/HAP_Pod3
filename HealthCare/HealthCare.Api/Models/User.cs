using HealthCare.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Api.Models;

  public class User
{
   
    public int UserId { get; set; }

    [Required]
    [MaxLength(255)]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(256)]
    public string PasswordHash { get; set; } = null!;

    [Required]
    [MaxLength(20)]
    public string Role { get; set; } = null!;  // Patient / Doctor / Admin

    [MaxLength(512)]
    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiry { get; set; }
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;


    // Navigation
    public Patient? Patient { get; set; }
    public Doctor? Doctor { get; set; }
    }
