using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Web.Services;
using HealthCare.Web.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using HealthCare.Shared;

namespace HealthCare.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;
        private const int PageSize = 10;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        private ActionResult RedirectWithMessage(bool success, string successMsg, string errorMsg)
        {
            TempData[success ? "Success" : "Error"] = success ? successMsg : errorMsg;
            return RedirectToAction("List");
        }

        //  LIST → Doctor/List.cshtml
        public async Task<ActionResult> List(
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

        //  CREATE (GET) → Doctor/Register.cshtml
        public ActionResult Add()
        {
            return View("Add");
        }

        //  CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(CreateDoctorDto dto)
        {
            if (dto.TimeSlots == null || !dto.TimeSlots.Any())
            {
                ModelState.AddModelError("TimeSlots", "Please select at least one time slot");
            }

            if (!ModelState.IsValid)
                return View("Add", dto);

            var result = await _service.CreateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Doctor created successfully.";
                return RedirectToAction("List");
            }

            ModelState.AddModelError("", "Error creating doctor");
            return View("Add", dto);
        }

        //  EDIT (GET) → Doctor/Edit.cshtml
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _service.GetByIdAsync(id);

            var doctor = result.Items.FirstOrDefault();

            if (doctor == null)
                return RedirectToAction("List");

            return View(doctor);
        }

        //  EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.UpdateAsync(dto);

            if (!result)
            {
                ModelState.AddModelError("", "Update failed");
                return View(dto);
            }

            return RedirectWithMessage(true, "Doctor updated successfully", "");
        }


        //  DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return RedirectWithMessage(result, "Doctor deleted.", "Delete failed.");
        }

        [HttpGet]
        public async Task<ActionResult> GetDoctors(string specialization)
        {
            var doctors = await _service
                .GetDoctorsBySpecializationAsync(specialization);

            return Json(doctors, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> IsEmailAvailable(string Email)
        {
            var isAvailable = await _service.IsEmailAvailableAsync(Email);

            //  already returns true/false correctly
            return Json(isAvailable, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Profile(int id)
        {
            var doctor = await _service.GetByIdAsync(id);

            if (doctor == null)
            {
                TempData["Error"] = "Doctor does not exist.";
            }

            return View("List", doctor);
        }

        public ActionResult AddPartial()
        {
            return View("Add");
        }

        public async Task<ActionResult> EditPartial(int id)
        {
            var doctor = await _service.GetByIdAsync(id);
            return View("Edit", doctor);
        }

        public async Task<ActionResult> ViewPartial(int id)
        {
            var doctor = await _service.GetByIdAsync(id);
            return PartialView("_ViewPartial", doctor);
        }
    }
}