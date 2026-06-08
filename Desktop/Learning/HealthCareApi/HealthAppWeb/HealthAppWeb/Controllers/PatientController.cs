using HealthAppWeb.Models.ViewModels;
using HealthAppWeb.Services.Implementations;
using HealthAppWeb.Services.Interfaces;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace HospitalMVC.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientService _service;
        private const int PageSize = 10;

        public PatientController()
        {
            _service = new PatientService();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult List(int page = 1)
        {
            var vm = _service.GetPaged(page, PageSize);
            return View(vm);
        }

        public ActionResult Profile(int id = 0)
        {
            PatientProfileViewModel vm;

            if (User.IsInRole("Patient"))
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
        public ActionResult Register()
        {
            return View(new PatientRegisterViewModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(PatientRegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("age");
                return View(vm);

            }

            var result = _service.Register(vm);
            if (!result.Success)
            {
                System.Diagnostics.Debug.WriteLine("gae");
                ModelState.AddModelError(result.ErrorField, result.ErrorMessage);
                return View(vm);
            }

            System.Diagnostics.Debug.WriteLine("man");
            TempData["Success"] = "Patient registered successfully.";
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id = 0)
        {
            PatientEditViewModel vm;

            if (User.IsInRole("Patient"))
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
        public ActionResult Edit(PatientEditViewModel vm)
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
                return RedirectToAction("Profile", new { id = vm.PatientId });

            return RedirectToAction("Profile");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            TempData["Success"] = "Patient deleted.";
            return RedirectToAction("Index");
        }

        private int GetCurrentUserId()
        {
            var identity = (FormsIdentity)User.Identity;
            var parts = identity.Ticket.UserData.Split('|');
            return int.Parse(parts[2]);
        }
    }
}