using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Web.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;
using HealthCare.Web.Services;

namespace HealthCare.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;
        private const int PageSize = 10;

        public DoctorController()
        {
            _service = new DoctorService();
        }

        // ✅ LIST → Doctor/List.cshtml
        public async Task<ActionResult> Index(
            string specialization,
            string searchTerm,
            bool orderByDescending = false,
            int pageNumber = 1)
        {
            var result = await _service.GetDoctorsAsync(
                specialization,
                searchTerm,
                orderByDescending,
                pageNumber,
                PageSize);

            return View("List", result);
        }

        // ✅ PROFILE → Doctor/Profile.cshtml
        public async Task<ActionResult> Profile(int id)
        {
            var doctor = await _service.GetByIdAsync(id);

            if (doctor == null)
                return HttpNotFound();

            return View("Profile", doctor);
        }

        // ✅ CREATE (GET) → Doctor/Register.cshtml
        public ActionResult Register()
        {
            return View("Register");
        }

        // ✅ CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(DoctorDto dto)
        {
            if (!ModelState.IsValid)
                return View("Register", dto);

            var result = await _service.CreateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Doctor created successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating doctor");
            return View("Register", dto);
        }

        // ✅ EDIT (GET) → Doctor/Edit.cshtml
        public async Task<ActionResult> Edit(int id)
        {
            var doctor = await _service.GetByIdAsync(id);

            if (doctor == null)
                return HttpNotFound();

            return View("Edit", doctor);
        }

        // ✅ EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DoctorDto dto)
        {
            if (!ModelState.IsValid)
                return View("Edit", dto);

            var result = await _service.UpdateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Doctor updated successfully.";
                return RedirectToAction("Profile", new { id = dto.DoctorId });
            }

            ModelState.AddModelError("", "Error updating doctor");
            return View("Edit", dto);
        }

        // ✅ DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result)
                TempData["Success"] = "Doctor deleted.";
            else
                TempData["Error"] = "Delete failed.";

            return RedirectToAction("Index");
        }
    }
}