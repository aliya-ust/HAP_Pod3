namespace HealthCare.Api.Exceptions
{
    public class ClaimNotFoundException : Exception
    {
        public ClaimNotFoundException(string claimName)
            : base($"'{claimName}' claim not found in token.") { }
    }
}
