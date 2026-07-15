namespace HealthCare.Api.Exceptions
{
    public class NoAvailableSlotsException : Exception
    {
        public NoAvailableSlotsException()
            : base("No available slots found for this doctor.") { }
    }
}