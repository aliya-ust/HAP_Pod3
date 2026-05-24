using Microsoft.Extensions.DependencyInjection;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Menus;

namespace HealthApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()

                .AddSingleton<PatientDb>()
                .AddSingleton<DoctorDb>()
                .AddSingleton<HealthRecordDb>()
                .AddSingleton<AppointmentDb>()

                .AddScoped<IPatientRepository, PatientRepository>()
                .AddScoped<IDoctorRepository, DoctorRepository>()
                .AddScoped<IHealthRecordRepository, HealthRecordRepository>()
                .AddScoped<IAppointmentRepository, AppointmentRepository>()

                .AddScoped<IPatientService, PatientService>()
                .AddScoped<IDoctorService, DoctorService>()
                .AddScoped<IHealthRecordService, HealthRecordService>()
                .AddScoped<IAppointmentService, AppointmentService>()

                .AddScoped<PatientMenu>()
                .AddScoped<DoctorMenu>()
                .AddScoped<HealthRecordMenu>()
                .AddScoped<AppointmentMenu>()

                .BuildServiceProvider();

            ShowMainMenu(serviceProvider);
        }

        static void ShowMainMenu(ServiceProvider serviceProvider)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("HEALTH MANAGEMENT SYSTEM");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Patient Menu");
                Console.WriteLine("2. Doctor Menu");
                Console.WriteLine("3. Appointment Menu");
                Console.WriteLine("4. HealthRecord Menu");
                Console.WriteLine("5. Exit");
                Console.WriteLine("=================================");

                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        serviceProvider.GetRequiredService<PatientMenu>().PatientRegisteration();
                        break;

                    case 2:
                        serviceProvider.GetRequiredService<DoctorMenu>().ShowMenu();
                        break;

                    case 3:
                        serviceProvider.GetRequiredService<AppointmentMenu>().Show();
                        break;

                    case 4:
                        serviceProvider.GetRequiredService<HealthRecordMenu>().ShowMenu();
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid choice");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}