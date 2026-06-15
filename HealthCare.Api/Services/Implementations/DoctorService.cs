using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;

namespace HealthApp.Infrastructure.Services;

public class DoctorService : IDoctorService
{
    private readonly IRepository<Doctor> _repository;
    private readonly HealthCareDbContext _context;

    public DoctorService(IRepository<Doctor> repository, HealthCareDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<Doctor?> GetByIdAsync(int id) =>
        await _repository.GetByIdAsync(id);

    public async Task<IEnumerable<Doctor>> GetAllAsync() =>
        await _repository.GetAllAsync();

    public async Task AddAsync(Doctor doctor)
    {
        await _repository.AddAsync(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Doctor doctor)
    {
        await _repository.UpdateAsync(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _context.SaveChangesAsync();
    }
}