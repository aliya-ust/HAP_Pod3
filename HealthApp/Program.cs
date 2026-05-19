using System;
using Microsoft.Extensions.DependencyInjection;
using HealthApp;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Menus;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Models;

// 1. Create service collection
var services = new ServiceCollection();
// 2. Register dependencies
services.AddScoped<IPatientRepository, PatientRepository>();
services.AddScoped<IPatientService, PatientService>();
services.AddScoped<PatientMenu>();
services.AddScoped<DoctorMenu>();
// 3. Build provider
var provider = services.BuildServiceProvider();
// 4. Resolve menus
var patientMenu = provider.GetRequiredService<PatientMenu>();
var doctorMenu = provider.GetRequiredService<DoctorMenu>();

bool exit = false;
while (!exit)
{
    Console.WriteLine("\n==== Hospital Management System ====");
    Console.WriteLine("1. Register a new patient");
    Console.WriteLine("2. Add a new doctor");
    Console.WriteLine("3. Search doctors by specialisation");
    Console.WriteLine("4. Book an appointment for a patient");
    Console.WriteLine("5. View all appointments for a patient");
    Console.WriteLine("6. Confirm or cancel an appointment");
    Console.WriteLine("7. Add a health record after a completed appointment");
    Console.WriteLine("8. View health history for a patient");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");
    string ?input = Console.ReadLine();

    // Input validation
    if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine("Invalid input. Please enter a number between 0 and 8.");
        continue;
    }

    if (choice < 0 || choice > 8)
    {
        Console.WriteLine("Invalid choice. Please select a valid option (0-8).");
        continue;
    }
    
    switch (choice)
    {
        case 1:
            Console.WriteLine(patientMenu.RegisterPatient());
            break;
        case 2:
            Console.WriteLine(doctorMenu.AddDoctor());
            break;
        case 3:
            List<Doctor> doctors = doctorMenu.SearchDoctorBySpecialisation();
            foreach (Doctor d in doctors)
            {
                Console.WriteLine(d);
            }
            break;
        case 4:
            // Book an appointment for a patient
            break;
        case 5:
            // View all appointments for a patient
            break;
        case 6:
            // Confirm or cancel an appointment
            break;
        case 7:
            // Add a health record after a completed appointment
            break;
        case 8:
            // View health history for a patient
            break;
        case 0:
            exit = true;
            Console.WriteLine("Exiting program...");
            break;
    }
}

