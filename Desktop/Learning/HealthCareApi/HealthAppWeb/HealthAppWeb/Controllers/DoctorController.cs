using HealthAppWeb.Models.ViewModels;
using HealthAppWeb.Services.Implementations;
using HealthAppWeb.Services.Interfaces;
using System.Web.Mvc;
using System.Web.Security;

namespace HealthAppWeb.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;
        private const int PageSize = 10;

        public DoctorController()
        {
            _service = new DoctorService();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult List(int page = 1)
        {
            var vm = _service.GetPaged(page, PageSize);
            return View(vm);
        }

        public ActionResult Profile(int id = 0)
        {
            DoctorProfileViewModel vm;

            if (User.IsInRole("Doctor"))
                vm = _service.GetProfileByUserId(GetCurrentUserId());
            else if (User.IsInRole("Admin") && id != 0)
                vm = _service.GetProfileById(id);
            else
                return new HttpUnauthorizedResult();

            if (vm == null)
                return HttpNotFound();

            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            return View(new DoctorRegisterViewModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(DoctorRegisterViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var result = _service.Register(vm);
            if (!result.Success)
            {
                ModelState.AddModelError(result.ErrorField, result.ErrorMessage);
                return View(vm);
            }

            TempData["Success"] = "Doctor registered successfully.";
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id = 0)
        {
            DoctorEditViewModel vm;

            if (User.IsInRole("Doctor"))
                vm = _service.GetEditViewModelByUserId(GetCurrentUserId());
            else if (User.IsInRole("Admin") && id != 0)
                vm = _service.GetEditViewModel(id);
            else
                return new HttpUnauthorizedResult();

            if (vm == null)
                return HttpNotFound();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoctorEditViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var result = _service.Edit(vm, GetCurrentUserId(), User.IsInRole("Admin"));
            if (!result.Success)
            {
                if (result.ErrorMessage == "Unauthorized.")
                    return new HttpUnauthorizedResult();

                ModelState.AddModelError(result.ErrorField, result.ErrorMessage);
                return View(vm);
            }

            TempData["Success"] = "Profile updated successfully.";

            if (User.IsInRole("Admin"))
                return RedirectToAction("Profile", new { id = vm.DoctorId });

            return RedirectToAction("List");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            TempData["Success"] = "Doctor deleted.";
            return RedirectToAction("Index");
        }

        private int GetCurrentUserId()
        {
            var identity = (System.Web.Security.FormsIdentity)User.Identity;
            var parts = identity.Ticket.UserData.Split('|');
            return int.Parse(parts[2]);
        }
    }
}