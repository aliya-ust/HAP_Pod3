using AutoMapper;
using HealthCare.Api;
using HealthCareApi.Repositories.Implementations;
using HealthCareApi.Repositories.Interfaces;
using HealthCareApi.Services.Implementations;
using HealthCareApi.Services.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HealthCare.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers


            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();


            // DbContext
            container.RegisterInstance<IMapper>(mapper);
            container.RegisterType<HealthAppDbContext>();

            // Generic Repository
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

            // Doctor Repository
            container.RegisterType<IDoctorRepository, DoctorRepository>();
            container.RegisterType<IPatientRepository, PatientRepository>();
            container.RegisterType<IAppointmentRepository, AppointmentRepository>();
            container.RegisterType<IHealthRecordRepository, HealthRecordRepository>();

            // Services
            container.RegisterType<IDoctorService, DoctorService>();
            container.RegisterType<IPatientService, PatientService>();
            container.RegisterType<IAppointmentService, AppointmentService>();
            container.RegisterType<IHealthRecordService, HealthRecordService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}