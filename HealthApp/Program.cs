using System;
using Microsoft.Extensions.DependencyInjection;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Menus;
using HealthApp.ConsoleApp.Databases;

// Register every dependency 
var services = new ServiceCollection();

services.AddSingleton<DoctorDb>();
services.AddSingleton<PatientDb>();
services.AddSingleton<AppointmentDb>();
services.AddSingleton<HealthRecordDB>();

services.AddSingleton<IPatientRepository, PatientRepository>();
services.AddSingleton<IDoctorRepository, DoctorRepository>();
services.AddSingleton<IAppointmentRepository, AppointmentRepository>();
services.AddSingleton<IHealthRecordRepository, HealthRecordRepository>();

// Services (business logic — interface + implementation)
services.AddScoped<IPatientService, PatientService>();
services.AddScoped<IDoctorService, DoctorService>();
services.AddScoped<IAppointmentService, AppointmentService>();
services.AddScoped<IHealthRecordService, HealthRecordService>();

// Menus 
services.AddScoped<PatientMenu>();
services.AddScoped<DoctorMenu>();
services.AddScoped<AppointmentMenu>();
services.AddScoped<HealthRecordMenu>();

// Build the service provider
var provider = services.BuildServiceProvider();
var patientMenu = provider.GetRequiredService<PatientMenu>();
var doctorMenu = provider.GetRequiredService<DoctorMenu>();
var appointmentMenu = provider.GetRequiredService<AppointmentMenu>();
var healthRecordMenu = provider.GetRequiredService<HealthRecordMenu>();

bool running = true;

while (running)
{
    Console.WriteLine("===================================================");
    Console.WriteLine("            HEALTH CARE MANAGEMENT");
    Console.WriteLine("===================================================");
    Console.WriteLine(" 1. Register a new patient");
    Console.WriteLine(" 2. Add a new doctor     ");
    Console.WriteLine(" 3. Search doctors by specialisation");
    Console.WriteLine(" 4. Book an appointment");
    Console.WriteLine(" 5. View all appointments for a patient");
    Console.WriteLine(" 6. Confirm or cancel an appointment");
    Console.WriteLine(" 7. Add a health record after a consultation");
    Console.WriteLine(" 8. View health history for a patient");
    Console.WriteLine(" 0. Exit");
    Console.WriteLine(" ══════════════════════════════════════════════════");
    Console.Write("  Choose an option: ");

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            patientMenu.PatientRegisteration();
            break;

        case "2":
            doctorMenu.AddDoctor();
            break;

        case "3":
            doctorMenu.SearchBySpecialisation();
            break;

        case "4":
            appointmentMenu.BookAppointment();
            break;

        case "5":
            appointmentMenu.ViewPatientAppointments();
            break;

        case "6":
            appointmentMenu.ConfirmOrCancel();
            break;

        case "7":
            Console.WriteLine();
            break;

        case "8":
            healthRecordMenu.Show();
            break;
        
        case "0":
            Console.WriteLine("\n  Thank you for using HealthAxis.");
            running = false;
            break;

        default:
            Console.WriteLine("   Invalid option. Enter a number between 0 and 8.");
            break;
    }
}