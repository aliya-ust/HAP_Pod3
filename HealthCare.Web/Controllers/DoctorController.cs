using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Web.Services;
using HealthCare.Web.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HealthCare.Web.Controllers
{
    [ExcludeFromCodeCoverage]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;
        private const int PageSize = 10;

        public DoctorController()
        {
            _service = new DoctorService();
        }

        // LIST WITH FILTERING, SEARCH, SORTING, AND PAGINATION
        public async Task<ActionResult> Index(
            string specialisation,
            string searchTerm,
            bool orderByDescending = false,
            int pageNumber = 1)
        {
            var result = await _service.GetDoctorsAsync(
                specialisation,
                searchTerm,
                orderByDescending,
                pageNumber,
                PageSize);

            
            ViewBag.SearchTerm = searchTerm;
            ViewBag.Specialisation = specialisation;

            return View(result);
        }

       
        public async Task<ActionResult> Profile(int id)
        {
            var doctor = await _service.GetByIdAsync(id);

            if (doctor == null)
                return HttpNotFound();

            return PartialView("_ProfilePartial", doctor);
        }

        // REGISTER (GET)
        public ActionResult Register()
        {
            return View();
        }

        // REGISTER (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(DoctorDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.CreateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Doctor created successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating doctor");
            return View(dto);
        }

        // EDIT (GET)
        public async Task<ActionResult> Edit(int id)
        {
            var doctor = await _service.GetByIdAsync(id);

            if (doctor == null)
                return HttpNotFound();

            return View(doctor);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DoctorDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.UpdateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Doctor updated successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error updating doctor");
            return View(dto);
        }

        // OPTIONAL: Available Doctors Page
        public async Task<ActionResult> Available(
            string specialisation,
            string searchTerm,
            bool orderByDescending = false,
            int pageNumber = 1)
        {
            var result = await _service.GetDoctorsAsync(
                specialisation,
                searchTerm,
                orderByDescending,
                pageNumber,
                PageSize);

            return View(result);
        }

        // DELETE
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result)
                TempData["Success"] = "Doctor deleted successfully.";
            else
                TempData["Error"] = "Delete failed.";

            return RedirectToAction("Index");
        }
    }
}