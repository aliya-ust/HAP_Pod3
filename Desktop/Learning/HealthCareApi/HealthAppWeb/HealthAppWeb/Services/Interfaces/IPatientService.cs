using HealthAppWeb.Models.Helpers;
using HealthAppWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthAppWeb.Services.Interfaces
{
    public interface IPatientService
    {
        PagedResult<PatientListViewModel> GetPaged(int page, int pageSize);
        PatientProfileViewModel GetProfileById(int patientId);
        PatientProfileViewModel GetProfileByUserId(int userId);
        PatientEditViewModel GetEditViewModel(int patientId);
        PatientEditViewModel GetEditViewModelByUserId(int userId);
        ServiceResult Register(PatientRegisterViewModel vm);
        ServiceResult Edit(PatientEditViewModel vm, int currentUserId, bool isAdmin);
        ServiceResult Delete(int patientId);
    }
}