using HealthCare.Api.DTOs;
using HealthCare.Api.DTOs.Patient;
using HealthCare.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController(IPatientService patientService) : ControllerBase
    {
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await patientService.GetByIdAsync(id);
            if (patient is null) return NotFound();
            return Ok(patient);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] PatientFilter filter)
        {
            var patients = await patientService.GetAllAsync(filter);
            return Ok(patients);
        }
        
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Create(CreatePatientDto dto)
        {
            await patientService.AddAsync(dto);
            return Ok(new { message = "Patient created successfully" });
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Patient")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePatientDto dto)
        {
            var existing = await patientService.GetByIdAsync(id);
            if (existing is null) return NotFound();
            await patientService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await patientService.GetByIdAsync(id);
            if (existing is null) return NotFound();
            await patientService.DeleteAsync(id);
            return NoContent();
        }
    }
}
