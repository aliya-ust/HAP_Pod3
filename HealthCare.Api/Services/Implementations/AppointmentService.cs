using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;

namespace HealthApp.Infrastructure.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IRepository<Appointment> _repository;
    private readonly HealthCareDbContext _context;

    public AppointmentService(IRepository<Appointment> repository, HealthCareDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<Appointment?> GetByIdAsync(int id) =>
        await _repository.GetByIdAsync(id);

    public async Task<IEnumerable<Appointment>> GetAllAsync() =>
        await _repository.GetAllAsync();

    public async Task AddAsync(Appointment appointment)
    {
        await _repository.AddAsync(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Appointment appointment)
    {
        await _repository.UpdateAsync(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await _context.SaveChangesAsync();
    }
}