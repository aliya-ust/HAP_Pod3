//using HealthCareApi.Models;
using HealthCare.Api;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.Doctor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCareApi.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<PagedResult<Doctor>> GetFilteredDoctorsAsync(
            string specialisation = null,
            string searchTerm = null,
            bool orderByDescending = false,
            int pageNumber = 1,
            int pageSize = 10);

        Task<List<Doctor>> GetDoctorBySpecializationAsync(string specialisation);
        Task<Doctor> AddDoctorAsync(DoctorDto doctorDto);
        Task<Doctor> UpdateDoctorAsync(Doctor updatedDoctor);
        Task<bool> DeleteDoctorAsync(int id);
    }
}