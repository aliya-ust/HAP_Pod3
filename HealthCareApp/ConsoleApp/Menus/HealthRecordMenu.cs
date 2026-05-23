using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Services;
using HealthApp.ConsoleApp.Interfaces;
using System;
using System.Globalization;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp.ConsoleApp.Menus
{
    public class HealthRecordMenu
    {
        private readonly IHealthRecordService _healthRecordService;
        private readonly IAppointmentService _appointmentService;

        public HealthRecordMenu(IHealthRecordService healthRecordService,
                                IAppointmentService appointmentService)
        {
            _healthRecordService = healthRecordService;
            _appointmentService = appointmentService;
        }

        public string AddHealthRecord()
        {
            try
            {
                int appointmentId;
                string? diagnosis;
                string? prescription;
                string? doctorNotes;

                Appointment? appointment = null;

                // ✅ Appointment Input Loop
                while (true)
                {
                    Console.Write("Enter Appointment ID (or 'q' to quit): ");
                    var input = Console.ReadLine();

                    if (input?.ToLower() == "q")
                    {
                        Console.WriteLine("Health record creation cancelled.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return "";
                    }

                    if (int.TryParse(input, out appointmentId) && appointmentId > 0)
                    {
                        try
                        {
                            appointment = _appointmentService.GetAppointmentById(appointmentId);
                            appointment.Complete();   // ✅ mark as completed
                            break;   // ✅ exit loop after success
                        }
                        catch (AppointmentNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Appointment ID.\n");
                    }
                }

                // ✅ Diagnosis Input
                while (true)
                {
                    Console.Write("Enter Diagnosis (or 'q' to quit): ");
                    var input = Console.ReadLine();

                    if (input?.ToLower() == "q")
                    {
                        Console.WriteLine("Health record creation cancelled.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return "";
                    }

                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        diagnosis = input.Trim();
                        break;
                    }

                    Console.WriteLine("Diagnosis cannot be empty.\n");
                }

                // ✅ Prescription Input
                while (true)
                {
                    Console.Write("Enter Prescription (or 'q' to quit): ");
                    var input = Console.ReadLine();

                    if (input?.ToLower() == "q")
                    {
                        Console.WriteLine("Health record creation cancelled.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return "";
                    }

                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        prescription = input.Trim();
                        break;
                    }

                    Console.WriteLine("Prescription cannot be empty.\n");
                }

                // ✅ Doctor Notes Input
                while (true)
                {
                    Console.Write("Enter Doctor Notes (or 'q' to quit): ");
                    var input = Console.ReadLine();

                    if (input?.ToLower() == "q")
                    {
                        Console.WriteLine("Health record creation cancelled.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return "";
                    }

                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        doctorNotes = input.Trim();
                        break;
                    }

                    Console.WriteLine("Doctor Notes cannot be empty.\n");
                }

                // ✅ Create HealthRecord
                var record = new HealthRecord
                {
                    Patient = appointment.Patient,
                    Doctor = appointment.Doctor,
                    VisitDate = appointment.ScheduledDate, // ✅ auto from appointment
                    Diagnosis = diagnosis,
                    Prescription = prescription,
                    DoctorNotes = doctorNotes
                };

                return _healthRecordService.AddHealthRecord(record);
            }
            catch (InvalidOperationException)
            {
                return "Cannot add health record for an appointment that's not been confirmed";
            }
        }


        public void ViewRecord()
{
    while (true)
    {
        Console.WriteLine("1. View records by Patient Id");
        Console.WriteLine("2. View records by Doctor Id");
        Console.WriteLine("3. View record by Record Id");
        Console.WriteLine("4. Back");
        Console.Write("Enter choice: ");

        string choice = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(choice))
        {
            Console.WriteLine("Invalid input.");
            Console.ReadKey();
            continue;   // ✅ FIX
        }

        switch (choice)
        {
            case "1":
                try
                {
                    Console.Write("Enter Patient Id: ");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int patientId))
                    {
                        Console.WriteLine("Invalid Patient Id.");
                        Console.ReadKey();
                        continue;   // ✅ FIX
                    }

                    var records = _healthRecordService
                        .GetByPatientIdOrderByVisitDateDesc(patientId);

                    Console.WriteLine("\nHealth records:");
                    foreach (var r in records)
                    {
                        Console.WriteLine(r);
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                        catch (PatientNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                        }
                        catch (HealthRecordNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                        }
                        break;

            case "2":
                try
                {
                    Console.Write("Enter Doctor Id: ");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int doctorId))
                    {
                        Console.WriteLine("Invalid Doctor Id.");
                        Console.ReadKey();
                        continue;   // ✅ FIX
                    }

                    var records = _healthRecordService
                        .GetByDoctorIdOrderByVisitDateDesc(doctorId);

                    Console.WriteLine("\nHealth records:");
                    foreach (var r in records)
                    {
                        Console.WriteLine(r);
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                        catch (DoctorNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                        }
                        catch (HealthRecordNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                        }
                        break;

            case "3":
                try
                {
                    Console.Write("Enter Record Id: ");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int recordId))
                    {
                        Console.WriteLine("Invalid Record Id.");
                        Console.ReadKey();
                        continue;   // ✅ FIX
                    }

                    var record = _healthRecordService.GetRecordById(recordId);

                    Console.WriteLine("\nHealth record:");
                    Console.WriteLine(record);

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                        catch (HealthRecordNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                        }
                        break;

            case "4":
                return;   // ✅ ONLY exit point

            default:
                Console.WriteLine("Invalid choice.");
                Console.ReadKey();
                continue;   // ✅ FIX
        }
    }
}
public string UpdateHealthRecord()
        {
            try
            {
                int recordId;

                Console.Write("Enter Record ID to update (or 'q' to quit): ");
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                {
                    Console.WriteLine("Health record creation cancelled.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return "";
                }

                if (!int.TryParse(input, out recordId) || recordId <= 0)
                    return "Invalid Record ID";

                HealthRecord? existingRecord = _healthRecordService.GetRecordById(recordId);
                if (existingRecord is null)
                {
                    return "Invalid Record ID";
                }

                Console.WriteLine("\nCurrent Record Details:");
                Console.WriteLine(existingRecord);

                DateTime visitDate = existingRecord.VisitDate;
                while (true)
                {
                    Console.Write("\nEnter Visit Date (dd/mm/yyyy) (Press ENTER to keep existing value): ");
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                        break;

                    if (DateTime.TryParseExact(
                            input,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime parsedDate))
                    {
                        if (parsedDate <= DateTime.Today)
                        {
                            visitDate = parsedDate;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Visit date cannot be in the future.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please use dd/MM/yyyy.\n");
                    }

                    Console.WriteLine("Invalid visit date.\n");
                }

                Console.Write("Enter Diagnosis (Press ENTER to keep existing value): ");
                input = Console.ReadLine();
                string diagnosis = string.IsNullOrWhiteSpace(input)
                    ? existingRecord.Diagnosis
                    : input.Trim();

                Console.Write("Enter Prescription (Press ENTER to keep existing value): ");
                input = Console.ReadLine();
                string prescription = string.IsNullOrWhiteSpace(input)
                    ? existingRecord.Prescription
                    : input.Trim();

                Console.Write("Enter Doctor Notes (Press ENTER to keep existing value): ");
                input = Console.ReadLine();
                string doctorNotes = string.IsNullOrWhiteSpace(input)
                    ? existingRecord.DoctorNotes
                    : input.Trim();

                var updatedRecord = new HealthRecord
                {
                    RecordId = existingRecord.RecordId,
                    Patient = existingRecord.Patient,
                    Doctor = existingRecord.Doctor,
                    VisitDate = visitDate,
                    Diagnosis = diagnosis,
                    Prescription = prescription,
                    DoctorNotes = doctorNotes
                };

                var result = _healthRecordService.UpdateHealthRecord(updatedRecord);

                return "\n Health Record Updated Successfully!\n\nUPDATED RECORD:\n" + result.ToString();
            }
            catch (HealthRecordNotFoundException ex)
            {
                return ex.Message;
            }
        }

        public bool TryParseVisitDate(string visitDate, out DateTime result, out string? error)
        {
            result = default;
            error = null;

            if (!DateTime.TryParseExact(
                visitDate,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime visitDateParsed))
            {
                error = "Visit date not entered in the correct format";
                return false;
            }

            if (visitDateParsed.Date > DateTime.Today)
            {
                error = "Visit Date can't be in the future";
                return false;
            }

            result = visitDateParsed;
            return true;
        }

        private void ViewAllRecords()
        {
            Console.WriteLine("\nAll Health Records:\n");

            var records = _healthRecordService.GetAllRecords();

            if (records.Count == 0)
            {
                Console.WriteLine("No records found.");
            }
            else
            {
                foreach (var r in records)
                {
                    Console.WriteLine(r);
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("HEALTH RECORD MENU");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Add Health Record");
                Console.WriteLine("2. Get Records (By Patient / Doctor / Record ID)");  //UPDATED
                Console.WriteLine("3. Update Health Record");
                Console.WriteLine("4. View All Records");
                Console.WriteLine("5. Back");
                Console.WriteLine("=================================");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        Console.WriteLine(AddHealthRecord());
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case "2":
                        ViewRecord();   //opens submenu
                        break;

                    case "3":
                        Console.WriteLine(UpdateHealthRecord());
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case "4":
                        ViewAllRecords();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    }
