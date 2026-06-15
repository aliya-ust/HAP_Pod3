using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;

namespace HealthApp.Infrastructure.Services
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IRepository<HealthRecord> _repository;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;

        public HealthRecordService(IRepository<HealthRecord> repository, HealthCareDbContext context, IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<HealthRecordListDto?> GetByIdAsync(int id)
        {
            var record = await _repository.GetByIdAsync(id);
            return record is null ? null : _mapper.Map<HealthRecordListDto>(record);
        }

        public async Task<IEnumerable<HealthRecordListDto>> GetAllAsync()
        {
            var records = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<HealthRecordListDto>>(records);
        }

        public async Task AddAsync(CreateHealthRecordDto dto)
        {
            var record = _mapper.Map<HealthRecord>(dto);
            await _repository.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateHealthRecordDto dto)
        {
            var record = await _repository.GetByIdAsync(id);
            if (record is null) return;
            _mapper.Map(dto, record);
            await _repository.UpdateAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _context.SaveChangesAsync();
        }
    }
}