using HealthCare.Shared.DTOs.Patient;
using HealthCare.Web.Services;
using HealthCare.Web.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

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

        // LIST (INDEX PAGE)
        public async Task<ActionResult> Index(string searchTerm, int pageNumber = 1)
        {
            var result = await _service.GetPatientsAsync(searchTerm, pageNumber, PageSize);
            return View(result);
        }

        // PROFILE
        public async Task<ActionResult> Profile(int id)
        {
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
        public async Task<ActionResult> Register(CreatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.CreateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Patient created successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating patient");
            return View(dto);
        }

        // EDIT (GET)
        public async Task<ActionResult> Edit(int id)
        {
            var patient = await _service.GetByIdAsync(id);

            if (patient == null)
                return HttpNotFound();

            return View(patient);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.UpdateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Updated successfully";
                return RedirectToAction("Profile", new { id = dto.PatientId });
            }

            ModelState.AddModelError("", "Update failed");
            return View(dto);
        }

        // DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            TempData[result ? "Success" : "Error"] =
                result ? "Deleted successfully" : "Delete failed";

            return RedirectToAction("Index");
        }
    }
}