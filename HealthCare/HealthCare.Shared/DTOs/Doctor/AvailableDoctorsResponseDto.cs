using HealthCare.Shared.DTOs.Doctor;

public class AvailableDoctorsResponseDto
{
    public List<DoctorListDto> Doctors { get; set; } = new();
    public string Message { get; set; } = string.Empty;
}