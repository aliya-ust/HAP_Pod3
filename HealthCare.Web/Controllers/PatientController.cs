using HealthCare.Shared.DTOs.Patient;
using HealthCare.Web.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;
using HealthCare.Web.Services;

namespace HealthCare.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _service;
        private const int PageSize = 10;

        public PatientController()
        {
            _service = new PatientService();
        }

        // LIST → Patient/List.cshtml
        public async Task<ActionResult> List(string searchTerm, int pageNumber = 1)
        {
            var result = await _service.GetPatientsAsync(searchTerm, pageNumber, PageSize);
            return View(result);
        }

        // PROFILE → Patient/Profile.cshtml
        public async Task<ActionResult> Profile(int id)
        {
            if (id == 0)
                return HttpNotFound();

            var patient = await _service.GetByIdAsync(id);

            if (patient == null)
                return HttpNotFound();

            return View(patient);
        }

        // REGISTER (GET)
        public ActionResult Register()
        {
            return View();
        }

        // REGISTER (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(PatientDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.CreateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Patient created successfully.";
                return RedirectToAction("List");
            }

            ModelState.AddModelError("", "");
            return View(dto);
        }

        // EDIT (GET)
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
                return HttpNotFound();

            var patient = await _service.GetByIdAsync(id);

            if (patient == null)
                return HttpNotFound();

            return View(patient);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PatientDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.UpdateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Patient updated successfully.";
                return RedirectToAction("Profile", new { id = dto.PatientId });
            }

            ModelState.AddModelError("", "Error updating patient");
            return View(dto);
        }

        // DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result)
                TempData["Success"] = "Patient deleted.";
            else
                TempData["Error"] = "Delete failed.";

            return RedirectToAction("List");
        }
    }
}