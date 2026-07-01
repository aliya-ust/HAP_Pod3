using System.Security.Claims;

namespace HealthCare.Api.Utilities
{
    public static class ClaimsHelper
    {
        public static int GetPatientId(ClaimsPrincipal user)
        {
            var claim = user.FindFirst("PatientId")
                ?? throw new InvalidOperationException("PatientId claim not found in token.");

            return int.Parse(claim.Value);
        }

        public static int GetDoctorId(ClaimsPrincipal user)
        {
            var claim = user.FindFirst("DoctorId")
                ?? throw new InvalidOperationException("DoctorId claim not found in token.");

            return int.Parse(claim.Value);
        }
    }
}
