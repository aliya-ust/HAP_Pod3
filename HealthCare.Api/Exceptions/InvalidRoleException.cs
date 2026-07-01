namespace HealthCare.Api.Exceptions
{
    public class InvalidRoleException : Exception
    {
        public InvalidRoleException()
            : base("Invalid role.") { }
    }
}
