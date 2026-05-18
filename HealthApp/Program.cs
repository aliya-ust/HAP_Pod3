
using System;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Menus;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create service collection
        var services = new ServiceCollection();

        // 2. Register dependencies
        services.AddScoped<IPatientRepo, PatientRepo>();
        services.AddScoped<IPatientService, PatientService>();

        services.AddScoped<PatientMenu>();
        services.AddScoped<DoctorMenu>();

        // 3. Build provider
        var provider = services.BuildServiceProvider();

        // 4. Resolve menus
        var patientMenu = provider.GetRequiredService<PatientMenu>();
        var doctorMenu = provider.GetRequiredService<DoctorMenu>();

        Console.WriteLine("=====================");
        Console.WriteLine("HEALTH CARE MANAGEMENT");
        Console.WriteLine("=====================");

        while (true)
        {
            Console.WriteLine("1. Patient Registration");
            Console.WriteLine("2. Doctor");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Patient Registration selected.");
                    patientMenu.Show();
                    break;

                case "2":
                    Console.WriteLine("Doctor selected.");
                    doctorMenu.ShowMenu();
                    break;

                case "3":
                    Console.WriteLine("Exiting the application.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
