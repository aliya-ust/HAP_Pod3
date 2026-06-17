using HealthCare.Api.Data;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Models;

namespace HealthCare.Api.Repositories.Implementations
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(HealthCareDbContext context) : base(context) { }
    }
} 