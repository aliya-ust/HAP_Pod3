using HealthCare.Shared.DTOs.Doctor;

namespace HealthCare.Shared.DTOs.Response
{
    public class AvailableDoctorsResponseDto
    {
        public List<DoctorListDto> Doctors { get; set; } = new();
        public string Message { get; set; } = string.Empty;
    }
}