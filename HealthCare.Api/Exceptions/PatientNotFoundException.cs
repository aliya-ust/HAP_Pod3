namespace HealthCare.Api.Exceptions
{
    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException()
                    : base("Patient not found.") { }

        public PatientNotFoundException(int id)
                    : base($"Patient with ID {id} not found.") { }
    }
}