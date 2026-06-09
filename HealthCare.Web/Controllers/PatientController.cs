using HealthCare.Shared.DTOs.Patient;
using HealthCare.Web.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
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

        // LIST (Index view)
        public async Task<ActionResult> List(string searchTerm, int pageNumber = 1)
        {
            var result = await _service.GetPatientsAsync(searchTerm, pageNumber, PageSize);

            // result = PagedResult<PatientDto>
            return View(result);
        }

        // PROFILE (Profile.cshtml)
        public async Task<ActionResult> Profile(int id = 0)
        {
            PatientDto patient;

            if (User.IsInRole("Patient"))
            {
                patient = await _service.GetByIdAsync(GetCurrentUserId());
            }
            else if (User.IsInRole("Admin") && id != 0)
            {
                patient = await _service.GetByIdAsync(id);
            }
            else
            {
                return new HttpUnauthorizedResult();
            }

            if (patient == null)
                return HttpNotFound();

            return View(patient); // Profile.cshtml 
        }

        // REGISTER (GET → Register.cshtml)
        [Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            return View(); // Register.cshtml 
        }

        //  REGISTER (POST → Register.cshtml)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(PatientDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto); // MUST return Register view

            var result = await _service.CreateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Patient created successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating patient");
            return View(dto); // Register.cshtml 
        }

        // EDIT (GET → Edit.cshtml)
        public async Task<ActionResult> Edit(int id = 0)
        {
            PatientDto patient;

            if (User.IsInRole("Patient"))
            {
                patient = await _service.GetByIdAsync(GetCurrentUserId());
            }
            else if (User.IsInRole("Admin") && id != 0)
            {
                patient = await _service.GetByIdAsync(id);
            }
            else
            {
                return new HttpUnauthorizedResult();
            }

            if (patient == null)
                return HttpNotFound();

            return View(patient); // Edit.cshtml 
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PatientDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            // Security check
            if (User.IsInRole("Patient") && dto.PatientId != GetCurrentUserId())
                return new HttpUnauthorizedResult();

            var result = await _service.UpdateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Patient updated successfully.";

                // FIXED: redirect to Profile (NOT Details)
                return RedirectToAction("Profile", new { id = dto.PatientId });
            }

            ModelState.AddModelError("", "Error updating patient");
            return View(dto);
        }

        // DELETE
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result)
                TempData["Success"] = "Patient deleted.";
            else
                TempData["Error"] = "Delete failed.";

            return RedirectToAction("Index");
        }

        // HELPER
        private int GetCurrentUserId()
        {
            var identity = (FormsIdentity)User.Identity;
            var parts = identity.Ticket.UserData.Split('|');
            return int.Parse(parts[2]);
        }
    }
}