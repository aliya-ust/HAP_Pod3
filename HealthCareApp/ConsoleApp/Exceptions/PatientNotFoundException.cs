namespace HealthApp.ConsoleApp.Exceptions

{

    public class PatientNotFoundException : Exception
    {

        public PatientNotFoundException(int patientId)

            : base($"Patient with ID {patientId} not found.")

        { }

    }

}