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
            CreateMap<CreatePatientDto, Patient>();
            CreateMap<UpdatePatientDto, Patient>();
            CreateMap<PatientListDto, Patient>();

            // Doctor DTO mappings
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<UpdateDoctorDto, Doctor>();
            CreateMap<DoctorListDto, Doctor>();

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