using AutoMapper;
using HealthCare.Api;
using HealthCare.Shared;
using HealthCare.Shared.DTOs.Appointment;
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

    [RoutePrefix("api/appointments")]
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(
            IAppointmentService appointmentService,
            IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        // BOOK APPOINTMENT
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Book(Appointment appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _appointmentService
                    .BookAppointmentAsync(appointment);

                var dto = _mapper.Map<AppointmentDto>(created);

                return Created($"api/appointments/{dto.AppointmentId}", dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET PATIENT APPOINTMENTS 
      
        [HttpGet]
        [Route("patient/{patientId:int}")]
        public async Task<IHttpActionResult> GetPatientAppointments(
            int patientId,
            string status = null,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var result = await _appointmentService
                .GetPatientAppointmentsAsync(patientId, status, pageNumber, pageSize);

            
            var dtos = _mapper.Map<IEnumerable<AppointmentDto>>(result.Items);

          
            return Ok(new PagedResult<AppointmentDto>
            {
                Items = dtos.ToList(),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            });
        }     

        // GET APPOINTMENTS BY DATE

        [HttpGet]
        [Route("date")]
        public async Task<IHttpActionResult> GetByDate(DateTime date)
        {
            var appointments = await _appointmentService
                .GetAppointmentsByDateAsync(date);

            var dtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

            return Ok(dtos);
        }

        // GET AVAILABLE SLOTS FOR DOCTOR
        [HttpGet]
        [Route("slots")]
        public async Task<IHttpActionResult> GetSlots(int doctorId, DateTime date)
        {
            var slots = await _appointmentService.GetAvailableSlotsAsync(doctorId, date);
            return Ok(slots);
        }

        // CONFIRM APPOINTMENT

        [HttpPut]
        [Route("{id:int}/confirm")]
        public async Task<IHttpActionResult> Confirm(int id)
        {
            try
            {
                var appointment = await _appointmentService
                    .ConfirmAppointmentAsync(id);

                var dto = _mapper.Map<AppointmentDto>(appointment);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // CANCEL APPOINTMENT

        [HttpPut]
        [Route("{id:int}/cancel")]
        public async Task<IHttpActionResult> Cancel(int id, CancelAppointmentDto dto)
        {
            try
            {
                var appointment = await _appointmentService
                    .CancelAppointmentAsync(id, dto.Reason);

                var result = _mapper.Map<AppointmentDto>(appointment);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}