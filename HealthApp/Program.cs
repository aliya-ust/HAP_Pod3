// using System;
// using Microsoft.Extensions.DependencyInjection;
// using HealthApp;
// using HealthApp.ConsoleApp.Interfaces;
// using HealthApp.ConsoleApp.Services;
// using HealthApp.ConsoleApp.Menus;
// using HealthApp.ConsoleApp.Repositories;

//         // 1. Create service collection
//         var services = new ServiceCollection();

//         // 2. Register dependencies
//         services.AddScoped<IPatientRepository, PatientRepository>();
//         services.AddScoped<IPatientService, PatientService>();

//         services.AddScoped<PatientMenu>();
//         services.AddScoped<DoctorMenu>();

//         // 3. Build provider
//         var provider = services.BuildServiceProvider();

//         // 4. Resolve menus
//         var patientMenu = provider.GetRequiredService<PatientMenu>();
//         var doctorMenu = provider.GetRequiredService<DoctorMenu>();


//         Console.WriteLine("=====================");
//         Console.WriteLine("HEALTH CARE MANAGEMENT");
//         Console.WriteLine("=====================");

//         while (true)
//         {
//             Console.WriteLine("1. Patient Registration");
//             Console.WriteLine("2. Doctor");
//             Console.WriteLine("3. Exit");

//             Console.Write("Enter your choice: ");
//             var choice = Console.ReadLine();

//             switch (choice)
//             {
//                 case "1":
//                     Console.WriteLine("Patient Registration selected.");
//                     patientMenu.Show();
//                     break;

//                 case "2":
//                     Console.WriteLine("Doctor selected.");
//                     doctorMenu.ShowMenu();
//                     break;

//                 case "3":
//                     Console.WriteLine("Exiting the application.");
//                     return;

//                 default:
//                     Console.WriteLine("Invalid choice. Please try again.");
//                     break;
//             }
//         }
using System;
using Microsoft.Extensions.DependencyInjection;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Menus;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Databases;

// ════════════════════════════════════════════════════════════════════════════════
//  HealthAxis — Sprint 1 Console App
//  Pure C#, no database, no web framework.
//  All data lives in-memory (List<T> inside each repository).
//  DI is wired here; menus are resolved from the container.
// ════════════════════════════════════════════════════════════════════════════════

// ── 1. Register every dependency ────────────────────────────────────────────────
var services = new ServiceCollection();

// Repositories (in-memory List<T> stores — swapped for EF Core in Sprint 2)
services.AddSingleton<DoctorDb>();
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

// Menus (thin UI layer — injected with their required services)
services.AddScoped<PatientMenu>();
services.AddScoped<DoctorMenu>();
services.AddScoped<AppointmentMenu>();
services.AddScoped<HealthRecordMenu>();

// ── 2. Build the service provider ───────────────────────────────────────────────
var provider = services.BuildServiceProvider();

// ── 3. Seed three sample doctors (matches the original Program.cs) ───────────────
//    Resolved from DI so the seeded data goes into the singleton repository
// var doctorService = provider.GetRequiredService<IDoctorService>();

// doctorService.AddDoctor(new Doctor
// {
//     DoctorId = 1, FullName = "Arjun Mehta",
//     Specialisation = "General Physician", YearsOfExperience = 10,
//     ConsultationFee = 500, IsActive = true
// });
// doctorService.AddDoctor(new Doctor
// {
//     DoctorId = 2, FullName = "Priya Nair",
//     Specialisation = "Cardiology", YearsOfExperience = 15,
//     ConsultationFee = 1200, IsActive = true
// });
// doctorService.AddDoctor(new Doctor
// {
//     DoctorId = 3, FullName = "Deepa Krishnan",
//     Specialisation = "Psychiatry", YearsOfExperience = 8,
//     ConsultationFee = 900, IsActive = true
// });

// ── 4. Resolve menus once (Scoped — same scope for the whole session) ────────────
var patientMenu = provider.GetRequiredService<PatientMenu>();
var doctorMenu = provider.GetRequiredService<DoctorMenu>();
var appointmentMenu = provider.GetRequiredService<AppointmentMenu>();
var healthRecordMenu = provider.GetRequiredService<HealthRecordMenu>();

// ════════════════════════════════════════════════════════════════════════════════
//  5. Main menu loop — 8 options as specified in s.pdf
// ════════════════════════════════════════════════════════════════════════════════

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("╔══════════════════════════════════════════════════╗");
    Console.WriteLine("║           HealthAxis Patient Portal              ║");
    Console.WriteLine("║                  — Sprint 1 —                   ║");
    Console.WriteLine("╠══════════════════════════════════════════════════╣");
    Console.WriteLine("║  1. Register a new patient                       ║");
    Console.WriteLine("║  2. Add a new doctor                             ║");
    Console.WriteLine("║  3. Search doctors by specialisation             ║");
    Console.WriteLine("║  4. Book an appointment                          ║");
    Console.WriteLine("║  5. View all appointments for a patient          ║");
    Console.WriteLine("║  6. Confirm or cancel an appointment             ║");
    Console.WriteLine("║  7. Add a health record after a consultation     ║");
    Console.WriteLine("║  8. View health history for a patient            ║");
    Console.WriteLine("║  0. Exit                                         ║");
    Console.WriteLine("╚══════════════════════════════════════════════════╝");
    Console.Write("  Choose an option: ");

    string input = Console.ReadLine()?.Trim() ?? "";

    switch (input)
    {
        // ── Patient ───────────────────────────────────────────────────────────
        case "1":
            patientMenu.RegisterPatient();
            break;

        // ── Doctor ────────────────────────────────────────────────────────────
        case "2":
            doctorMenu.AddDoctor();
            break;

        // ── Doctor search ─────────────────────────────────────────────────────
        case "3":
            doctorMenu.SearchBySpecialisation();
            break;

        // ── Appointment ───────────────────────────────────────────────────────
        case "4":
            appointmentMenu.BookAppointment();
            break;
        case "5":
            appointmentMenu.ViewPatientAppointments();
            break;
        case "6":
            appointmentMenu.ConfirmOrCancel();
            break;

        // ── Health records ────────────────────────────────────────────────────
        case "7":
        case "8":
            healthRecordMenu.Show();
            break;

        // ── Exit ──────────────────────────────────────────────────────────────
        case "0":
            Console.WriteLine("\n  Thank you for using HealthAxis. Goodbye!");
            running = false;
            break;

        default:
            Console.WriteLine("  ✖  Invalid option. Enter a number between 0 and 8.");
            break;
    }
}