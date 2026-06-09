using HealthCare.Shared.DTOs.HealthRecord;
using HealthCare.Web.Services;
using HealthCare.Web.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

public class HealthRecordController : Controller
{
    private readonly IHealthRecordService _service;
    private const int PageSize = 10;

    public HealthRecordController()
    {
        _service = new HealthRecordService();
    }

    //  LIST / HISTORY
    // → HealthRecord/List.cshtml
    public async Task<ActionResult> List(int patientId, int pageNumber = 1)
    {
        var result = await _service.GetPatientHealthHistoryAsync(
            patientId,
            pageNumber,
            PageSize);

        return View("List", result);
    }

    //  ADD (GET)
    // → HealthRecord/Create.cshtml
    public ActionResult Create(int patientId)
    {
        var model = new HealthRecordDto
        {
            PatientId = patientId
        };

        return View("Create", model);
    }

    //  ADD (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(HealthRecordDto dto)
    {
        if (!ModelState.IsValid)
            return View("Create", dto);

        var result = await _service.CreateAsync(dto);

        if (result)
        {
            TempData["Success"] = "Health record added successfully.";
            return RedirectToAction("List", new { patientId = dto.PatientId });
        }

        ModelState.AddModelError("", "Failed to create record");
        return View("Create", dto);
    }
}