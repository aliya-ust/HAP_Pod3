using Microsoft.Extensions.DependencyInjection;
using HealthApp;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Repositories.impl;
using HealthApp.ConsoleApp.Database;

namespace HealthApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // ✅ Create Service Collection
            var services = new ServiceCollection();

            // ✅ Register Dependencies
            services.AddSingleton<DoctorDb>(); // shared DB instance
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<DoctorMenu>();

            // ✅ Build Service Provider
            var provider = services.BuildServiceProvider();

            // ✅ Resolve DoctorMenu
            var menu = provider.GetService<DoctorMenu>();

            if (menu != null)
            {
                menu.ShowMenu();
            }
        }
    }
}