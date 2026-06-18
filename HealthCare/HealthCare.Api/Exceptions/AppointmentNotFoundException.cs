
using HealthCare.Api.Exceptions;

namespace HealthCare.Api.Exceptions
{
    public class AppointmentNotFoundException : Exception
    {

        public AppointmentNotFoundException(int id)
                   : base($"Appointment with ID {id} not found") { }

    }
}