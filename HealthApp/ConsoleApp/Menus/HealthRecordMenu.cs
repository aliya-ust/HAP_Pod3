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

                Console.Clear();
                Appointment? appointment;
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
                        appointment = _appointmentService.GetAppointmentById(appointmentId);
                        if (appointment != null)
                        {
                            appointment.Complete();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Appointment ID.\n");
                    }
                }

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

                var record = new HealthRecord
                {
                    Patient = appointment.Patient,
                    Doctor = appointment.Doctor,
                    VisitDate = appointment.ScheduledDate,
                    Diagnosis = diagnosis,
                    Prescription = prescription,
                    DoctorNotes = doctorNotes
                };

                return _healthRecordService.AddHealthRecord(record);
            } catch (InvalidOperationException)
            {
                return "Cannot add health record for an appointment that's not been confirmed";
            }
        }

        public void ViewRecord()
        {
            Console.Clear();
            Console.WriteLine("1. View records by Patient Id");
            Console.WriteLine("2. View records by Doctor Id");
            Console.WriteLine("3. View record by Record Id");
            Console.Write("Enter choice: ");

            string? choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadKey();
                return;
            }

            Console.Clear();

            switch (choice)
            {
                case "1":
                    {
                        try
                        {
                            Console.Write("Enter Patient Id: ");
                            string? input = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int patientId))
                            {
                                Console.WriteLine("Invalid Patient Id.");
                                Console.ReadKey();
                                return;
                            }

                            List<HealthRecord> records = _healthRecordService
                                .GetByPatientIdOrderByVisitDateDesc(patientId);

                            Console.Clear();
                            Console.WriteLine("Health records: ");
                            foreach (HealthRecord r in records)
                            {
                                Console.WriteLine(r.ToString());
                            }

                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            break;
                        } catch (PatientNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.Write("\nPress any key to continue...");
                            Console.ReadKey();
                        }
                    }
                    break;
                case "2":
                    {
                        try
                        {
                            Console.Write("Enter Doctor Id: ");
                            string? input = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int doctorId))
                            {
                                Console.WriteLine("Invalid Doctor Id.");
                                Console.ReadKey();
                                return;
                            }

                            List<HealthRecord> records = _healthRecordService
                                .GetByDoctorIdOrderByVisitDateDesc(doctorId);

                            Console.Clear();
                            Console.WriteLine("Health records: ");
                            foreach (HealthRecord r in records)
                            {
                                Console.WriteLine(r.ToString());
                            }

                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            break;
                        } catch (DoctorNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.Write("\nPress any key to continue...");
                            Console.ReadKey();
                        }
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
                                return;
                            }

                            HealthRecord? record = _healthRecordService
                                .GetRecordById(recordId);

                            Console.Clear();
                            Console.WriteLine("Health records: ");
                            Console.WriteLine(record);

                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            break;
                        } catch (HealthRecordNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.Write("\nPress any key to continue...");
                            Console.ReadKey();
                        }
                        break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    return;
            }
        }

        public string UpdateHealthRecord()
        {
            try
            {
                int recordId;
                Console.Clear();

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

                    if (DateTime.TryParse(input, out DateTime parsedDate) && parsedDate <= DateTime.Today)
                    {
                        visitDate = parsedDate;
                        break;
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

                Console.Clear();
                return _healthRecordService.UpdateHealthRecord(updatedRecord).ToString();
            } catch (HealthRecordNotFoundException ex)
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
    }
}
