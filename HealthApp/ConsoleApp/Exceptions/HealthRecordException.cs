using System;

namespace HealthApp.ConsoleApp.Exceptions
{
    public class HealthRecordExistsException : Exception
    {
        public HealthRecordExistsException(string message) : base(message)
        {
        }
    }

    public class HealthRecordNotFoundException : Exception
    {
        public HealthRecordNotFoundException(string message) : base(message)
        {
        }
    }
}