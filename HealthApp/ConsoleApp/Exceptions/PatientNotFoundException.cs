namespace HealthApp.ConsoleApp.Exceptions
{
    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException()
            : base($"Patient with ID not found.")
        {}
    }
}