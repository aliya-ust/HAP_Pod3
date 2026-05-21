using System;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    public class DoctorMenu
    {
        private readonly IDoctorService _service;

        public DoctorMenu(IDoctorService service)
        {
            _service = service;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n========== DOCTOR MENU ==========");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Update Doctor");
                Console.WriteLine("3. Get Doctor By Id");
                Console.WriteLine("4. Delete Doctor");
                Console.WriteLine("5. View All Doctors");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddDoctor(); break;
                    case 2: UpdateDoctor(); break;
                    case 3: GetDoctor(); break;
                    case 4: DeleteDoctor(); break;
                    case 5: ViewAll(); break;
                    case 6: return;
                }
            }
        }

        private void AddDoctor()
        {
            Doctor d = new Doctor();

            Console.Write("Enter Name: ");
            d.FullName = Console.ReadLine();

            Console.Write("Enter Specialisation: ");
            d.Specialisation = Console.ReadLine();

            Console.Write("Enter Experience: ");
            d.YearsOfExperience = int.Parse(Console.ReadLine());

            Console.Write("Enter Consultation Fee: ");
            d.ConsultationFee = decimal.Parse(Console.ReadLine());

            _service.AddDoctor(d);

            Console.WriteLine("✅ Doctor Added Successfully");
        }

        private void UpdateDoctor()
        {
            Console.Write("Enter Doctor ID: ");
            int id = int.Parse(Console.ReadLine());

            var d = _service.GetDoctorById(id);

            Console.Write("Enter New Name: ");
            d.FullName = Console.ReadLine();

            Console.Write("Enter New Specialisation: ");
            d.Specialisation = Console.ReadLine();

            _service.UpdateDoctor(d);

            Console.WriteLine("✅ Doctor Updated");
        }

        private void GetDoctor()
        {
            Console.Write("Enter Doctor ID: ");
            int id = int.Parse(Console.ReadLine());

            var d = _service.GetDoctorById(id);

            Console.WriteLine($"Name: {d.FullName}, Spec: {d.Specialisation}");
        }

        private void DeleteDoctor()
        {
            Console.Write("Enter Doctor ID: ");
            int id = int.Parse(Console.ReadLine());

            _service.DeleteDoctor(id);

            Console.WriteLine("✅ Doctor Deleted");
        }

        private void ViewAll()
        {
            var list = _service.GetAllDoctors();

            foreach (var d in list)
            {
                Console.WriteLine($"{d.DoctorId} - {d.FullName} - {d.Specialisation}");
            }
        }
    }
}