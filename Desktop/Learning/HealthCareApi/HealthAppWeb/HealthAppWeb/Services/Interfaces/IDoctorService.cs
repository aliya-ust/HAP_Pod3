using HealthAppWeb.Models.Helpers;
using HealthAppWeb.Models.ViewModels;
using HealthAppWeb.Services;

namespace HealthAppWeb.Services.Interfaces
{
    public interface IDoctorService
    {
        PagedResult<DoctorListViewModel> GetPaged(int page, int pageSize);
        DoctorProfileViewModel GetProfileById(int doctorId);
        DoctorProfileViewModel GetProfileByUserId(int userId);
        DoctorEditViewModel GetEditViewModel(int doctorId);
        DoctorEditViewModel GetEditViewModelByUserId(int userId);
        ServiceResult Register(DoctorRegisterViewModel vm);
        ServiceResult Edit(DoctorEditViewModel vm, int currentUserId, bool isAdmin);
        ServiceResult Delete(int doctorId);
    }
}