using System;
using System.Collections.Generic;

namespace HealthcareApp
{
    public class HealthRecordMenu
    {
        private List<HealthRecord> records = new List<HealthRecord>();

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Healthcare Record Menu ---");
                Console.WriteLine("1. Add Health Record");
                Console.WriteLine("2. View All Records");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRecord();
                        break;

                    case "2":
                        ViewRecords();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void AddRecord()
        {
            HealthRecord record = new HealthRecord();

            Console.Write("Enter Patient Name: ");
            record.Patient = Console.ReadLine();

            Console.Write("Enter Doctor Name: ");
            record.Doctor = Console.ReadLine();

            Console.Write("Enter Visit Date (yyyy-mm-dd): ");
            record.VisitDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Diagnosis: ");
            record.Diagnosis = Console.ReadLine();

            Console.Write("Enter Prescription: ");
            record.Prescription = Console.ReadLine();

            Console.Write("Enter Doctor Notes: ");
            record.DoctorNotes = Console.ReadLine();

            records.Add(record);

            Console.WriteLine("✅ Record added successfully!");
        }

        private void ViewRecords()
        {
            Console.WriteLine("\n--- All Health Records ---");

            if (records.Count == 0)
            {
                Console.WriteLine("No records found.");
                return;
            }

            foreach (var record in records)
            {
                Console.WriteLine(record.GetSummary());
            }
        }
    }
}
