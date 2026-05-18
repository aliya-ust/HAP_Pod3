using Microsoft.Extensions.DependencyInjection;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Interfaces;

// var services= new ServiceCollection()
//     .AddSingleton<IAppointmentRepository, AppointmentRepo>()
//     .AddSingleton<IAppointmentService, AppointmentService>()
//     .BuildServiceProvider();

 var services = new ServiceCollection();
    services.AddSingleton<IAppointmentService, AppointmentService>();
    //services.AddScoped<DoctorMenu>();.
    var provider = services.BuildServiceProvider();
    IAppointmentService service = provider.GetService<IAppointmentService>();