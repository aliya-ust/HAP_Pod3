using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Shared.DTOs;
using HealthCare.Shared.DTOs.Patient;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthCare.Api.Services.Impl
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;
        private readonly HealthCareDbContext _context;
        private readonly IMapper _mapper;

        private const string NotFoundMessage = "Patient not found.";

        public PatientService(IRepository<Patient> repository, HealthCareDbContext context, IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<PatientListDto> GetByIdAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new InvalidOperationException(NotFoundMessage);

            return _mapper.Map<PatientListDto>(patient);
        }

        

        public async Task AddAsync(CreatePatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            await _repository.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<PatientListDto>> GetAllAsync(PatientFilter filter)
        {

            Expression<Func<Patient, bool>> predicate = p => true;

            if (filter.HasInsurance.HasValue)
            {
                if (filter.HasInsurance.Value)
                {
                    predicate = p =>
                        p.InsuranceId != null &&
                        p.InsuranceId != "";
                }
                else
                {
                    predicate = p =>
                        p.InsuranceId == null ||
                        p.InsuranceId == "";
                }
            }

            if (!string.IsNullOrWhiteSpace(filter.FullName))
            {
                var search = filter.FullName.Trim();

                if (filter.HasInsurance.HasValue)
                {
                    if (filter.HasInsurance.Value)
                    {
                        predicate = p =>
                            p.InsuranceId != null &&
                            p.InsuranceId != "" &&
                            p.FullName != null &&
                            EF.Functions.Like(p.FullName, $"%{search}%");
                    }
                    else
                    {
                        predicate = p =>
                            (p.InsuranceId == null || p.InsuranceId == "") &&
                            p.FullName != null &&
                            EF.Functions.Like(p.FullName, $"%{search}%");
                    }
                }
                else
                {
                    predicate = p =>
                        p.FullName != null &&
                        EF.Functions.Like(p.FullName, $"%{search}%");
                }
            }

            var pagedResult = await _repository.GetAllAsync(
                filter.PageNumber,
                filter.PageSize,
                predicate
            );

            return new PagedResult<PatientListDto>
            {
                Items = _mapper.Map<IEnumerable<PatientListDto>>(pagedResult.Items),
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalCount = pagedResult.TotalCount
            };
        }

        public async Task UpdateAsync(int id, UpdatePatientDto dto)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new InvalidOperationException(NotFoundMessage);

            _mapper.Map(dto, patient); 

            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, bool isActive)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new InvalidOperationException(NotFoundMessage);

            patient.IsActive = isActive;

            await _repository.UpdateAsync(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);

            if (patient is null)
                throw new InvalidOperationException(NotFoundMessage);

            try
            {
                await _repository.DeleteAsync(id);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Failed to delete patient. It may be referenced by existing appointments or health records.", ex);
            }
        }

        public async Task<int> GetRecentPatientCount()
        {
            var fromDate = DateTimeOffset.UtcNow.AddDays(-30);

            return await _context.Patients
                .CountAsync(p => p.CreatedDate >= fromDate);
        }

        public async Task<PatientDashboardDto> GetDashboardAsync(int patientId)
        {
            var upcomingAppointments = await _context.Appointments
                .CountAsync(a =>
                    a.PatientId == patientId &&
                    a.ScheduledDate >= DateOnly.FromDateTime(DateTime.Today) &&
                    a.Status != "Cancelled");

            var latestRecords = await _context.HealthRecords
                .CountAsync(h => h.PatientId == patientId);

            return new PatientDashboardDto
            {
                UpcomingAppointmentsCount = upcomingAppointments,
                LatestRecordsCount = latestRecords
            };
        }

    }
}