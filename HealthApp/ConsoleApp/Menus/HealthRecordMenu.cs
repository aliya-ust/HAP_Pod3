using System;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    public class HealthRecordMenu
    {
        private readonly IHealthRecordService _service;

        public HealthRecordMenu(IHealthRecordService service)
        {
            _service = service;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n======= HEALTH RECORD MENU =======");
                Console.WriteLine("1. Add Record");
                Console.WriteLine("2. View By Patient");
                Console.WriteLine("3. View By Doctor");
                Console.WriteLine("4. Delete Record");
                Console.WriteLine("5. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: Add(); break;
                    case 2: ByPatient(); break;
                    case 3: ByDoctor(); break;
                    case 4: Delete(); break;
                    case 5: return;
                }
            }
        }

        private void Add()
        {
            Console.Write("Enter PatientId: ");
            int pId = int.Parse(Console.ReadLine());

            Console.Write("Enter DoctorId: ");
            int dId = int.Parse(Console.ReadLine());

            Console.Write("Enter Diagnosis: ");
            string diagnosis = Console.ReadLine();

            Console.Write("Enter Prescription: ");
            string prescription = Console.ReadLine();

            var dto = new CreateHealthRecordRequest
            {
                PatientId = pId,
                DoctorId = dId,
                Diagnosis = diagnosis,
                Prescription = prescription,
                VisitDate = DateTime.Now
            };

            _service.AddRecord(dto);

            Console.WriteLine("✅ Record Added");
        }

        private void ByPatient()
        {
            Console.Write("Enter PatientId: ");
            int id = int.Parse(Console.ReadLine());

            var list = _service.GetByPatientIdOrderByVisitDateDesc(id);

            foreach (var r in list)
            {
                Console.WriteLine($"{r.Diagnosis} - {r.VisitDate}");
            }
        }

        private void ByDoctor()
        {
            Console.Write("Enter DoctorId: ");
            int id = int.Parse(Console.ReadLine());

            var list = _service.GetByDoctorIdOrderByVisitDateDesc(id);

            foreach (var r in list)
            {
                Console.WriteLine($"{r.Diagnosis} - {r.VisitDate}");
            }
        }

        private void Delete()
        {
            Console.Write("Enter RecordId: ");
            int id = int.Parse(Console.ReadLine());

            _service.Delete(id);

            Console.WriteLine("✅ Record Deleted");
        }
    }
}