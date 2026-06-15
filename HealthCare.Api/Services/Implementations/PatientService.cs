using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;

namespace HealthCare.Api.Services.Implementation
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;
        private readonly HealthCareDbContext _context;

        public PatientService(IRepository<Patient> repository, HealthCareDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<Patient?> GetByIdAsync(int id) =>
            await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Patient>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task AddAsync(Patient patient)
        {
            await _repository.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Patient patient)
        {
            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _context.SaveChangesAsync();
        }
    }
}