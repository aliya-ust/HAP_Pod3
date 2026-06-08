//using HealthCareApi.Models;
using AutoMapper;
using HealthCareApi.DTOs.Doctor;
using HealthCareApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HealthCareApi.Controllers
{
    [RoutePrefix("api/doctors")]
    public class DoctorController : ApiController
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetDoctors(
            [FromUri] string specialization = null,
            [FromUri] string searchTerm = null,
            [FromUri] bool orderByDescending = false,
            [FromUri] int pageNumber = 1,
            [FromUri] int pageSize = 10)
        {
            var doctors = await _doctorService.GetFilteredDoctorsAsync(
                specialization,
                searchTerm,
                orderByDescending,
                pageNumber,
                pageSize);

            // Map to DTO
            var doctorDtos = _mapper.Map<IEnumerable<DoctorDto>>(doctors);

            return Ok(doctorDtos);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();

            var doctorDto = _mapper.Map<DoctorDto>(doctor);

            return Ok(doctorDto);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Add(Doctor doctor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdDoctor = await _doctorService.AddDoctorAsync(doctor);

            var dto = _mapper.Map<DoctorDto>(createdDoctor);

            // ✅ Correct REST response
            return Created($"api/doctors/{dto.DoctorId}", dto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Update(int id, Doctor doctor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != doctor.DoctorId)
                return BadRequest("Doctor ID mismatch");

            var updatedDoctor = await _doctorService.UpdateDoctorAsync(doctor);

            if (updatedDoctor == null)
                return NotFound();

            var dto = _mapper.Map<DoctorDto>(updatedDoctor);

            return Ok(dto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var result = await _doctorService.DeleteDoctorAsync(id);

            if (!result)
                return NotFound();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}