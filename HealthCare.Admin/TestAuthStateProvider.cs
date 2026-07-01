using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace HealthCare.Admin
{
    public class TestAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, "TestAdmin"),
            new Claim(ClaimTypes.Role, "Admin")
        }, "TestAuth");

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
