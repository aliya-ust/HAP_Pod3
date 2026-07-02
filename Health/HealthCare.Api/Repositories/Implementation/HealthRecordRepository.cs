using HealthCare.Api.Data;
using HealthCare.Api.DTOs.HealthRecord;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Implementation;
using HealthCare.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Repositories.Implementations
{
    public class HealthRecordRepository : Repository<HealthRecord>, IHealthRecordRepository
    {
        public HealthRecordRepository(HealthCareDbContext context) : base(context) { }

        public async Task<List<HealthRecordListDto>> GetPatientHealthRecords(int patientId)
        {
            return await _dbSet
                .Where(x => x.PatientId == patientId)
                .OrderByDescending(x => x.VisitDate)
                .Select(x => new HealthRecordListDto
                {
                    Diagnosis = x.Diagnosis,
                    Prescription = x.Prescription,
                    Notes = x.Notes,
                    VisitDate = x.VisitDate
                })
                .ToListAsync();
        }

        public async Task<List<HealthRecordListDto>> GetHealthRecordByAppointment(int id) =>
            await _dbSet
                .Where(hr => hr.AppointmentId == id)
                .Select(hr => new HealthRecordListDto
                {
                    RecordId = hr.RecordId,
                    PatientName = hr.Patient.FullName,
                    DoctorName = hr.Doctor.FullName,
                    VisitDate = hr.VisitDate,
                    Diagnosis = hr.Diagnosis,
                    Prescription = hr.Prescription,
                    Notes = hr.Notes
                })
                .ToListAsync();
    }
}