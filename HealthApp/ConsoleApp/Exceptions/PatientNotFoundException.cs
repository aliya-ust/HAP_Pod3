namespace HealthApp.ConsoleApp.Exceptions
{
    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException(int Id)
            : base($"Patient with ID {Id} not found.")
        {}
    }
}