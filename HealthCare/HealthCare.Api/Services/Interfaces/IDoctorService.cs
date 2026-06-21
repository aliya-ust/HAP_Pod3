using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Models;

namespace HealthCare.Api.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<DoctorListDto> GetByIdAsync(int id);
        Task<PagedResult<DoctorListDto>> GetAllAsync(DoctorFilter filter);
        Task AddAsync(CreateDoctorDto dto);
        Task UpdateAsync(int id, UpdateDoctorDto dto);
        Task DeleteAsync(int id);
        Task<List<string>> GetSlots(int doctorId);
        Task UpdateStatusAsync(int id, bool isActive);
        Task CreateSlots(int id, List<string> timeslots);
        Task<CreateLeaveResultDto> CreateLeave(int id, List<CreateLeaveDto> leaves);
        Task<List<DoctorListDto>> AvailableDoctors(string specialisation, DateOnly date);
    }
} 