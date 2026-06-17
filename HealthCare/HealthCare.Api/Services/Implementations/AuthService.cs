using HealthCare.Api.DTOs.Auth;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealthCare.Api.Services.Implementations
{
    public class AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration) : IAuthService//Primary Constructor

    {

        public async Task<(bool success, string Message, string UserId)> RegisterAsync(RegisterDto request)

        {

            // Step 1: Validate password match 

            if (request.Password != request.ConfirmPassword)

            {

                return (false, "Password do not match", string.Empty);

            }



            // Step 2: Validate role 

            if (request.Role != "Admin" && request.Role != "Patient" && request.Role != "Doctor" )

            {

                return (false, "Invalid Role, must be Admin or Patient or Doctor", string.Empty);

            }



            // Step 3: Create new Identity user 

            var user = new IdentityUser

            {

                UserName = request.Email,  // Username set to email 

                Email = request.Email

            };



            // Step 4: Create user with hashed password 

            var result = await userManager.CreateAsync(user, request.Password);



            // Step 5: Check if user creation failed 

            if (!result.Succeeded)

            {

                // Collect all error messages 

                var errors = string.Join(",", result.Errors.Select(e => e.Description));

                return (false, errors, string.Empty);

            }



            // Step 6: Assign role to user 

            await userManager.AddToRoleAsync(user, request.Role);



            // Step 7: Return success 

            return (true, "User Registered successfully", user.Id);

        }



        public async Task<(bool Success, string Message, string AccessToken, int ExpiresIn)> LoginAsync(LoginDto request)

        {

            // Step 1: Find user by email 

            var user = await userManager.FindByEmailAsync(request.Email);

            if (user is null)

            {

                return (false, "Invalid Credentials", string.Empty, 0);

            }



            // Step 2: Validate password 

            var passwordValid = await userManager.CheckPasswordAsync(user, request.Password);

            if (!passwordValid)

            {

                return (false, "Invalid Credentials", string.Empty, 0);

            }



            // Step 3: Generate JWT token 

            var token = await GenerateJwtToken(user);



            // Step 4: Get expiration time 

            var expirationMinutes = int.Parse(configuration.GetSection("jwt")["AccessTokenExpirationMinutes"]!);



            // Step 5: Return success with token (convert minutes to seconds) 

            return (true, "Login Successful", token, expirationMinutes * 60);

        }



        private async Task<string> GenerateJwtToken(IdentityUser user)

        {

            // Step 1: Get JWT settings from configuration 

            var jwtSetting = configuration.GetSection("jwt");



            // Step 2: Create signing key from secret 

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting["Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



            // Step 3: Get user's roles 

            var roles = await userManager.GetRolesAsync(user);



            // Step 4: Create claims (user information stored in token) 

            var claims = new List<Claim>()

        {

            new Claim(JwtRegisteredClaimNames.Sub, user.Id),          // Subject (User ID) 

            new Claim(JwtRegisteredClaimNames.Email, user.Email!),    // Email 

            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT ID (unique token ID) 

            new Claim(ClaimTypes.NameIdentifier, user.Id)             // Name Identifier 

        };



            // Step 5: Add role claims — MUST use ClaimTypes.Role for [Authorize(Roles=)] to work 

            foreach (var role in roles)

            {

                claims.Add(new Claim(ClaimTypes.Role, role));

            }



            // Step 6: Get token expiration 

            var expirationMinutes = int.Parse(jwtSetting["AccessTokenExpirationMinutes"]!);



            // Step 7: Create JWT token 

            var token = new JwtSecurityToken(

                issuer: jwtSetting["Issuer"],              // Who created the token 

                audience: jwtSetting["Audience"],          // Who the token is for 

                claims: claims,                            // User information 

                expires: DateTime.UtcNow.AddMinutes(expirationMinutes), // Expiration time 

                signingCredentials: credentials            // Signature 

            );



            // Step 8: Convert token to string and return 

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }


}

