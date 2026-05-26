using Microsoft.Extensions.DependencyInjection;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Menus;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Helpers;

var services = new ServiceCollection();

services.AddSingleton<DoctorDb>();
services.AddSingleton<AppointmentDb>();
services.AddSingleton<HealthRecordDb>();
services.AddSingleton<PatientDb>();
services.AddSingleton<IPatientRepository, PatientRepository>();
services.AddSingleton<IDoctorRepository, DoctorRepository>();
services.AddSingleton<IAppointmentRepository, AppointmentRepository>();
services.AddSingleton<IHealthRecordRepository, HealthRecordRepository>();

services.AddScoped<IPatientService, PatientService>();
services.AddScoped<IDoctorService, DoctorService>();
services.AddScoped<IAppointmentService, AppointmentService>();
services.AddScoped<IHealthRecordService, HealthRecordService>();

services.AddScoped<PatientMenu>();
services.AddScoped<DoctorMenu>();
services.AddScoped<AppointmentMenu>();
services.AddScoped<HealthRecordMenu>();

var provider = services.BuildServiceProvider();
var patientMenu = provider.GetRequiredService<PatientMenu>();
var doctorMenu = provider.GetRequiredService<DoctorMenu>();
var appointmentMenu = provider.GetRequiredService<AppointmentMenu>();
var healthRecordMenu = provider.GetRequiredService<HealthRecordMenu>();

bool running = true;
while (running)
{
    try
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.WriteLine("║           HealthAxis Patient Portal              ║");
        Console.WriteLine("╠══════════════════════════════════════════════════╣");
        Console.WriteLine("║  1. Register a new patient                       ║");
        Console.WriteLine("║  2. Add a new doctor                             ║");
        Console.WriteLine("║  3. Search doctors by specialisation             ║");
        Console.WriteLine("║  4. Book an appointment                          ║");
        Console.WriteLine("║  5. View all appointments for a patient          ║");
        Console.WriteLine("║  6. Update appointment status                    ║");
        Console.WriteLine("║  7. Add a health record after a consultation     ║");
        Console.WriteLine("║  8. View health history                          ║");
        Console.WriteLine("║  9. Go to detailed menus(Patient/Doctor)         ║");
        Console.WriteLine("║  0. Exit                                         ║");
        Console.WriteLine("╚══════════════════════════════════════════════════╝");
        Console.WriteLine("  Type 'back' anywhere to return to this menu");
        Console.Write("  Choose an option: ");

        switch (Console.ReadLine()?.Trim() ?? "")
        {
            case "1": patientMenu.RegisterPatient(); break;
            case "2": doctorMenu.AddDoctor(); break;
            case "3": doctorMenu.SearchBySpecialisation(); break;
            case "4": appointmentMenu.BookAppointment(); break;
            case "5": appointmentMenu.ViewPatientAppointments(); break;
            case "6": appointmentMenu.UpdateAppointmentMenu(); break;
            case "7": healthRecordMenu.AddHealthRecord(); break;
            case "8": healthRecordMenu.ViewRecord(); break;
            case "9": DetailedMenu(); break;
            case "0": Console.WriteLine("\n  Thank you for using HealthAxis. Goodbye!"); running = false; break;
            default: Console.WriteLine("  Invalid option. Enter a number between 0 and 9."); break;
        }
    }
    catch (ArgumentNullException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n {ex.Message}");
        Console.ResetColor();
        Console.WriteLine("  Press any key to continue...");
        Console.ReadKey();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{ex.Message}");
        Console.ResetColor();
        Console.WriteLine("  Press any key to continue...");
        Console.ReadKey();
    }

    void DetailedMenu()
    {
        while (true)
        {
            try
            { 
                Console.WriteLine("1.Patient Menu");
                Console.WriteLine("2.Doctor Menu ");
                Console.WriteLine("3.Back ");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        patientMenu.ViewPatientMenu();
                        break;

                    case "2":
                        doctorMenu.ShowMenu();
                        break;

                    case "3": return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("  Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("  Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}

[ExclueCodeFromCoverage]
public partial class program { }