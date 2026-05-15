using System;
using System.Collections.Generic;

public class DoctorMenu
{
    private List<Doctor> doctors = new List<Doctor>();

    public void ShowMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== DOCTOR MENU =====");
            Console.WriteLine("1. Add New Doctor");
            Console.WriteLine("2. Search Doctors by Specialisation");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddDoctor();
                    break;

                case 2:
                    SearchDoctor();
                    break;

                case 3:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 3);
    }

    private void AddDoctor()
    {
        Doctor doctor = new Doctor();

        Console.Write("Enter Doctor ID: ");
        doctor.DoctorId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Full Name: ");
        doctor.FullName = Console.ReadLine() ?? "";

        Console.Write("Enter Specialisation: ");
        doctor.Specialisation = Console.ReadLine() ?? "";

        Console.Write("Enter Years Of Experience: ");
        doctor.YearsOfExperience = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Consultation Fee: ");
        doctor.ConsultationFee = Convert.ToDecimal(Console.ReadLine());

        doctor.IsActive = true;

        // sample available dates
        doctor.Appointments.Add(DateTime.Today);
        doctor.Appointments.Add(DateTime.Today.AddDays(1));
        doctor.Appointments.Add(DateTime.Today.AddDays(2));

        doctors.Add(doctor);

        Console.WriteLine("Doctor added successfully!");
    }

    private void SearchDoctor()
    {
        Console.Write("Enter specialisation to search: ");
        string search = Console.ReadLine() ?? "";

        bool found = false;

        foreach (Doctor doctor in doctors)
        {
            if (doctor.Specialisation.Equals(search, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nDoctor Found:");
                Console.WriteLine(doctor.GetDoctorDetails());
                Console.WriteLine(doctor.GetScheduleSummary());

                Console.WriteLine("Available Today: " +
                    (doctor.IsAvailable(DateTime.Today) ? "Yes" : "No"));

                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No doctor found with that specialisation.");
        }
    }
}