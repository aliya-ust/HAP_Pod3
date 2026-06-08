using HealthAppWeb.Models;
using HealthAppWeb.Models.Helpers;
using HealthAppWeb.Models.ViewModels;
using HealthAppWeb.App_Start;
using HealthAppWeb.Services.Interfaces;
using System;
using System.Linq;

namespace HealthAppWeb.Services.Implementations
{
    public class PatientService : IPatientService
    {
        public PagedResult<PatientListViewModel> GetPaged(int page, int pageSize)
        {
            var all = InMemoryStore.Patients;

            var items = all
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PatientListViewModel
                {
                    PatientId = p.PatientId,
                    FullName = p.FullName,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                    CreatedDate = p.CreatedDate
                })
                .ToList();

            return new PagedResult<PatientListViewModel>
            {
                Items = items,
                TotalCount = all.Count,
                PageNumber = page,
                PageSize = pageSize
            };
        }

        public PatientProfileViewModel GetProfileById(int patientId)
        {
            var p = InMemoryStore.Patients.Find(x => x.PatientId == patientId);
            return p == null ? null : MapToProfile(p);
        }

        public PatientProfileViewModel GetProfileByUserId(int userId)
        {
            var p = InMemoryStore.Patients.Find(x => x.UserId == userId);
            return p == null ? null : MapToProfile(p);
        }

        public PatientEditViewModel GetEditViewModel(int patientId)
        {
            var p = InMemoryStore.Patients.Find(x => x.PatientId == patientId);
            return p == null ? null : MapToEdit(p);
        }

        public PatientEditViewModel GetEditViewModelByUserId(int userId)
        {
            var p = InMemoryStore.Patients.Find(x => x.UserId == userId);
            return p == null ? null : MapToEdit(p);
        }

        public ServiceResult Register(PatientRegisterViewModel vm)
        {
            bool emailTaken = InMemoryStore.Patients.Exists(p => p.Email == vm.Email)
                           || InMemoryStore.Users.Exists(u => u.Email == vm.Email);
            if (emailTaken)
                return ServiceResult.Fail("Email", "This email is already registered.");

            var user = new User
            {
                UserId = InMemoryStore.NextUserId++,
                Email = vm.Email,
                PasswordHash = vm.Password,
                Role = "Patient",
                FullName = vm.FullName
            };
            InMemoryStore.Users.Add(user);

            var patient = new Patient
            {
                PatientId = InMemoryStore.NextPatientId++,
                UserId = user.UserId,
                FullName = vm.FullName,
                DateOfBirth = vm.DateOfBirth,
                Gender = vm.Gender,
                PhoneNumber = vm.PhoneNumber,
                Email = vm.Email,
                InsuranceId = vm.InsuranceId,
                CreatedDate = DateTime.Now
            };
            InMemoryStore.Patients.Add(patient);

            return ServiceResult.Ok();
        }

        public ServiceResult Edit(PatientEditViewModel vm, int currentUserId, bool isAdmin)
        {
            var patient = InMemoryStore.Patients.Find(p => p.PatientId == vm.PatientId);
            if (patient == null)
                return ServiceResult.Fail("", "Patient not found.");

            if (!isAdmin && patient.UserId != currentUserId)
                return ServiceResult.Fail("", "Unauthorized.");

            bool emailTaken = InMemoryStore.Patients.Exists(
                p => p.Email == vm.Email && p.PatientId != vm.PatientId
            );
            if (emailTaken)
                return ServiceResult.Fail("Email", "This email is already used by another patient.");

            patient.FullName = vm.FullName;
            patient.DateOfBirth = vm.DateOfBirth;
            patient.Gender = vm.Gender;
            patient.PhoneNumber = vm.PhoneNumber;
            patient.Email = vm.Email;
            patient.InsuranceId = vm.InsuranceId;

            var user = InMemoryStore.Users.Find(u => u.UserId == patient.UserId);
            if (user != null)
                user.Email = vm.Email;

            return ServiceResult.Ok();
        }

        public ServiceResult Delete(int patientId)
        {
            var patient = InMemoryStore.Patients.Find(p => p.PatientId == patientId);
            if (patient == null)
                return ServiceResult.Fail("", "Patient not found.");

            var user = InMemoryStore.Users.Find(u => u.UserId == patient.UserId);
            if (user != null)
                InMemoryStore.Users.Remove(user);

            InMemoryStore.Patients.Remove(patient);
            return ServiceResult.Ok();
        }

        private PatientProfileViewModel MapToProfile(Patient p)
        {
            return new PatientProfileViewModel
            {
                PatientId = p.PatientId,
                FullName = p.FullName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                InsuranceId = p.InsuranceId
            };
        }

        private PatientEditViewModel MapToEdit(Patient p)
        {
            return new PatientEditViewModel
            {
                PatientId = p.PatientId,
                FullName = p.FullName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                InsuranceId = p.InsuranceId
            };
        }
    }
}