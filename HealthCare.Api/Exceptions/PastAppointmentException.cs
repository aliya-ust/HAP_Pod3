namespace HealthCare.Api.Exceptions
{
    public class PastAppointmentException : Exception
    {
        public PastAppointmentException()
                    : base("Cannot book an appointment for a past date.") { }

        public PastAppointmentException(string message)
                    : base(message) { }
    }
}