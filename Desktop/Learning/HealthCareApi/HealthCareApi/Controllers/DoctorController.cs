using HealthCareApi.Models;
using HealthCareApi.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace HealthCareApi.Controllers
{
    [RoutePrefix("api/doctors")]
    public class DoctorController : ApiController
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
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
            // Call the async service method
            var doctors = await _doctorService.GetFilteredDoctorsAsync(
                specialization,
                searchTerm,
                orderByDescending,
                pageNumber,
                pageSize);

            return Ok(doctors);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null) return NotFound();

            return Ok(doctor);
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Add(Doctor doctor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _doctorService.AddDoctorAsync(doctor);
            return Ok(doctor);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update(Doctor doctor)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _doctorService.UpdateDoctorAsync(doctor);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }
    }
}