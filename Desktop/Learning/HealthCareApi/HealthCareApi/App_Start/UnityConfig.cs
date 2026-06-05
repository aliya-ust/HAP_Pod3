using HealthCareApi.Data.Context;
using HealthCareApi.Data.Repositories.Implementations;
using HealthCareApi.Data.Repositories.Interfaces;
using HealthCareApi.Repositories.Implementations;
using HealthCareApi.Repositories.Interfaces;
using HealthCareApi.Services.Implementations;
using HealthCareApi.Services.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace HealthCareApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // DbContext
            container.RegisterType<HealthCareDbContext>();

            // Generic Repository
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            // Doctor Repository
            container.RegisterType<IDoctorRepository, DoctorRepository>();

            // Services
            container.RegisterType<IDoctorService, DoctorService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}