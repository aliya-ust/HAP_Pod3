using System;

namespace HealthApp.ConsoleApp.Exceptions
{
    public class PatientInvalidException : Exception
    {
        public PatientInvalidException()
            : base("Patient data is invalid.")
        {
        }

        public PatientInvalidException(string message)
            : base(message)
        {
        }
    }

    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException(int id)
            : base($"Patient with ID {id} not found.")
        {
        }
    }
}