using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;

namespace HealthCare.Api.Repositories.Impl
{
    public class HealthRecordRepository : Repository<HealthRecord>, IHealthRecordRepository
    {
        public HealthRecordRepository(HealthCareDbContext context) : base(context) { }
    }
}