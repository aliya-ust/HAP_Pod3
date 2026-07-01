using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Api.Exceptions;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthCare.Api.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public DoctorService(IDoctorRepository repository, IAppointmentRepository appointmentRepository, HealthCareDbContext context, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _appointmentRepository = appointmentRepository;
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
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

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateDoctorDto dto)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
                throw new DoctorNotFoundException(id);

            _mapper.Map(dto, doctor); // maps onto the tracked entity � EF picks up the changes

            await _repository.UpdateAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, bool isActive)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
                throw new DoctorNotFoundException(id);

            doctor.IsActive = isActive;

            await _repository.UpdateAsync(doctor);
            await _context.SaveChangesAsync();
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
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
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
            await _context.SaveChangesAsync();
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
                await _context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<List<DoctorListDto>> AvailableDoctors(string specialisation, DateOnly date) =>
            await _repository.AvailableDoctors(specialisation, date);

        public async Task<DoctorSummaryDto> GetSummaryAsync() =>
            await _repository.GetSummaryAsync();
    }
}