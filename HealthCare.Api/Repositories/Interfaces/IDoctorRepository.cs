//using HealthCareApi.Models;
using HealthCare.Api;
using HealthCare.Shared;
using HealthCareApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthCareApi.Repositories.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<PagedResult<Doctor>> GetDoctorsAsync(
            string specialisation = null,
            string searchTerm = null,
            bool orderByDescending = false,
            int pageNumber = 1,
            int pageSize = 10
        );

        Task AddDoctorSlotAsync(List<DoctorAvailableSlot> slots);

        Task<List<Doctor>> DoctorBySpecializationAsync(string specialisation);
        
    }
}