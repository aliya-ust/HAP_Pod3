namespace HealthCare.Api.Exceptions
{
    public class SlotAlreadyBookedException : Exception
    {
        public SlotAlreadyBookedException()
            : base("This time slot is already booked.") { }
    }
}
