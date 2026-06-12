using HealthCare.Shared;
using HealthCare.Shared.DTOs.Patient;
using HealthCare.Web.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HealthCare.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _service;

        private const int PageSize = 10;
        private const string RegisterView = "Register";

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        private ActionResult ResultWithMessage(bool success, string successMsg, string errorMsg)
        {
            TempData[success ? "Success" : "Error"] =
                success ? successMsg : errorMsg;

            return RedirectToAction("List");
        }

        // LIST → Patient/List.cshtml
        public async Task<ActionResult> List(string searchTerm, int pageNumber = 1)
        {
            var result = await _service.GetPatientsAsync(searchTerm, pageNumber, PageSize);
            return View(result);
        }

        // REGISTER (GET)
        public ActionResult Register()
        {
            return View(RegisterView);
        }

        // REGISTER (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(PatientDto dto)
        {
            if (!ModelState.IsValid)
                return View(RegisterView, dto);

            var isAvailable = await _service.IsEmailAvailableAsync(dto.Email);

            if (!isAvailable)
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View(RegisterView, dto);
            }

            var result = await _service.CreateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Patient created successfully.";
                return RedirectToAction("List");
            }

            ModelState.AddModelError("", "Error creating patient");
            return View(RegisterView, dto);
        }

        [HttpGet]
        public async Task<ActionResult> IsEmailAvailable(string Email)
        {
            var isAvailable = await _service.IsEmailAvailableAsync(Email);
            return Json(isAvailable, JsonRequestBehavior.AllowGet);
        }

        // EDIT (GET)
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);
            var patient = result.Items.FirstOrDefault();

            if (patient == null)
                return RedirectToAction("List");

            return View(patient);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.UpdateAsync(dto);

            if (!result)
            {
                ModelState.AddModelError("", "Update failed");
                return View(dto);
            }

            return ResultWithMessage(true, "Patient updated successfully", "");
        }

        // DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return ResultWithMessage(result, "Patient deleted.", "Delete failed.");
        }

        public async Task<ActionResult> EditPartial(int id)
        {
            var patient = await _service.GetByIdAsync(id);
            return PartialView("_EditPartial", patient);
        }

        public async Task<ActionResult> ViewPartial(int id)
        {
            var patient = await _service.GetByIdAsync(id);
            return PartialView("_ViewPartial", patient);
        }
    }
}