using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<DoctorProfileDto> GetByIdAsync(int id);
        Task<PagedResult<DoctorListDto>> GetAllAsync(DoctorFilter filter);
        Task AddAsync(CreateDoctorDto dto);
        Task UpdateAsync(int id, UpdateDoctorDto dto);
        Task UpdateStatusAsync(int id, bool isActive);
        Task DeleteAsync(int id);
        Task<List<string>> GetSlots(int doctorId);
        Task<CreateLeaveResultDto> CreateLeave(int id, List<CreateLeaveDto> leaves);
        Task<List<DoctorListDto>> AvailableDoctors(string specialisation, DateOnly date);
    }
}