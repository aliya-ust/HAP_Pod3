using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;

namespace HealthApp.Infrastructure.Services;

public class HealthRecordService : IHealthRecordService
{
    private readonly IRepository<HealthRecord> _repository;
    private readonly HealthCareDbContext _context;

    public HealthRecordService(IRepository<HealthRecord> repository, HealthCareDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<HealthRecord?> GetByIdAsync(int id) =>
        await _repository.GetByIdAsync(id);

    public async Task<IEnumerable<HealthRecord>> GetAllAsync() =>
        await _repository.GetAllAsync();

    public async Task AddAsync(HealthRecord healthRecord)
    {
        await _repository.AddAsync(healthRecord);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(HealthRecord healthRecord)
    {
        await _repository.UpdateAsync(healthRecord);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _context.SaveChangesAsync();
    }
}