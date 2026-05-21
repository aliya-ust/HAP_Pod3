// ✅ Interfaces
using HealthApp.ConsoleApp.Interfaces;
// ✅ Menus
using HealthApp.ConsoleApp.Menus;
// ✅ Repositories
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Repositories.impl;
// ✅ Services
using HealthApp.ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HealthApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // ✅ 1. Create DI container
            var services = new ServiceCollection();

            // ✅ 2. Register Repositories
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepo>();
            services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();

            // ✅ 3. Register Services
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IHealthRecordService, HealthRecordService>();

            // ✅ 4. Register Menus
            services.AddScoped<PatientMenu>();
            services.AddScoped<DoctorMenu>();
            services.AddScoped<AppointmentMenu>();
            services.AddScoped<HealthRecordMenu>();

            // ✅ 5. Build provider
            var provider = services.BuildServiceProvider();

            // ✅ 6. Resolve menus
            var patientMenu = provider.GetRequiredService<PatientMenu>();
            var doctorMenu = provider.GetRequiredService<DoctorMenu>();
            var appointmentMenu = provider.GetRequiredService<AppointmentMenu>();
            var healthRecordMenu = provider.GetRequiredService<HealthRecordMenu>();

            Console.WriteLine("===================================");
            Console.WriteLine("    HEALTH CARE MANAGEMENT SYSTEM");
            Console.WriteLine("===================================");

            // ✅ 7. Main Menu Loop
            while (true)
            {
                Console.WriteLine("\n------ MAIN MENU ------");
                Console.WriteLine("1. Patient Module");
                Console.WriteLine("2. Doctor Module");
                Console.WriteLine("3. Appointment Module");
                Console.WriteLine("4. Health Record Module");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        patientMenu.PatientRegisteration();
                        break;

                    case "2":
                        doctorMenu.ShowMenu();
                        break;

                    case "3":
                        appointmentMenu.ShowMenu();
                        break;

                    case "4":
                        healthRecordMenu.ShowMenu();
                        break;

                    case "5":
                        Console.WriteLine("Exiting Application...");
                        return;

                    default:
                        Console.WriteLine("❌ Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}