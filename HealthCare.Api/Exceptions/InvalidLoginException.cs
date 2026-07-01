namespace HealthCare.Api.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException()
            : base("Invalid email or password.") { }

        public InvalidLoginException(string message)
            : base(message) { }
    }
}
