using HealthCare.Api.Models;
using HealthCare.Api.DTOs.Doctor;
using AutoMapper;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Shared.DTOs.Appointment;

namespace HealthCare.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Patient DTO mappings
            CreateMap<CreatePatientDto, Patient>();
            CreateMap<UpdatePatientDto, Patient>();
            CreateMap<Patient, PatientListDto>()
    .ForMember(dest => dest.HasInsurance,
        opt => opt.MapFrom(src => src.InsuranceId != null)); 




            // Doctor DTO mappings
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<UpdateDoctorDto, Doctor>();
            CreateMap<Doctor, DoctorListDto>();

            // Appointment DTO mappings
            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<UpdateAppointmentDto, Appointment>();
            CreateMap<AppointmentListDto, Appointment>();
            CreateMap<Appointment, AppointmentListDto>()
                  .ForMember(dest => dest.PatientId,
                             opt => opt.MapFrom(src => src.PatientId));

            // Health Record DTO mappings
            CreateMap<CreateHealthRecordDto, HealthRecord>();
            CreateMap<UpdateHealthRecordDto, HealthRecord>();
            CreateMap<HealthRecordListDto, HealthRecord>();
            CreateMap<HealthRecord, HealthRecordListDto>();
        }
    }
}