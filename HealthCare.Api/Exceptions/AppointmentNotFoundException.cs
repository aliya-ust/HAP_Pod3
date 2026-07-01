namespace HealthCare.Api.Exceptions
{
    public class AppointmentNotFoundException : Exception
    {

        public AppointmentNotFoundException()
                   : base($"Appointment not found") { }

    }
}