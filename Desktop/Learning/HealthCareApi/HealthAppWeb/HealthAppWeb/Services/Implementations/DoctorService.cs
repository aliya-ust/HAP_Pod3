using HealthAppWeb.App_Start;
using HealthAppWeb.Models;
using HealthAppWeb.Models.Helpers;
using HealthAppWeb.Models.ViewModels;
using HealthAppWeb.Services.Interfaces;
using HealthAppWeb.Services;
using System;
using System.Linq;

namespace HealthAppWeb.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        public PagedResult<DoctorListViewModel> GetPaged(int page, int pageSize)
        {
            var all = InMemoryStore.Doctors;

            var items = all
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(d => new DoctorListViewModel
                {
                    DoctorId = d.DoctorId,
                    FullName = d.FullName,
                    Specialisation = d.Specialisation,
                    YearsOfExperience = d.YearsOfExperience,
                    ConsultationFee = d.ConsultationFee,
                    IsActive = d.IsActive
                })
                .ToList();

            return new PagedResult<DoctorListViewModel>
            {
                Items = items,
                TotalCount = all.Count,
                PageNumber = page,
                PageSize = pageSize
            };
        }

        public DoctorProfileViewModel GetProfileById(int doctorId)
        {
            var d = InMemoryStore.Doctors.Find(x => x.DoctorId == doctorId);
            return d == null ? null : MapToProfile(d);
        }

        public DoctorProfileViewModel GetProfileByUserId(int userId)
        {
            var d = InMemoryStore.Doctors.Find(x => x.UserId == userId);
            return d == null ? null : MapToProfile(d);
        }

        public DoctorEditViewModel GetEditViewModel(int doctorId)
        {
            var d = InMemoryStore.Doctors.Find(x => x.DoctorId == doctorId);
            return d == null ? null : MapToEdit(d);
        }

        public DoctorEditViewModel GetEditViewModelByUserId(int userId)
        {
            var d = InMemoryStore.Doctors.Find(x => x.UserId == userId);
            return d == null ? null : MapToEdit(d);
        }

        public ServiceResult Register(DoctorRegisterViewModel vm)
        {
            bool emailTaken = InMemoryStore.Users.Exists(u => u.Email == vm.Email);
            if (emailTaken)
                return ServiceResult.Fail("Email", "This email is already registered.");

            var user = new User
            {
                UserId = InMemoryStore.NextUserId++,
                Email = vm.Email,
                PasswordHash = vm.Password,
                Role = "Doctor",
                FullName = vm.FullName
            };
            InMemoryStore.Users.Add(user);

            var doctor = new Doctor
            {
                DoctorId = InMemoryStore.NextDoctorId++,
                UserId = user.UserId,
                FullName = vm.FullName,
                Specialisation = vm.Specialisation,
                YearsOfExperience = vm.YearsOfExperience,
                ConsultationFee = vm.ConsultationFee,
                IsActive = true,
                CreatedDate = DateTime.Now
            };
            InMemoryStore.Doctors.Add(doctor);

            return ServiceResult.Ok();
        }

        public ServiceResult Edit(DoctorEditViewModel vm, int currentUserId, bool isAdmin)
        {
            var doctor = InMemoryStore.Doctors.Find(d => d.DoctorId == vm.DoctorId);
            if (doctor == null)
                return ServiceResult.Fail("", "Doctor not found.");

            if (!isAdmin && doctor.UserId != currentUserId)
                return ServiceResult.Fail("", "Unauthorized.");

            doctor.FullName = vm.FullName;
            doctor.Specialisation = vm.Specialisation;
            doctor.YearsOfExperience = vm.YearsOfExperience;
            doctor.ConsultationFee = vm.ConsultationFee;
            doctor.IsActive = vm.IsActive;

            var user = InMemoryStore.Users.Find(u => u.UserId == doctor.UserId);
            if (user != null)
                user.FullName = vm.FullName;

            return ServiceResult.Ok();
        }

        public ServiceResult Delete(int doctorId)
        {
            var doctor = InMemoryStore.Doctors.Find(d => d.DoctorId == doctorId);
            if (doctor == null)
                return ServiceResult.Fail("", "Doctor not found.");

            var user = InMemoryStore.Users.Find(u => u.UserId == doctor.UserId);
            if (user != null)
                InMemoryStore.Users.Remove(user);

            InMemoryStore.Doctors.Remove(doctor);
            return ServiceResult.Ok();
        }

        private DoctorProfileViewModel MapToProfile(Doctor d)
        {
            return new DoctorProfileViewModel
            {
                DoctorId = d.DoctorId,
                FullName = d.FullName,
                Specialisation = d.Specialisation,
                YearsOfExperience = d.YearsOfExperience,
                ConsultationFee = d.ConsultationFee,
                IsActive = d.IsActive
            };
        }

        private DoctorEditViewModel MapToEdit(Doctor d)
        {
            return new DoctorEditViewModel
            {
                DoctorId = d.DoctorId,
                FullName = d.FullName,
                Specialisation = d.Specialisation,
                YearsOfExperience = d.YearsOfExperience,
                ConsultationFee = d.ConsultationFee,
                IsActive = d.IsActive
            };
        }
    }
}