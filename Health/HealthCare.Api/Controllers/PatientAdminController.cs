using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace HealthCare.Api.Controllers
{
    [ApiController]
    [Route("api/admin/patients")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class PatientAdminController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientAdminController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            return Ok(patient);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PatientFilter filter)
        {
            var patients = await _patientService.GetAllAsync(filter);
            return Ok(patients);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(CreatePatientDto dto)
        //{
        //    await _patientService.AddAsync(dto);
        //    return Ok(new { message = "Patient created successfully." });
        //}

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdatePatientDto dto)
        {
            await _patientService.UpdateAsync(id, dto);
            return Ok(new { message = "Patient updated successfully." });
        }

        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(int id, bool isActive)
        {
            await _patientService.UpdateStatusAsync(id, isActive);
            return Ok(new { message = "Patient status updated successfully." });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientService.DeleteAsync(id);
            return Ok(new { message = "Patient deleted successfully." });
        }
    }
}