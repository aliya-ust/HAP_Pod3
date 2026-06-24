using AutoMapper;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HealthCare.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Patient DTO mappings
            CreateMap<CreatePatientDto, Patient>();
            CreateMap<UpdatePatientDto, Patient>();
            CreateMap<Patient, PatientListDto>()
               .ForMember(
                   dest => dest.HasInsurance,
                   opt => opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.InsuranceId))
                   )
                .ForMember(dest => dest.IsActive,
                     opt => opt.MapFrom(src => src.IsActive));

            // Doctor DTO mappings
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<UpdateDoctorDto, Doctor>();
            CreateMap<Doctor, DoctorListDto>();

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
