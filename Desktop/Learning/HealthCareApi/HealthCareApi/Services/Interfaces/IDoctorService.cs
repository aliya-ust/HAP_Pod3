using HealthCareApi.Models;
using System.Collections.Generic;

namespace HealthCareApi.Services.Interfaces
{
    public interface IDoctorService
    {
        List<Doctor> GetAllDoctors();
    }

}
