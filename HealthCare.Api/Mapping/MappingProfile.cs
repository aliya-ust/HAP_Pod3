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
            CreateMap<Patient, PatientListDto>()
                .ForMember(d => d.Email, o => o.MapFrom(s => s.User!.Email ?? string.Empty));

            // Doctor DTO mappings
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<UpdateDoctorDto, Doctor>();
            CreateMap<Doctor, DoctorListDto>();

            // Appointment DTO mappings
            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<UpdateAppointmentDto, Appointment>();
            CreateMap<Appointment, AppointmentListDto>();

            // Health Record DTO mappings
            CreateMap<CreateHealthRecordDto, HealthRecord>();
            CreateMap<UpdateHealthRecordDto, HealthRecord>();

        }
    }
}
