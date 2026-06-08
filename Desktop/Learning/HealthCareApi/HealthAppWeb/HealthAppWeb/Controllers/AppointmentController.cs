using System;
using System.Web.Mvc;
using System.Web.Security;
using HealthAppWeb.Models.ViewModels;
using HealthAppWeb.Services.Implementations;
using HealthAppWeb.Services.Interfaces;

namespace HealthAppWeb.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _service;

        public AppointmentController()
        {
            _service = new AppointmentService();
        }

        [Authorize(Roles = "Patient")]
        public ActionResult Book(int? selectedDoctorId)
        {
            var vm = _service.GetBookingViewModel(selectedDoctorId);

            vm.SelectedDoctorId = selectedDoctorId ?? 0;

            return View(vm);
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book(AppointmentBookingViewModel vm)
        {
            var fresh = _service.GetBookingViewModel();
            vm.Doctors = fresh.Doctors;
            vm.AvailableSlots = _service.GetAvailableSlots(vm.SelectedDoctorId, vm.SelectedDate);

            if (!ModelState.IsValid)
                return View(vm);

            var result = _service.Book(vm, GetCurrentUserId());
            if (!result.Success)
            {
                ModelState.AddModelError(result.ErrorField, result.ErrorMessage);
                return View(vm);
            }

            TempData["Success"] = "Appointment booked successfully.";
            return RedirectToAction("MyAppointments");
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        public ActionResult GetSlots(int doctorId, DateTime date)
        {
            var slots = _service.GetAvailableSlots(doctorId, date);
            return Json(slots);
        }

        [Authorize(Roles = "Patient")]
        public ActionResult MyAppointments()
        {
            var vm = _service.GetPatientAppointments(GetCurrentUserId());
            return View(vm);
        }

        [Authorize(Roles = "Patient")]
        public ActionResult CancelPatient(int id)
        {
            var vm = _service.GetCancelViewModelForPatient(id, GetCurrentUserId());
            if (vm == null)
            {
                TempData["Error"] = "This appointment cannot be cancelled.";
                return RedirectToAction("MyAppointments");
            }
            return View(vm);
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelPatient(CancelAppointmentViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var result = _service.CancelByPatient(vm.AppointmentId, vm.Reason, GetCurrentUserId());
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return View(vm);
            }

            TempData["Success"] = "Appointment cancelled.";
            return RedirectToAction("MyAppointments");
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult Schedule(DateTime filterDate = default(DateTime))
        {
            if (filterDate == default(DateTime))
                filterDate = DateTime.Today;

            var vm = _service.GetDoctorSchedule(GetCurrentUserId(), filterDate);
            return View(vm);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Confirm(int id)
        {
            var result = _service.ConfirmByDoctor(id, GetCurrentUserId());

            if (!result.Success)
                TempData["Error"] = result.ErrorMessage;
            else
                TempData["Success"] = "Appointment confirmed.";

            return RedirectToAction("Schedule");
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult CancelDoctor(int id)
        {
            var vm = _service.GetCancelViewModelForDoctor(id, GetCurrentUserId());
            if (vm == null)
                return new HttpUnauthorizedResult();

            return View(vm);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelDoctor(CancelAppointmentViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var result = _service.CancelByDoctor(vm.AppointmentId, vm.Reason, GetCurrentUserId());
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return View(vm);
            }

            TempData["Success"] = "Appointment cancelled.";
            return RedirectToAction("Schedule");
        }

        private int GetCurrentUserId()
        {
            var identity = (FormsIdentity)User.Identity;
            var parts = identity.Ticket.UserData.Split('|');
            return int.Parse(parts[2]);
        }
    }
}