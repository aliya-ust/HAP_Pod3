using HealthCare.Api.Models;
using HealthCare.Shared.DTOs.Doctor;
using AutoMapper;
using HealthCare.Shared.DTOs.Patient;
using HealthCare.Shared.DTOs.Appointment;
using HealthCare.Shared.DTOs.HealthRecord;

namespace HealthCare.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Patient DTO mappings
            CreateMap<CreatePatientDto, Patient>();
            CreateMap<UpdatePatientDto, Patient>();
            CreateMap<Patient, PatientListDto>();

            // Doctor DTO mappings
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<UpdateDoctorDto, Doctor>()
                .ForMember(dest => dest.Specialisation,
                opt => opt.MapFrom(src => src.Specialisation.ToString()));
            CreateMap<Doctor, DoctorListDto>()
     .ForMember(dest => dest.DoctorId,
         opt => opt.MapFrom(src => src.DoctorId)) 

    .ForMember(dest => dest.Email,
        opt => opt.MapFrom(src => src.User.Email)); 

            // Appointment DTO mappings
            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<UpdateAppointmentDto, Appointment>();
            CreateMap<AppointmentListDto, Appointment>();

            // Health Record DTO mappings
            CreateMap<CreateHealthRecordDto, HealthRecord>();
            CreateMap<UpdateHealthRecordDto, HealthRecord>();
            CreateMap<HealthRecordListDto, HealthRecord>();
        }
    }
}