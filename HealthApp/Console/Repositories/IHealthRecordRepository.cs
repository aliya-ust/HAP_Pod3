using System.Collections.Generic;
using HealthcareApp.Models;

namespace HealthcareApp.Repository
{
    public interface IHealthRecordRepository
    {
        void Add();
        void Delete(int index);
        void Update(int index);
        List<HealthRecord> GetAll();
    }
}