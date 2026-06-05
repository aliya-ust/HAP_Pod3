using System.Web.Http;
using HealthCareApi.Repositories.Interfaces;

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

        [HttpGet, Route("")]
        public IHttpActionResult GetAll() =>
        Ok(_doctorService.GetAllDoctors());
    }
}
