using System;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.ConsoleApp.Menus
{
    public class AppointmentMenu
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public AppointmentMenu(
            IAppointmentService appointmentService,
            IPatientService patientService,
            IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===================================");
                Console.WriteLine("Appointment Menu");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Book Appointment");
                Console.WriteLine("2. View Appointments");
                Console.WriteLine("3. Cancel Appointment");
                Console.WriteLine("4. Back");

                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input");
                    InputValidator.Pause();
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            BookAppointment();
                            break;

                        case 2:
                            ViewPatientAppointments();
                            break;

                        case 3:
                            CancelAppointment();
                            break;

                        case 4:
                            return;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                InputValidator.Pause();
            }
        }

        public void BookAppointment()
        {
            if (!InputValidator.TryReadPositiveInt("Patient ID: ", out int patientId))
                return;

            var patient = _patientService.GetPatientById(patientId);

            if (!InputValidator.TryReadPositiveInt("Doctor ID: ", out int doctorId))
                return;

            var doctor = _doctorService.GetDoctorById(doctorId);

            if (!doctor.IsActive)
            {
                Console.WriteLine("Doctor is not active");
                return;
            }

            if (!InputValidator.TryReadFutureDate("Date (dd/MM/yyyy): ", out DateTime date))
                return;

            Console.WriteLine("Available slots:");
            Console.WriteLine("1. 09:00 AM");
            Console.WriteLine("2. 10:00 AM");
            Console.WriteLine("3. 11:00 AM");
            Console.WriteLine("4. 02:00 PM");
            Console.WriteLine("5. 03:00 PM");
            Console.WriteLine("6. 04:00 PM");

            Console.Write("Select slot (1-6): ");
            string input = Console.ReadLine();

            string slot = input switch
            {
                "1" => "09:00 AM",
                "2" => "10:00 AM",
                "3" => "11:00 AM",
                "4" => "02:00 PM",
                "5" => "03:00 PM",
                "6" => "04:00 PM",
                _ => null
            };

            if (slot == null)
            {
                Console.WriteLine("Invalid slot selection");
                return;
            }

            var appt = _appointmentService.BookAppointment(patient, doctor, date, slot);

            Console.WriteLine("Appointment booked successfully");
            Console.WriteLine(appt.GetDetails());
        }

        public void ViewPatientAppointments()
        {
            if (!InputValidator.TryReadPositiveInt("Patient ID: ", out int patientId))
                return;

            var list = _appointmentService.GetAppointmentsByPatient(patientId);

            if (list.Count == 0)
            {
                Console.WriteLine("No appointments found");
                return;
            }

            foreach (var a in list)
            {
                Console.WriteLine(a.GetDetails());
            }
        }

        public void CancelAppointment()
        {
            if (!InputValidator.TryReadPositiveInt("Appointment ID: ", out int id))
                return;

            if (!InputValidator.TryReadString("Enter reason: ", out string reason))
                return;

            _appointmentService.CancelAppointment(id, reason);

            Console.WriteLine("Appointment cancelled successfully");
        }
    }
}