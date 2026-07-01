using System.Net.Http.Json;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.Auth;

namespace HealthCare.Admin.Services
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly TokenService _tokenService; 

        public AuthService(HttpClient http, TokenService tokenService)
        {
            _http = http;
            _tokenService = tokenService;
        }

        public async Task LoginAsync(LoginDto loginDto)
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", loginDto);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ApiResponse<AuthResponseDto>>();
            if (result?.Data != null)
            {
                await _tokenService.SetToken(result.Data.AccessToken);
            }
        }
    }
}
