using System;
using System.Collections.Generic;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;
using HealthApp.ConsoleApp.Exceptions;

namespace HealthApp
{
    public class AppointmentMenu
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public AppointmentMenu(IAppointmentService appointmentService,
                                IPatientService patientService,
                                IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        public string BookAppointment()
        {
            try
            {
                int patientId;
                int doctorId;
                Patient? patient;
                Doctor? doctor;
                DateTime date;
                string slot;

                Console.Clear();
                while (true)
                {
                    Console.Write("Enter Patient ID (or 'q' to quit): ");
                    var input = Console.ReadLine();

                    if (input?.ToLower() == "q")
                    {
                        Console.WriteLine("Booking cancelled.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        return "";            
                    }

                    if (int.TryParse(input, out patientId) && patientId > 0)
                    {
                        patient = _patientService.GetPatientById(patientId);
                        if (patient != null) 
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Invalid Patient ID.\n");
                }

                while (true)
                {
                    Console.Write("Enter Doctor ID (or 'q' to quit): ");
                    var input = Console.ReadLine();

                    if (input?.ToLower() == "q")
                    {
                        Console.WriteLine("Booking cancelled.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        return "";            
                    }

                    if (int.TryParse(input, out doctorId) && doctorId > 0)
                    {
                        doctor = _doctorService.GetDoctorById(doctorId);
                        if (doctor != null) 
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Invalid Doctor ID.\n");
                }

                while (true)
                {
                    Console.Write("Enter Appointment Date (dd/mm/yyyy) (or 'q' to quit): ");
                    var input = Console.ReadLine();

                    if (input?.ToLower() == "q")
                    {
                        Console.WriteLine("Booking cancelled.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        return "";            
                    }

                    if (DateTime.TryParse(input, out date))
                        break;

                    Console.WriteLine("Invalid date format.\n");
                }

                
                Console.WriteLine();
                Console.WriteLine("  Available time slots:");
                Console.WriteLine("    [1] 09:00 AM    [2] 10:00 AM    [3] 11:00 AM");
                Console.WriteLine("    [4] 02:00 PM    [5] 03:00 PM    [6] 04:00 PM");

                int slotChoice;
                while (true)
                {
                    Console.Write("Choose slot (1-6): ");
                    var input = Console.ReadLine();

                    if (!int.TryParse(input, out slotChoice) || slotChoice < 1 || slotChoice > 6)
                    {
                        Console.WriteLine("Please enter a number between 1 and 6.");
                        continue;
                    }
                    break;
                }

                string[] slots = {
                    "09:00 AM", "10:00 AM", "11:00 AM",
                    "02:00 PM", "03:00 PM", "04:00 PM"
                };

                slot = slots[slotChoice - 1];

                return _appointmentService
                    .BookAppointment(patient, doctor, date, slot);
            } catch (PatientNotFoundException ex)
            {
                return ex.Message;
            } catch (DoctorNotFoundException ex)
            {
                return ex.Message;
            } catch (PastDateException ex)
            {
                return $"{ex.Message}";
            }
            catch (AppointmentConflictException ex)
            {
                return $"{ex.Message}";
            }
            catch (DoctorUnavailableException ex)
            {
                return $"{ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected error: {ex.Message}";
            }
        }

        public List<Appointment> ViewAppointments()
        {
            Console.Clear();
            Console.WriteLine("1. View appointments by Patient Id");
            Console.WriteLine("2. View appointments by Doctor Id");
            Console.WriteLine("3. View appointment by Appointment Id");
            Console.WriteLine("4. Go back");
            Console.Write("Enter choice: ");

            string? choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Invalid input.");
                Console.ReadKey();
                return [];
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
                                return [];
                            }

                            var existingPatient = _patientService.GetPatientById(patientId);

                            List<Appointment> appointments = _appointmentService.GetAppointmentsByPatientId(patientId);

                            Console.Clear();
                            Console.WriteLine("\n=== Appointments ===\n");

                            foreach (Appointment a in appointments)
                            {
                                Console.WriteLine(a.GetDetails());
                            }

                            return [];
                        } catch (AppointmentNotFoundException)
                        {
                            Console.WriteLine("There are no appointments booked by this patient ID");
                            return [];
                        } catch (PatientNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            return [];
                        }
                }
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
                                return [];
                            }

                            var existingDoctor = _doctorService.GetDoctorById(doctorId);

                            List<Appointment> appointments = _appointmentService.GetAppointmentsByDoctorId(doctorId);

                            Console.Clear();
                            Console.WriteLine("\n=== Appointments ===\n");

                            foreach (var a in appointments)
                            {
                                Console.WriteLine(a.GetDetails());
                            }
                            return [];
                        } catch (AppointmentNotFoundException)
                        {
                            Console.WriteLine("There are no appointments booked by this patient ID");
                            return [];
                        } catch (DoctorNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            return [];
                        }
                }
                case "3":
                    try
                        {
                            Console.Write("Enter Appointment Id: ");
                            string? input = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int appointmentId))
                            {
                                Console.WriteLine("Invalid Record Id.");
                                Console.ReadKey();
                                return [];
                            }

                            Appointment? appointment = _appointmentService
                                .GetAppointmentById(appointmentId);

                            Console.Clear();
                            Console.WriteLine("Appointment: ");
                            Console.WriteLine(appointment.GetDetails());
                            return [];
                        } catch (AppointmentNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.Write("\nPress any key to continue...");
                            Console.ReadKey();
                            return [];
                        }
                case "4":
                    return [];
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    return [];
            }
        }

        public string ConfirmCancelAppointment()
        {
            Console.Clear();
            Console.WriteLine("1. Confirm Appointment");
            Console.WriteLine("2. Cancel Appointment");
            Console.WriteLine("3. Go back");
            Console.Write("Enter choice: ");

            string? choice = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(choice))
            {
                return "Invalid input.";
            }

            switch (choice)
            {
                case "1":
                {
                    try
                    {
                        Console.Write("Enter Appointment Id to confirm: ");
                        string? input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int appointmentId))
                        {
                            return "Invalid Appointment Id.";
                        }

                        Appointment? appointment = _appointmentService
                            .GetAppointmentById(appointmentId);

                        appointment.Confirm();

                        return "Appointment confirmed successfully.";
                    }
                    catch (AppointmentNotFoundException ex)
                    {
                        return ex.Message;
                    }
                    catch (InvalidOperationException ex)
                    {
                        return $"{ex.Message}";
                    }
                }

                case "2":
                {
                    try
                    {
                        Console.Write("Enter Appointment Id to cancel: ");
                        string? input = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int appointmentId))
                        {
                            return "Invalid Appointment Id.";
                        }

                        
                        Console.Write("Enter reason for cancellation: ");
                        string? reason = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(reason))
                        {
                            return "Cancellation reason cannot be empty.";
                        }

                        // Assuming service has CancelAppointment method
                        return _appointmentService.CancelAppointment(appointmentId, reason);
                    }
                    catch (AppointmentNotFoundException ex)
                    {
                        return ex.Message;
                    }
                    catch (InvalidOperationException ex)
                    {
                        return $"{ex.Message}";
                    }
                }

                case "3":
                    return "";

                default:
                    return "Invalid choice.";
            }
        }
    }
}
