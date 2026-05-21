using System;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    public class AppointmentMenu
    {
        private readonly IAppointmentService _service;

        public AppointmentMenu(IAppointmentService service)
        {
            _service = service;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n======= APPOINTMENT MENU =======");
                Console.WriteLine("1. Book Appointment");
                Console.WriteLine("2. Cancel Appointment");
                Console.WriteLine("3. View By Patient");
                Console.WriteLine("4. View By Doctor");
                Console.WriteLine("5. View Upcoming");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: Book(); break;
                    case 2: Cancel(); break;
                    case 3: ByPatient(); break;
                    case 4: ByDoctor(); break;
                    case 5: Upcoming(); break;
                    case 6: return;
                }
            }
        }

        private void Book()
        {
            Console.Write("Enter PatientId: ");
            int pId = int.Parse(Console.ReadLine());

            Console.Write("Enter DoctorId: ");
            int dId = int.Parse(Console.ReadLine());

            Console.Write("Enter Date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Time Slot: ");
            string slot = Console.ReadLine();

            var patient = new Patient { PatientId = pId };
            var doctor = new Doctor { DoctorId = dId };

            var appointment = _service.BookAppointment(patient, doctor, date, slot);

            Console.WriteLine("✅ Appointment Booked");
            Console.WriteLine(appointment.GetDetails());
        }

        private void Cancel()
        {
            Console.Write("Enter AppointmentId: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Reason: ");
            string reason = Console.ReadLine();

            _service.CancelAppointment(id, reason);

            Console.WriteLine("✅ Appointment Cancelled");
        }

        private void ByPatient()
        {
            Console.Write("Enter PatientId: ");
            int id = int.Parse(Console.ReadLine());

            var list = _service.GetAppointmentsByPatient(id);

            foreach (var a in list)
            {
                Console.WriteLine(a.GetDetails());
            }
        }

        private void ByDoctor()
        {
            Console.Write("Enter DoctorId: ");
            int id = int.Parse(Console.ReadLine());

            var list = _service.GetAppointmentsByDoctor(id);

            foreach (var a in list)
            {
                Console.WriteLine(a.GetDetails());
            }
        }

        private void Upcoming()
        {
            var list = _service.GetUpcomingAppointments();

            foreach (var a in list)
            {
                Console.WriteLine(a.GetDetails());
            }
        }
    }
}