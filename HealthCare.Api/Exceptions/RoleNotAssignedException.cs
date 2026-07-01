namespace HealthCare.Api.Exceptions
{
    public class RoleNotAssignedException : Exception
    {
        public RoleNotAssignedException()
            : base("Role is not assigned.") { }
    }
}
