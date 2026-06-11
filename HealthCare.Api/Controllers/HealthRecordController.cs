using AutoMapper;
using HealthCare.Api;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.HealthRecord;
using HealthCareApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace HealthCareApi.Controllers
{
    [RoutePrefix("api/healthrecords")]
    public class HealthRecordController : ApiController
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly IMapper _mapper;

        public HealthRecordController(
            IHealthRecordService healthRecordService,
            IMapper mapper)
        {
            _healthRecordService = healthRecordService;
            _mapper = mapper;
        }

        // 1. ADD HEALTH RECORD
        // POST: api/healthrecords
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Add(HealthRecord record)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _healthRecordService
                    .CreateAsync(record);

                return Ok(created);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        // 2. GET PATIENT HEALTH HISTORY (VIEW + Pagination)
        // GET: api/healthrecords/patient/5?pageNumber=1&pageSize=5
        [HttpGet]
        [Route("patient/{patientId:int}")]
        public async Task<IHttpActionResult> GetPatientHistory(
            int patientId,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var result = await _healthRecordService
                .GetPatientHealthHistoryAsync(patientId, pageNumber, pageSize);

            // ✅ map ONLY Items
            var dtos = _mapper.Map<IEnumerable<HealthRecordDto>>(result.Items);

            // ✅ return paged result
            return Ok(new PagedResult<HealthRecordDto>
            {
                Items = dtos.ToList(),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            });
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(HealthRecordDto dto)
        {
            try
            {
                var record = new HealthRecord
                {
                    AppointmentId = dto.AppointmentId,
                    PatientId = dto.PatientId,
                    DoctorId = dto.DoctorId,
                    Diagnosis = dto.Diagnosis,
                    Prescription = dto.Prescription,
                    Notes = dto.Notes,
                    VisitDate = DateTime.Now
                };

                var result = await _healthRecordService.CreateAsync(record);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // ✅ send error
            }
        }

        // ✅ 3. GET HEALTH RECORD BY ID
        // GET: api/healthrecords/10
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            try
            {
                var record = await _healthRecordService.GetByAppointmentIdAsync(id);

                if (record == null)
                    return NotFound();

                var dto = _mapper.Map<HealthRecordDto>(record);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}