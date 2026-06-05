using AutoMapper;
//using HealthCareAPI.Domain.Entities;
using HealthCareApi.DTOs.Appointment;
using HealthCareApi.DTOs.Doctor;
using HealthCareApi.DTOs.Patient;
using HealthCareApi.Models;
using System;

namespace HealthCareApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Doctor
            CreateMap<Doctor, DoctorDto>();
            CreateMap<CreateDoctorDto, Doctor>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<UpdateDoctorDto, Doctor>();

            // Patient
            CreateMap<Patient, PatientDto>();
            CreateMap<CreatePatientDto, Patient>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            // Appointment
            //CreateMap<Appointment, AppointmentDto>()
            //    .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
            //    .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName));
            //CreateMap<CreateAppointmentDto, Appointment>()
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Pending"))
            //    .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}