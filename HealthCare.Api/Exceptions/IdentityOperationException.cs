namespace HealthCare.Api.Exceptions
{
    public class IdentityOperationException : Exception
    {
        public IdentityOperationException(string message)
            : base(message) { }
    }
}
