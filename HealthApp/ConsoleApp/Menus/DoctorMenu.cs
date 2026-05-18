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
            System.Console.WriteLine("\n===== DOCTOR MENU =====");
            System.Console.WriteLine("1. Add New Doctor");
            System.Console.WriteLine("2. Search Doctors by Specialisation");
            System.Console.WriteLine("3. Exit");

            System.Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(System.Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddDoctor();
                    break;

                case 2:
                    SearchDoctor();
                    break;
                case 3:
                    System.Console.WriteLine("Exiting...");`
                    break;

                default:
                    System.Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 3);
    }

    private void AddDoctor()
    {
        Doctor doctor = new Doctor();

        System.Console.Write("Enter Doctor ID: ");
        doctor.DoctorId = Convert.ToInt32(System.Console.ReadLine());

        System.Console.Write("Enter Full Name: ");
        doctor.FullName = System.Console.ReadLine() ?? "";

        System.Console.Write("Enter Specialisation: ");
        doctor.Specialisation = System.Console.ReadLine() ?? "";

        System.Console.Write("Enter Years Of Experience: ");
        doctor.YearsOfExperience = Convert.ToInt32(System.Console.ReadLine());

        System.Console.Write("Enter Consultation Fee: ");
        doctor.ConsultationFee = Convert.ToDecimal(System.Console.ReadLine());

        doctor.IsActive = true;

        // sample available dates
        doctor.Appointments.Add(DateTime.Today);
        doctor.Appointments.Add(DateTime.Today.AddDays(1));
        doctor.Appointments.Add(DateTime.Today.AddDays(2));

        doctors.Add(doctor);

        System.Console.WriteLine("Doctor added successfully!");
    }

    private void SearchDoctor()
    {
        System.Console.Write("Enter specialisation to search: ");
        string search = System.Console.ReadLine() ?? "";

        bool found = false;

        foreach (Doctor doctor in doctors)
        {
            if (doctor.Specialisation.Equals(search, StringComparison.OrdinalIgnoreCase))
            {
                System.Console.WriteLine("\nDoctor Found:");
                System.Console.WriteLine(doctor.GetDoctorDetails());
                System.Console.WriteLine(doctor.GetScheduleSummary());

                System.Console.WriteLine("Available Today: " +
                    (doctor.IsAvailable(DateTime.Today) ? "Yes" : "No"));

                found = true;
            }
        }

        if (!found)
        {
            System.Console.WriteLine("No doctor found with that specialisation.");
        }
    }
}