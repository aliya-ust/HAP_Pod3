using HealthCare.Shared;
using HealthCare.Shared.DTOs.HealthRecord;
using HealthCare.Web.Services;
using HealthCare.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HealthCare.Web.Controllers
{
    [ExcludeFromCodeCoverage]
    public class HealthRecordController : Controller
    {
        private readonly IHealthRecordService _service;
        private const int PageSize = 10;

        public HealthRecordController()
        {
            _service = new HealthRecordService();
        }

        //public async Task<ActionResult> List(int pageNumber = 1)
        //{
        //    var result = await _service.GetAllAsync(pageNumber, PageSize);

        //    return View(result);
        //}

        //  LIST / HISTORY

        public async Task<ActionResult> List(int? patientId, int pageNumber = 1)
        {
            if (!patientId.HasValue)
            {
                return View(new PagedResult<HealthRecordDto>
                {
                    Items = new List<HealthRecordDto>(),
                    PageNumber = 1,
                    PageSize = PageSize
                });
            }

            var result = await _service.GetPatientHealthHistoryAsync(
                patientId.Value,
                pageNumber,
                PageSize);

            return View("List", result);
        }

        // ADD GET
        public async Task<ActionResult> Create(int appointmentId)
        {
            var dto = new HealthRecordDto
            {
                AppointmentId = appointmentId
            };
            return View(dto);
        }

        // ADD POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HealthRecordDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var result = await _service.CreateAsync(dto);

                if (result != null)
                {
                    TempData["Success"] = "Health record added successfully.";
                    return RedirectToAction("List", new { patientId = dto.PatientId });
                }

                ModelState.AddModelError("", "Failed to create record");
                return View(dto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(dto);
            }
        }

        // SINGLE RECORD VIEW
        public async Task<ActionResult> Single(int id)
        {
            try
            {
                var record = await _service.GetByIdAsync(id);

                if (record == null)
                {
                    ViewBag.Error = "Health record not found.";
                    return View();
                }

                return View(record);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

    }
}