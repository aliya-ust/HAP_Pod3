using AutoMapper;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Api.Exceptions;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Linq.Expressions;
using System.Text.Json;

namespace HealthCare.Api.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IDistributedCache _cache;
        private readonly ILogger<DoctorService> _logger;
        private readonly int _ttlMinutes;
        private static readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

        public DoctorService(IDoctorRepository repository, IAppointmentRepository appointmentRepository, IMapper mapper, UserManager<User> userManager, IDistributedCache cache, ILogger<DoctorService> logger, int ttlMinutes)
        {
            _repository = repository;
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _userManager = userManager;
            _cache = cache;
            _logger = logger;
            _ttlMinutes = ttlMinutes;
        }

        public async Task<DoctorListDto> GetByIdAsync(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
                throw new DoctorNotFoundException(id);

            return _mapper.Map<DoctorListDto>(doctor);
        }

        public async Task<PagedResult<DoctorListDto>> GetAllAsync(DoctorFilter filter)
        {
            var query = _repository.GetQueryable();

            // Search by name
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query.Where(d =>
                    d.FullName.Contains(filter.Search));
            }

            // Filter by specialisation
            if (!string.IsNullOrWhiteSpace(filter.Specialisation))
            {
                query = query.Where(d => d.Specialisation == filter.Specialisation);
            }

            // Filter by active status
            if (filter.IsActive.HasValue)
            {
                query = query.Where(d => d.IsActive == filter.IsActive.Value);
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(filter.SortBy))
            {
                query = filter.SortBy.ToLower() switch
                {
                    "experience" => filter.IsDescending
                        ? query.OrderByDescending(d => d.YearsOfExperience)
                        : query.OrderBy(d => d.YearsOfExperience),

                    "fee" => filter.IsDescending
                        ? query.OrderByDescending(d => d.ConsultationFee)
                        : query.OrderBy(d => d.ConsultationFee),

                    _ => query
                };
            }
            else
            {
                // Default sort
                query = query.OrderByDescending(d => d.YearsOfExperience);
            }

            // Total count
            var totalCount = await query.CountAsync();

            // Pagination
            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            // Map result
            return new PagedResult<DoctorListDto>
            {
                Items = _mapper.Map<IEnumerable<DoctorListDto>>(items),
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalCount = totalCount
            };
        }

        public async Task AddAsync(CreateDoctorDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            await _repository.AddAsync(doctor);

            await _repository.CreateSlots(doctor.DoctorId, dto.TimeSlots);

            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateDoctorDto dto)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
                throw new DoctorNotFoundException(id);

            _mapper.Map(dto, doctor); // maps onto the tracked entity � EF picks up the changes

            await _repository.UpdateAsync(doctor);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, bool isActive)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
                throw new DoctorNotFoundException(id);

            doctor.IsActive = isActive;

            await _repository.UpdateAsync(doctor);
            await _repository.SaveChangesAsync();
            await InvalidateCache(id);
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
                throw new DoctorNotFoundException(id);

            try
            {
                if (doctor.UserId is not null)
                {
                    var user = await _userManager.FindByIdAsync(doctor.UserId);
                    if (user is not null)
                    {
                        var result = await _userManager.DeleteAsync(user);
                        if (!result.Succeeded)
                            throw new IdentityOperationException(
                                string.Join(", ", result.Errors.Select(e => e.Description)));
                        return;
                    }
                }

                await _repository.DeleteAsync(id);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new DbHandleException("Failed to delete Doctor. It may be referenced by existing appointments or health records.");
            }
        }

        public async Task<List<string>> GetSlots(int doctorId)
        {
            var slots = await _repository.GetSlots(doctorId);

            if (slots.Count == 0)
                throw new NoAvailableSlotsException();

            return slots;
        }

        public async Task CreateSlots(int id, List<string> timeslots)
        {
            await _repository.CreateSlots(id, timeslots);
            await _repository.SaveChangesAsync();
            await InvalidateCache(id);
        }

        private async Task<List<string>> AvailableTimeSlotsCheck(DateOnly date, int doctorId)
        {
            var allSlots = await _repository.GetSlots(doctorId);
            var bookedSlots = await _appointmentRepository.BookedTimeSlots(date, doctorId);
            return allSlots.Except(bookedSlots).ToList();
        }

        public async Task<CreateLeaveResultDto> CreateLeave(int id, List<CreateLeaveDto> leaves)
        {
            var result = new CreateLeaveResultDto();
            var existingLeaves = await _repository.GetLeavesByDoctorId(id);
            var existingLeaveDates = existingLeaves.Select(l => l.LeaveDate).ToHashSet();

            var leavesToCreate = new List<CreateLeaveDto>();

            foreach (var leave in leaves)
            {
                if (existingLeaveDates.Contains(leave.LeaveDate))
                {
                    result.SkippedDates.Add(leave.LeaveDate);
                    continue;
                }

                var availableSlots = await AvailableTimeSlotsCheck(leave.LeaveDate, id);
                var allSlots = await GetSlots(id);

                if (availableSlots.Count != allSlots.Count)
                {
                    // Doctor has confirmed/pending appointments that day � cancel them and proceed
                    await _appointmentRepository.CancelAppointmentsByDoctorDate(id, leave.LeaveDate);
                    result.CreatedWithCancelledAppointments.Add(leave.LeaveDate);
                }

                leavesToCreate.Add(leave);
            }

            if (leavesToCreate.Count > 0)
            {
                await _repository.CreateLeaves(id, leavesToCreate);
                await _repository.SaveChangesAsync();
                await InvalidateCache(id);
            }

            return result;
        }

        public async Task<List<DoctorListDto>> AvailableDoctors(string specialisation, DateOnly date)
        {
            try
            {
                var version = await _cache.GetStringAsync($"cache_ver:{specialisation}") ?? "0";
                var cacheKey = $"available_doctors:{specialisation}:{date:yyyy-MM-dd}:v{version}";

                var cached = await _cache.GetStringAsync(cacheKey);
                if (cached is not null)
                {
                    if (_logger.IsEnabled(LogLevel.Information))
                        _logger.LogInformation("Cache hit for {CacheKey}", cacheKey);
                    return JsonSerializer.Deserialize<List<DoctorListDto>>(cached, _jsonOptions) ?? [];
                }

                if (_logger.IsEnabled(LogLevel.Information))
                    _logger.LogInformation("Cache miss for {CacheKey}. Querying database.", cacheKey);
                var result = await _repository.AvailableDoctors(specialisation, date);

                await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(result),
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_ttlMinutes)
                    });

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Cache unavailable, falling through to database");
                return await _repository.AvailableDoctors(specialisation, date);
            }
        }

        private async Task InvalidateCache(int doctorId)
        {
            try
            {
                var doctor = await _repository.GetByIdAsync(doctorId);
                if (doctor is null || doctor.Specialisation is null) return;

                var versionKey = $"cache_ver:{doctor.Specialisation}";
                var current = await _cache.GetStringAsync(versionKey) ?? "0";
                var next = (int.Parse(current) + 1).ToString();
                await _cache.SetStringAsync(versionKey, next);

                if (_logger.IsEnabled(LogLevel.Information))
                    _logger.LogInformation("Invalidated cache for {Specialisation} (v{Version})", doctor.Specialisation, next);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to invalidate cache for doctor {DoctorId}", doctorId);
            }
        }

        public async Task<DoctorSummaryDto> GetSummaryAsync() =>
            await _repository.GetSummaryAsync();
    }
}