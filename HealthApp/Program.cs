using System;
using Microsoft.Extensions.DependencyInjection;
using HealthApp;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Menus;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Databases;

var services = new ServiceCollection();

services.AddSingleton<PatientDb>();
services.AddSingleton<DoctorDb>();
services.AddSingleton<HealthRecordDB>();
services.AddSingleton<AppointmentDb>();

services.AddScoped<IPatientRepository, PatientRepository>();
services.AddScoped<IDoctorRepository, DoctorRepository>();
services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();
services.AddScoped<IAppointmentRepository, AppointmentRepository>();

services.AddScoped<IPatientService, PatientService>();
services.AddScoped<IDoctorService, DoctorService>();
services.AddScoped<IHealthRecordService, HealthRecordService>();
services.AddScoped<IAppointmentService, AppointmentService>();

services.AddScoped<PatientMenu>();
services.AddScoped<DoctorMenu>();
services.AddScoped<HealthRecordMenu>();
services.AddScoped<AppointmentMenu>();

var provider = services.BuildServiceProvider();

var patientMenu = provider.GetRequiredService<PatientMenu>();
var doctorMenu = provider.GetRequiredService<DoctorMenu>();
var healthRecordMenu = provider.GetRequiredService<HealthRecordMenu>();
var appointmentMenu = provider.GetRequiredService<AppointmentMenu>();

const string ContinueMessage = "\nPress any key to continue...";

bool exit = false;
while (!exit)
{
    Console.Clear();
    Console.WriteLine("\n==== Hospital Management System ====");
    Console.WriteLine("1. Register a new patient");
    Console.WriteLine("2. Add a new doctor");
    Console.WriteLine("3. Search doctors by specialisation");
    Console.WriteLine("4. Book an appointment for a patient");
    Console.WriteLine("5. View all appointments for a patient");
    Console.WriteLine("6. Confirm or cancel an appointment");
    Console.WriteLine("7. Add a health record after a completed appointment");
    Console.WriteLine("8. View health history for a patient");
    Console.WriteLine("9. Update patient record");
    Console.WriteLine("10. Update doctor record");
    Console.WriteLine("11. Update Health Record");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your choice: ");
    string ?input = Console.ReadLine();

    if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine("Invalid input. Please enter a number between 0 and 11.");
        continue;
    }

    if (choice < 0 || choice > 11)
    {
        Console.WriteLine("Invalid choice. Please select a valid option (0-11).");
        continue;
    }
    
    switch (choice)
    {
        case 1:
            Console.WriteLine($"\n{patientMenu.RegisterPatient()}");
            Console.Write(ContinueMessage);
            Console.ReadKey();
            break;
        case 2:
            Console.WriteLine($"\n{doctorMenu.AddDoctor()}");
            Console.Write(ContinueMessage);
            Console.ReadKey();
            break;
        case 3:
            List<Doctor> doctors = doctorMenu.SearchDoctorBySpecialisation();
            foreach (Doctor d in doctors)
            {
                Console.WriteLine(d);
            }
            Console.Write(ContinueMessage);
            Console.ReadKey();
            break;
        case 4:
            Console.WriteLine($"\n{appointmentMenu.BookAppointment()}");
            Console.Write(ContinueMessage);
            Console.ReadKey();
            break;
        case 5:
            appointmentMenu.ViewAppointments();
            Console.Write(ContinueMessage);
            Console.ReadKey();
            break;
        case 6:
            appointmentMenu.ConfirmCancelAppointment();
            Console.Write(ContinueMessage);
            Console.ReadKey();
            break;
        case 7:
            Console.WriteLine($"\n{healthRecordMenu.AddHealthRecord()}");
            Console.Write(ContinueMessage);
            Console.ReadKey();
            break;
        case 8:
            healthRecordMenu.ViewRecord();
            break;
        case 9:
            Console.WriteLine($"\nPatient details:\n{patientMenu.UpdatePatient()}");
            Console.Write(ContinueMessage);
            Console.ReadKey();
            break;
        case 10:
            Console.WriteLine($"\nDoctor details:\n{doctorMenu.UpdateDoctor()}");
            Console.Write(ContinueMessage);
            Console.ReadKey();
            break;
        case 11:
            Console.WriteLine($"\nHealth record details:\n{healthRecordMenu.UpdateHealthRecord()}");
            Console.Write(ContinueMessage);
            Console.ReadKey();
            break;
        case 0:
            exit = true;
            Console.WriteLine("Exiting program...");
            break;
    }
}

