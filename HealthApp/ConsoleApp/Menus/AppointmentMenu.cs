using System;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Models;

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
                Console.WriteLine("===================================");

                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadKey();
                    continue;
                }

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
                }

                InputValidator.Pause();
            }
        }

        public void BookAppointment()
        {
            if (!InputValidator.TryReadPositiveInt("Patient ID: ", out int patientId))
                return;

            Patient patient;
            try
            {
                patient = _patientService.GetPatientById(patientId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (!InputValidator.TryReadPositiveInt("Doctor ID: ", out int doctorId))
                return;

            Doctor doctor;
            try
            {
                doctor = _doctorService.GetDoctorById(doctorId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (!doctor.IsActive)
            {
                Console.WriteLine("Doctor is not active");
                return;
            }

            if (!InputValidator.TryReadFutureDate("Date (dd/MM/yyyy): ", out DateTime date))
                return;

            Console.WriteLine("  Available time slots:");
            Console.WriteLine("    [1] 09:00 AM    [2] 10:00 AM    [3] 11:00 AM");
            Console.WriteLine("    [4] 02:00 PM    [5] 03:00 PM    [6] 04:00 PM");
            Console.Write("Enter Time Slot: ");
            string slot = Console.ReadLine();

            try
            {
                var appt = _appointmentService.BookAppointment(patient, doctor, date, slot);
                Console.WriteLine("Appointment booked successfully");
                Console.WriteLine(appt.GetDetails());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ViewPatientAppointments()
        {
            if (!InputValidator.TryReadPositiveInt("Patient ID: ", out int patientId))
                return;

            try
            {
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CancelAppointment()
        {
            if (!InputValidator.TryReadPositiveInt("Appointment ID: ", out int id))
                return;

            if (!InputValidator.TryReadString("Enter reason: ", out string reason))
                return;

            try
            {
                _appointmentService.CancelAppointment(id, reason);
                Console.WriteLine("Appointment cancelled successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
