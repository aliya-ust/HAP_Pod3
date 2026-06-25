using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
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
        private const string NotFoundExceptionMessage = "Doctor not found.";

        public DoctorService(IDoctorRepository repository, IAppointmentRepository appointmentRepository, HealthCareDbContext context, IMapper mapper)
        {
            _repository = repository;
            _appointmentRepository = appointmentRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<DoctorListDto> GetByIdAsync(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
                return null;

            return _mapper.Map<DoctorListDto>(doctor);
        }

        public async Task<PagedResult<DoctorListDto>> GetAllAsync(DoctorFilter filter)
        {
            Expression<Func<Doctor, bool>> predicate = d =>
                    (string.IsNullOrEmpty(filter.Name) ||
                        (d.FullName != null &&
                         EF.Functions.Like(d.FullName, $"%{filter.Name}%"))) &&

                    (string.IsNullOrEmpty(filter.Specialisation) ||
                        d.Specialisation == filter.Specialisation) &&

                    (!filter.IsActive.HasValue ||
                        d.IsActive == filter.IsActive.Value);
            // ✅ ORDERING
            Func<IQueryable<Doctor>, IOrderedQueryable<Doctor>> orderBy = q =>
            {
                // ✅ If user selected experience sorting
                if (!string.IsNullOrEmpty(filter.ExperienceOrder))
                {
                    if (filter.ExperienceOrder == "asc")
                        return q.OrderBy(d => d.YearsOfExperience);

                    return q.OrderByDescending(d => d.YearsOfExperience);
                }

                // ✅ DEFAULT SORT (by ID)
                return q.OrderBy(d => d.DoctorId);
            };

            var pagedResult = await _repository.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                predicate,
                orderBy
            );

            return new PagedResult<DoctorListDto>
            {
                Items = _mapper.Map<IEnumerable<DoctorListDto>>(pagedResult.Items),
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalCount = pagedResult.TotalCount
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
                throw new InvalidOperationException(NotFoundExceptionMessage);

            _mapper.Map(dto, doctor); // maps onto the tracked entity — EF picks up the changes

            await _repository.UpdateAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, bool isActive)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
                throw new InvalidOperationException(NotFoundExceptionMessage);

            doctor.IsActive = isActive;

            await _repository.UpdateAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);

            if (doctor is null)
                throw new InvalidOperationException(NotFoundExceptionMessage);

            try
            {
                await _repository.DeleteAsync(id);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to delete Doctor. It may be referenced by existing appointments or health records.", ex);
            }
        }

        public async Task<List<string>> GetSlots(int doctorId)
        {
            var slots = await _repository.GetSlots(doctorId);

            if (slots.Count == 0)
                throw new InvalidOperationException("No available slots found for this doctor.");

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
                    // Doctor has confirmed/pending appointments that day — cancel them and proceed
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
    

    public async Task<DoctorSummaryDto> GetSummaryAsync()
        {
            var fromDate = DateTimeOffset.UtcNow.AddDays(-30);
            var toDate = DateTimeOffset.UtcNow;

            var result = await _context.Doctors
                .Where(d => d.CreatedDate >= fromDate && d.CreatedDate <= toDate)
                .GroupBy(d => 1)
                .Select(g => new DoctorSummaryDto
                {
                    TotalDoctors = g.Count(),
                    ActiveDoctors = g.Count(d => d.IsActive),
                    InactiveDoctors = g.Count(d => !d.IsActive)
                })
                .FirstOrDefaultAsync();

            return result ?? new DoctorSummaryDto();
        }
    }
}