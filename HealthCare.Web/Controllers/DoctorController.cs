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

        public DoctorController(IDoctorService service)
        {
            _service = service;
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

        //  PROFILE → Doctor/Profile.cshtml
        public async Task<ActionResult> Profile(int id)
        {
            var doctor = await _service.GetByIdAsync(id);

            if (doctor == null)
                return View("NotFound");;

            return View("Profile", doctor);
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
            if (!ModelState.IsValid)
                return PartialView("_EditPartial", dto);

            var result = await _service.CreateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Doctor created successfully.";
                return RedirectToAction("List");
            }

            ModelState.AddModelError("", "Error creating doctor");
            return PartialView("_EditPartial", dto);
        }

        //  EDIT (GET) → Doctor/Edit.cshtml
        public async Task<ActionResult> Edit(int id)
        {
            var doctor = await _service.GetByIdAsync(id);

            if (doctor == null)
                return View("NotFound");;

            return View("Edit", doctor);
        }

        //  EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return PartialView("_EditPartial", dto);

            var result = await _service.UpdateAsync(dto);

            if (result)
            {
                TempData["Success"] = "Doctor updated successfully.";
                return RedirectToAction("List", new { id = dto.DoctorId });
            }

            ModelState.AddModelError("", "Error updating doctor");
            return PartialView("_EditPartial", dto);
        }

        //  DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result)
                TempData["Success"] = "Doctor deleted.";
            else
                TempData["Error"] = "Delete failed.";

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> GetDoctors(string specialization)
        {
            var doctors = await _service
                .GetDoctorsBySpecializationAsync(specialization);

            return Json(doctors, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddPartial()
        {
            return PartialView("_AddPartial");
        }

        public async Task<ActionResult> EditPartial(int id)
        {
            var doctor = await _service.GetByIdAsync(id);
            return PartialView("_EditPartial", doctor);
        }

        public async Task<ActionResult> ViewPartial(int id)
        {
            var doctor = await _service.GetByIdAsync(id);
            return PartialView("_ViewPartial", doctor);
        }
    }
}