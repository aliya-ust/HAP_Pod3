using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Menu;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Services;
using System;


    public class Program
   {
    public static void Main(string[] args)
    {

        Console.WriteLine("=====================");
        Console.WriteLine("HEALTH CARE MANAGEMNT");
        Console.WriteLine("=====================");
        Console.WriteLine("1. Patient Registration");
        Console.WriteLine("2. Exit");

        while (true)
        {
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    Console.WriteLine("Patient Registration selected.");
                    IPatientRepo repo = new PatientRepo();
                    IPatientService service = new PatientService(repo);
                    PatientMenu menu = new PatientMenu(service);
                    menu.Show();

                    break;

                case "2":
                    Console.WriteLine("Exiting the application.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

                
}

