using AutoMapper;
using HealthCare.Api;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.HealthRecord;
using HealthCareApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace HealthCareApi.Controllers
{
    [ExcludeFromCodeCoverage]

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

        //  ADD HEALTH RECORD
     
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create(HealthRecordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var record = new HealthRecord
                {
                    AppointmentId = dto.AppointmentId,
                    Diagnosis = dto.Diagnosis,
                    Prescription = dto.Prescription,
                    Notes = dto.Notes
                };

                var created = await _healthRecordService.CreateAsync(record);

                return Ok(created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //  GET PATIENT HEALTH HISTORY (VIEW + Pagination)
      
        [HttpGet]
        [Route("patient/{patientId:int}")]
        public async Task<IHttpActionResult> GetPatientHistory(
            int patientId,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var result = await _healthRecordService
                .GetPatientHealthHistoryAsync(patientId, pageNumber, pageSize);

         
            var dtos = _mapper.Map<IEnumerable<HealthRecordDto>>(result.Items);

          
            return Ok(new PagedResult<HealthRecordDto>
            {
                Items = dtos.ToList(),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            });
        }
      
        // GET HEALTH RECORD BY ID
  
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

        // GET ALL HEALTH RECORDS
   
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {
                var records = await _healthRecordService.GetAllAsync();

                var dtos = _mapper.Map<IEnumerable<HealthRecordDto>>(records);

                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}