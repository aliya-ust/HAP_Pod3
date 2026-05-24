
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    public class AppointmentMenu
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public AppointmentMenu
        (
            IAppointmentService appointmentService,
            IPatientService patientService,
            IDoctorService doctorService
        )
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        // ===============================
        // MAIN MENU 
        // ===============================
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("APPOINTMENT MENU");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Book Appointment");
                Console.WriteLine("2. View Patient Appointments");
                Console.WriteLine("3. Confirm / Cancel Appointment");
                Console.WriteLine("4. Back");
                Console.WriteLine("========================================");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        BookAppointment();
                        break;
                    case "2":
                        ViewPatientAppointments();
                        break;
                    case "3":
                        ConfirmOrCancel();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        InputValidator.Pause();
                        break;
                }
            }
        }

        // ===============================
        // BOOK APPOINTMENT
        // ===============================
        public void BookAppointment()
        { 
            PrintHeader("BOOK APPOINTMENT");

            Patient patient;

            while (true)
            {
                if (!InputValidator.TryReadPositiveInt("Enter Patient ID : ", out int patientId))
                {
                    PrintError("Invalid Patient ID.");
                    continue;
                }

                patient = _patientService.GetPatientById(patientId);

                if (patient == null)
                {
                    PrintError($"Patient ID {patientId} not found.");
                    continue;
                }

                Console.WriteLine($"\nPatient Found : {patient.Name}");
                break;
            }

            //Display doctors

            Console.WriteLine("\nAVAILABLE DOCTORS");
            Console.WriteLine("----------------------------------------------------------");

            foreach (Doctor doc in _doctorService.GetAllDoctors())
            {
                string status = doc.IsActive ? "ACTIVE" : "INACTIVE";

                Console.WriteLine(
                    $"ID : {doc.DoctorId} | {doc.FullName} | {doc.Specialisation} | " +
                    $"Fee : Rs.{doc.ConsultationFee} | {doc.YearsOfExperience} Years Exp | {status}"
                );
            }

            Console.WriteLine("----------------------------------------------------------");

            Doctor doctor;

            while (true)
            {
                if (!InputValidator.TryReadPositiveInt("\nEnter Doctor ID : ", out int doctorId))
                {
                    PrintError("Invalid Doctor ID.");
                    continue;
                }

                doctor = _doctorService.GetByDoctorId(doctorId);

                if (doctor == null)
                {
                    PrintError("Doctor not found.");
                    continue;
                }

                if (!doctor.IsActive)
                {
                    PrintError($"Dr. {doctor.FullName} is currently inactive.");
                    continue;
                }

                Console.WriteLine($"\nDoctor Selected : {doctor.FullName}");
                break;
            }

            //Display available days

            Console.WriteLine("\nAVAILABLE DAYS");

            for (int i = 0; i < doctor.AvailableDates.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {doctor.AvailableDates[i]:dd MMM yyyy}");
            }

            DateTime selectedDate;

            while (true)
            {
                if (!InputValidator.TryReadPositiveInt("\nChoose Date (1, 2, ...): ", out int dateChoice))
                {
                    PrintError("Invalid choice.");
                    continue;
                }

                if (dateChoice < 1 || dateChoice > doctor.AvailableDates.Count)
                {
                    PrintError("Please select a valid option.");
                    continue;
                }

                selectedDate = doctor.AvailableDates[dateChoice - 1];
                break;
            }

            List<string> bookedSlots = _appointmentService
                .GetAppointmentsByDoctor(doctor.DoctorId)
                .Where(a =>
                    a.ScheduledDate.Date == selectedDate.Date &&
                    a.Status != AppointmentStatus.Cancelled)
                .Select(a => a.TimeSlot)
                .ToList();

            List<string> availableSlots = doctor.AvailableSlots
                .Except(bookedSlots)
                .ToList();

            if (availableSlots.Count == 0)
            {
                PrintError("No slots available for selected date.");
                InputValidator.Pause();
                return;
            }

            Console.WriteLine("\nAVAILABLE SLOTS");

            for (int i = 0; i < availableSlots.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableSlots[i]}");
            }

            string selectedSlot;

            while (true)
            {
                if (!InputValidator.TryReadPositiveInt("\nChoose Slot : ", out int slotChoice))
                {
                    PrintError("Invalid slot.");
                    continue;
                }

                if (slotChoice < 1 || slotChoice > availableSlots.Count)
                {
                    PrintError("Please select a valid slot number.");
                    continue;
                }

                selectedSlot = availableSlots[slotChoice - 1];

                bool slotAlreadyBooked = bookedSlots.Contains(selectedSlot);

                if (slotAlreadyBooked)
                {
                    PrintError("Slot already booked. Choose another slot.");
                    continue;
                }

                break;
            }

            Console.WriteLine("\nCONFIRM APPOINTMENT");
            Console.WriteLine("----------------------------------");

            Console.WriteLine($"Patient : {patient.Name}");
            Console.WriteLine($"Doctor  : {doctor.FullName}");
            Console.WriteLine($"Date    : {selectedDate:dd MMM yyyy}");
            Console.WriteLine($"Slot    : {selectedSlot}");

            Console.Write("\nProceed ? (Y/N) : ");

            string confirm = Console.ReadLine()?.Trim().ToUpper() ?? "";

            if (confirm != "Y")
            {
                Console.WriteLine("\nBooking cancelled.");
                InputValidator.Pause();
                return;
            }

            try
            {
                Appointment appt = _appointmentService.BookAppointment(patient, doctor, selectedDate, selectedSlot);

                Console.WriteLine();
                PrintSuccess("Appointment booked successfully!");
                Console.WriteLine($"\n{appt.GetDetails()}");
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            InputValidator.Pause();
        }

        // ===============================
        // VIEW PATIENT APPOINTMENTS
        // ===============================
        public void ViewPatientAppointments()
        {
            
            PrintHeader("VIEW PATIENT APPOINTMENTS");

            if (!InputValidator.TryReadPositiveInt("Enter Patient ID : ", out int patientId))
            {
                PrintError("Invalid Patient ID.");
                InputValidator.Pause();
                return;
            }

            try
            {
                var appointments = _appointmentService
                    .GetAppointmentsByPatient(patientId);

                foreach (var appt in appointments)
                {
                    Console.WriteLine(appt.GetDetails());
                    Console.WriteLine("------------------------------------");
                }
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            InputValidator.Pause();
        }

        // ===============================
        // CONFIRM / CANCEL
        // ===============================
        public void ConfirmOrCancel()
        { 
            PrintHeader("CONFIRM / CANCEL");

            var appointments = _appointmentService.GetUpcomingAppointments();

            foreach (var appt in appointments)
            {
                Console.WriteLine(appt.GetDetails());
                Console.WriteLine("--------------------------------");
            }

            if (!InputValidator.TryReadPositiveInt("Enter Appointment ID : ", out int id))
            {
                PrintError("Invalid ID.");
                return;
            }

            Console.Write("[C] Confirm  [X] Cancel : ");
            string action = Console.ReadLine()?.ToUpper();

            if (action == "C")
            {
                _appointmentService.GetAppointmentById(id).Confirm();
                PrintSuccess("Confirmed!");
            }
            else if (action == "X")
            {
                Console.Write("Reason: ");
                string reason = Console.ReadLine() ?? "";

                _appointmentService.CancelAppointment(id, reason);
                PrintSuccess("Cancelled!");
            }

            InputValidator.Pause();
        }

        // ===============================
        // HELPERS
        // ===============================

        private void PrintHeader(string title)
        {
            Console.WriteLine("========================================");
            Console.WriteLine(title);
            Console.WriteLine("========================================");
        }

        private void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR : {message}");
            Console.ResetColor();
        }

        private void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nSUCCESS : {message}");
            Console.ResetColor();
        }
    }
}