using HealthCare.Api.Models;
using HealthCare.Api.DTOs.Doctor;
using AutoMapper;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.DTOs.HealthRecord;

namespace HealthCare.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Patient DTO mappings
            CreateMap<CreatePatientDto, Doctor>();
            CreateMap<UpdatePatientDto, Doctor>();
            CreateMap<PatientListDto, Doctor>();

            // Doctor DTO mappings
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<UpdateDoctorDto, Doctor>();
            CreateMap<DoctorListDto, Doctor>();

            // Appointment DTO mappings
            CreateMap<CreateAppointmentDto, Doctor>();
            CreateMap<UpdateAppointmentDto, Doctor>();
            CreateMap<AppointmentListDto, Doctor>();

            // Health Record DTO mappings
            CreateMap<CreateHealthRecordDto, Doctor>();
            CreateMap<UpdateHealthRecordDto, Doctor>();
            CreateMap<HealthRecordListDto, Doctor>();
        }
    }
}
