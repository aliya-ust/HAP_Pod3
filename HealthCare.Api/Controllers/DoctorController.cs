//using HealthCareApi.Models;
using AutoMapper;
using HealthCare.Api;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.Doctor;
using HealthCareApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HealthCareApi.Controllers
{
    [ExcludeFromCodeCoverage]

    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        // GET DOCTORS WITH FILTERING, SEARCH, SORTING, AND PAGINATION
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetDoctors(
            [FromUri] string specialisation = null,
            [FromUri] string searchTerm = null,
            [FromUri] bool orderByDescending = false,
            [FromUri] int pageNumber = 1,
            [FromUri] int pageSize = 10)
        {
            var result = await _doctorService.GetFilteredDoctorsAsync(
                specialisation,
                searchTerm,
                orderByDescending,
                pageNumber,
                pageSize);

         
            var doctorDtos = _mapper.Map<IEnumerable<DoctorDto>>(result.Items);

           
            return Ok(new PagedResult<DoctorDto>
            {
                Items = doctorDtos.ToList(),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            });
        }

        // GET DOCTORS BY SPECIALISATION
        [HttpGet]
        [Route("api/doctors/specialisation/{specialisation}")]
        public async Task<IHttpActionResult> GetBySpecialization(string specialisation)
        {
            var doctors = await _doctorService.GetDoctorBySpecializationAsync(specialisation);

            var result = doctors.Select(d => new
            {
                d.DoctorId,
                d.FullName
            });


            return Ok(result);
        }

        //  GET DOCTOR BY ID
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();

            var doctorDto = _mapper.Map<DoctorDto>(doctor);

            return Ok(doctorDto);
        }

        // CREATE NEW DOCTOR
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Add(DoctorDto doctor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdDoctor = await _doctorService.AddDoctorAsync(doctor);

            var dto = _mapper.Map<DoctorDto>(createdDoctor);

           
            return Created($"api/doctors/{dto.DoctorId}", dto);
        }

        // UPDATE DOCTOR

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

        //  DELETE DOCTOR
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