namespace HealthCare.Api.Exceptions
{
    public class EmailAlreadyInUseException : Exception
    {
        public EmailAlreadyInUseException()
            : base("Email already in use") { }
    }
}
