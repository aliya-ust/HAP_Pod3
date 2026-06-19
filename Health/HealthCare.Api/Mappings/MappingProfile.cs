using AutoMapper;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HealthCare.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Patient, PatientListDto>().ReverseMap();

            CreateMap<CreatePatientDto, Patient>();

            CreateMap<CreateDoctorDto, Doctor>();
        }
    }
}
