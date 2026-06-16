using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;

namespace HealthCare.Api.Repositories.Impl
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(HealthCareDbContext context) : base(context) { }
    }
}