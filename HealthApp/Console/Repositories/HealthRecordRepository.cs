using System;
using System.Collections.Generic;
using HealthcareApp.Models;
using HealthcareApp.Data;

namespace HealthcareApp.Repository
{
    public class HealthRecordRepository : IHealthRecordRepository
    {
        public void Add()
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

            Database.Records.Add(record);

            Console.WriteLine("Record added successfully!");
        }

        public void Delete(int index)
        {
            if (index >= 0 && index < Database.Records.Count)
            {
                Database.Records.RemoveAt(index);
                Console.WriteLine("Record deleted");
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }
        public void Update(int index)
        {
            if (index >= 0 && index < Database.Records.Count)
            {
                HealthRecord record = Database.Records[index];

                Console.Write("Update Patient Name: ");
                record.Patient = Console.ReadLine();

                Console.Write("Update Doctor Name: ");
                record.Doctor = Console.ReadLine();

                Console.Write("Update Visit Date (yyyy-mm-dd): ");
                record.VisitDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Update Diagnosis: ");
                record.Diagnosis = Console.ReadLine();

                Console.Write("Update Prescription: ");
                record.Prescription = Console.ReadLine();

                Console.Write("Update Doctor Notes: ");
                record.DoctorNotes = Console.ReadLine();

                Console.WriteLine(" Record updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }

        public List<HealthRecord> GetAll()
        {
            return Database.Records;
        }
    }
}