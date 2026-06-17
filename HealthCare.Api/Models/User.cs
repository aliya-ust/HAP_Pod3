using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace HealthCare.Api.Models
{

    [SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty",
        Justification = "Required for future extensibility of Identity user")
    ]
    public class User : IdentityUser
    {
    }
}
