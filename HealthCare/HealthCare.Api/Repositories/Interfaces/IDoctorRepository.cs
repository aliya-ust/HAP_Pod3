using HealthCare.Api.DTOs.Doctor;
using HealthCare.Api.Models;
using HealthCare.Shared.DTOs.Doctor;

namespace HealthCare.Api.Repositories.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IQueryable<Doctor> GetQueryable();
        Task<Doctor?> GetByUserIdAsync(string userId);
        Task<List<string>> GetSlots(int doctorId);
        Task CreateSlots(int doctorId, List<string> timeslots);
        Task<List<DoctorLeaves>> GetLeavesByDoctorId(int doctorId);
        Task CreateLeaves(int doctorId, List<CreateLeaveDto> leaves);
        Task<List<DoctorListDto>> AvailableDoctors(string specialisation, DateOnly date);
        Task<DoctorSummaryDto> GetSummaryAsync();
    }
}