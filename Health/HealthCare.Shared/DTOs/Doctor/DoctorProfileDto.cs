namespace HealthCare.Api.DTOs.Doctor
{
    public class DoctorProfileDto
    {
        public int DoctorId { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Specialisation { get; set; } = null!;

        public int YearsOfExperience { get; set; }

        public decimal ConsultationFee { get; set; }
    }
}