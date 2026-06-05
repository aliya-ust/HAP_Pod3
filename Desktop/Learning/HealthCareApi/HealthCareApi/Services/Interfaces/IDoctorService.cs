using HealthCareApi.Models;
using System.Collections.Generic;

namespace HealthCareApi.Service.Interfaces
{
    public interface IDoctorService
    {
        List<Doctor> GetAllDoctors();
    }

}
