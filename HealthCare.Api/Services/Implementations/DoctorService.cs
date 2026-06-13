using HealthCare.Api;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.Doctor;
using HealthCareApi.Repositories.Interfaces;
using HealthCareApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareApi.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetByIdAsync(id);
        }

        public async Task<PagedResult<Doctor>> GetFilteredDoctorsAsync(
            string specialisation = null,
            string searchTerm = null,
            bool orderByDescending = true,
            int pageNumber = 1,
            int pageSize = 10)
        {
            return await _doctorRepository.GetDoctorsAsync(
                specialisation,
                searchTerm,
                orderByDescending,
                pageNumber,
                pageSize);
        }

        public async Task<Doctor> AddDoctorAsync(DoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                FullName = doctorDto.FullName,
                Specialisation = doctorDto.Specialisation,
                YearsOfExperience = doctorDto.YearsOfExperience,
                ConsultationFee = doctorDto.ConsultationFee,
                IsActive = true
            };

            // Save doctor first
            await _doctorRepository.AddAsync(doctor);

            // Now doctor.DoctorId is available

            if (doctorDto.DoctorAvailableSlots != null && doctorDto.DoctorAvailableSlots.Any())
            {
                var slots = doctorDto.DoctorAvailableSlots.Select(slot => new DoctorAvailableSlot
                {
                    DoctorId = doctor.DoctorId,
                    TimeSlot = slot
                }).ToList();

                await _doctorRepository.AddDoctorSlotAsync(slots);
            }

            return doctor;
        }

        public async Task<List<Doctor>> GetDoctorBySpecializationAsync(string specialisation)
        {
            return await _doctorRepository.DoctorBySpecializationAsync(specialisation);
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor updatedDoctor)
        {
            // Get existing data via repo
            var existingDoctor = await _doctorRepository.GetByIdAsync(updatedDoctor.DoctorId);

            if (existingDoctor == null)
                return null;

            // Update only allowed fields
            existingDoctor.FullName = updatedDoctor.FullName;
            existingDoctor.Specialisation = updatedDoctor.Specialisation;
            existingDoctor.YearsOfExperience = updatedDoctor.YearsOfExperience;
            existingDoctor.ConsultationFee = updatedDoctor.ConsultationFee;

            // Call repo to save
            await _doctorRepository.UpdateAsync(existingDoctor);

            return existingDoctor;
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null)
                return false;

            await _doctorRepository.DeleteAsync(doctor);

            return true;
        }
    }
}