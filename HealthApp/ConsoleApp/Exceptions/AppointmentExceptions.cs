using System;

namespace HealthApp.ConsoleApp.Exceptions
{
    public class AppointmentConflictException : Exception
    {
        public AppointmentConflictException(string message) : base(message)
        {
        }
    }

    public class AppointmentNotFoundException : Exception
    {
        public AppointmentNotFoundException(string message) : base(message)
        {
        }
    }

    public class PastDateException : Exception
    {
        public PastDateException(string message) : base(message)
        {
        }
    }

    public class DoctorUnavailableException : Exception
    {
        public DoctorUnavailableException(string message) : base(message)
        {
        }
    }
}
