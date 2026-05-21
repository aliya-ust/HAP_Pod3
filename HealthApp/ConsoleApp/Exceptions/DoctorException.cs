using System;

namespace HealthApp.ConsoleApp.Exceptions
{
    public class DoctorInvalidException : Exception
    {
        public DoctorInvalidException(string message)
            : base(message)
        {
        }
    }

    public class DoctorAlreadyExistsException : Exception
    {
        public DoctorAlreadyExistsException(string message)
            : base(message)
        {
        }
    }

    public class SpecialisationNotFoundException : Exception
    {
        public SpecialisationNotFoundException(string message)
            : base(message)
        {
        }
    }

    public class DoctorNotFoundException : Exception
    {
        public DoctorNotFoundException(int id)
            : base($"Doctor with ID {id} not found.")
        {
        }
    }
}