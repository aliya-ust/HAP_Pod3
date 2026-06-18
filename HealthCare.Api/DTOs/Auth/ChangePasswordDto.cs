using System.ComponentModel.DataAnnotations;

namespace HealthCare.Api.DTOs.Auth
{
    public class ChangePasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        public string NewPassword { get; set; } = string.Empty;
]
    }
}
