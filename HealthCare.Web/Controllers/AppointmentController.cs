using HealthCare.Shared.DTOs.Appointment;
using HealthCare.Web.Services;
using HealthCare.Web.Services.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HealthCare.Web.Controllers
{
    [ExcludeFromCodeCoverage]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _service;
        private const int PageSize = 10;

        public AppointmentController()
        {
            _service = new AppointmentService();
        }

        public ActionResult Index()
        {
            return View();
        }

        //  LIST PATIENT APPOINTMENTS
        public async Task<ActionResult> List(int patientId, string status, int pageNumber = 1)
        {
            var result = await _service.GetPatientAppointmentsAsync(
                patientId,
                status,
                pageNumber,
                PageSize);

            return View("Index", result);
        }

        //  BOOK (GET)
        public ActionResult Book()
        {
            return View("Book");
        }

        //  BOOK (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Book(AppointmentDto dto)
        {
            try
            {
                var result = await _service.BookAsync(dto);

                if (result)
                {
                    TempData["Success"] = "Appointment booked successfully.";
                    return RedirectToAction("Index", new { patientId = dto.PatientId });
                }

                ModelState.AddModelError("", "Booking failed");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View("Book", dto);
        }

        //  CONFIRM
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Confirm(int id, int patientId)
        {
            await _service.ConfirmAsync(id);
            return RedirectToAction("Index", new { patientId });
        }

        //  CANCEL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cancel(int id, int patientId, string reason)
        {
            await _service.CancelAsync(id, reason);
            return RedirectToAction("Index", new { patientId });
        }

        //  DOCTOR TODAY
        public async Task<ActionResult> Today(int doctorId)
        {
            var data = await _service.GetTodayAppointmentsAsync(doctorId);
            return View("Today", data);
        }

        //  DOCTOR WEEK
        public async Task<ActionResult> Week(int doctorId)
        {
            var data = await _service.GetWeeklyAppointmentsAsync(doctorId);
            return View("Week", data);
        }

        //  BY DATE
        public async Task<ActionResult> ByDate(DateTime date)
        {
            var data = await _service.GetByDateAsync(date);
            return View("ByDate", data);
        }
    }
}