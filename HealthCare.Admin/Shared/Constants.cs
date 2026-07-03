namespace HealthCare.Admin.Shared
{
    public static class DoctorConstants
    {
        public static readonly IReadOnlyList<string> Specialisations = new List<string>
        {
            "Cardiology",
            "Dentist",
            "Dermatology",
            "Neurology",
            "Orthopedics",
            "Pediatrics",
            "Psychiatry",
            "Radiology",
            "General Medicine"
        }.AsReadOnly();
    }
}
