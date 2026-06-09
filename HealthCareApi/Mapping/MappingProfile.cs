using AutoMapper;
using HealthCareApi;
using HealthCareApi.DTOs.Appointment;
using HealthCareApi.DTOs.Doctor;
using HealthCareApi.DTOs.HealthRecord;
using HealthCareApi.DTOs.Patient;
using HealthCareApi.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Entity -> DTO
        CreateMap<Doctor, DoctorDto>()
            .ForMember(dest => dest.DoctorId,
                       opt => opt.MapFrom(src => src.DoctorId))
            .ForMember(dest => dest.Specialisation,
                       opt => opt.MapFrom(src => src.Specialisation));

        // DTO -> Entity
        CreateMap<DoctorDto, Doctor>()
            .ForMember(dest => dest.DoctorId,
                       opt => opt.MapFrom(src => src.DoctorId))
            .ForMember(dest => dest.Specialisation,
                       opt => opt.MapFrom(src => src.Specialisation));

        CreateMap<Patient, PatientDto>().ReverseMap();
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<vw_PatientHealthHistory, HealthRecordDto>();
    }
}