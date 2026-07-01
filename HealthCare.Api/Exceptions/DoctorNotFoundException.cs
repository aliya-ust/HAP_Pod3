namespace HealthCare.Api.Exceptions
{
    public class DoctorNotFoundException : Exception
    {
        public DoctorNotFoundException()
                    : base("Doctor not found.") { }

        public DoctorNotFoundException(int id)
                    : base($"Doctor with ID {id} not found") { }
    }
}