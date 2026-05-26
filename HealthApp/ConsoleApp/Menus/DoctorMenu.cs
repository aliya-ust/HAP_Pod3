using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Helpers;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Menus
{
    public class DoctorMenu
    {
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;

        public DoctorMenu(IDoctorService doctorService, IAppointmentService appointmentService)
        {
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("DOCTOR MENU");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Search by Specialisation");
                Console.WriteLine("3. Get Doctor By ID");
                Console.WriteLine("4. View All Doctors");
                Console.WriteLine("5. Back");

                Console.Write("Enter choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddDoctor(); break;
                    case "2": SearchBySpecialisation(); break;
                    case "3": GetDoctorById(); break;
                    case "4": ViewAllDoctors(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Pause();
                        break;
                }
            }
        }


        // Add a new doctor with schedule and available slots
        public void AddDoctor()
        {
            try
            {
                PrintHeader("Add New Doctor");
                Console.WriteLine("Type 'q' or 'back' anytime to return.\n");

                // Get and validate doctor full name
                string name = InputValidator.GetValidatedInput(
                    "Full Name              : ",
                    InputValidator.IsValidName,
                    "Name cannot be empty or contain numbers.")!;

                // Get and validate specialisation
                string spec = InputValidator.GetValidatedInput(
                    "Specialisation         : ",
                    InputValidator.IsValidName,
                    "Specialisation cannot be empty or contain numbers.")!;

                // Get and validate years of experience
                string yearsRaw = InputValidator.GetValidatedInput(
                    "Years Of Experience    : ",
                    InputValidator.IsValidExperience,
                    "Please enter a valid non-negative number.")!;

                // Get and validate consultation fee
                string feeRaw = InputValidator.GetValidatedInput(
                    "Consultation Fee (Rs.) : ",
                    InputValidator.IsValidFee,
                    "Please enter a valid non-negative amount.")!;

                int years = int.Parse(yearsRaw);
                decimal fee = decimal.Parse(feeRaw);

                // Collect leave dates within the next 30 days
                List<DateTime> leaveDates = new();
                DateTime startDate = DateTime.Today;
                DateTime endDate = DateTime.Today.AddDays(30);

                Console.WriteLine("\nDoctor is available for the next 30 days.");
                Console.WriteLine("Enter leave dates one by one. Type 'done' when finished.\n");

                while (true)
                {
                    Console.Write("Enter Leave Date (dd/MM/yyyy) or 'done' : ");
                    string input = Console.ReadLine()?.Trim() ?? "";

                    if (input.Equals("q", StringComparison.OrdinalIgnoreCase) ||
                        input.Equals("back", StringComparison.OrdinalIgnoreCase))
                        throw new OperationCanceledException();

                    if (input.Equals("done", StringComparison.OrdinalIgnoreCase))
                        break;

                    if (!DateTime.TryParseExact(input, "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out DateTime leaveDate))
                    {
                        PrintError("Invalid format. Use dd/MM/yyyy.");
                        continue;
                    }

                    if (leaveDate < startDate || leaveDate > endDate)
                    {
                        PrintError("Only dates within the next 30 days are allowed.");
                        continue;
                    }

                    if (leaveDates.Contains(leaveDate))
                    {
                        PrintError("Already added.");
                        continue;
                    }

                    leaveDates.Add(leaveDate);
                    Console.WriteLine($"  Leave added : {leaveDate:dd/MM/yyyy}");
                }

                // Build available dates by excluding leave dates
                List<DateTime> availableDates = new();
                for (DateTime d = startDate; d <= endDate; d = d.AddDays(1))
                    if (!leaveDates.Contains(d))
                        availableDates.Add(d);

                // Display and select available time slots
                SlotHelper slotHelper = new();
                List<string> allSlots = slotHelper.AvailableSlots;
                List<string> defaultSlots = new();

                while (true)
                {
                    Console.WriteLine("\nAvailable Slots:");
                    for (int i = 0; i < allSlots.Count; i++)
                        Console.WriteLine($"  {i + 1}. {allSlots[i]}");

                    string slotInput = InputValidator.GetValidatedInput(
                        "\nSelect Slots (e.g. 1,2,3) : ",
                        InputValidator.IsNonEmpty,
                        "Please enter at least one slot number.")!;

                    List<string> selected = new();
                    bool valid = true;

                    foreach (string choice in slotInput.Split(','))
                    {
                        if (!int.TryParse(choice.Trim(), out int index) ||
                            index < 1 || index > allSlots.Count)
                        {
                            PrintError($"Invalid slot choice: {choice.Trim()}");
                            valid = false;
                            break;
                        }

                        string slot = allSlots[index - 1];
                        if (!selected.Contains(slot)) selected.Add(slot);
                    }

                    if (!valid || selected.Count == 0) continue;

                    defaultSlots = selected;
                    break;
                }

                // Build and save the doctor
                Doctor doctor = new()
                {
                    Name = name,
                    Specialisation = spec,
                    YearsOfExperience = years,
                    ConsultationFee = fee,
                    IsActive = true,
                    AvailableDates = availableDates,
                    AvailableSlots = defaultSlots
                };

                _doctorService.AddDoctor(doctor);

                PrintSuccess("Doctor Added Successfully!");
                Console.WriteLine($"  {doctor.GetScheduleSummary()}");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }

            Pause();
        }

        // Search doctors by specialisation and show their details
        public void SearchBySpecialisation()
        {
            try
            {
                PrintHeader("Search Doctors by Specialisation");
                Console.WriteLine("Type 'q' or 'back' to return.\n");

                // Get specialisation keyword
                string query = InputValidator.GetValidatedInput(
                    "Specialisation : ",
                    InputValidator.IsValidName,
                    "Specialisation cannot be empty.")!;

                var results = _doctorService.GetDoctorsBySpecialisation(query);
                Console.WriteLine($"\n  {results.Count} doctor(s) found:\n");

                foreach (var d in results)
                {
                    Console.WriteLine($"  [{d.DoctorId}] {d.Name} — {d.Specialisation}");
                    Console.WriteLine($"  Experience : {d.YearsOfExperience} years | Fee : Rs.{d.ConsultationFee}");
                    Console.WriteLine($"  Status     : {(d.IsActive ? "Active" : "Inactive")}");
                    Console.WriteLine(d.AvailableSlots.Count > 0
                        ? $"  Slots      : {string.Join(", ", d.AvailableSlots)}"
                        : "  Slots      : None configured");

                    // Show availability using spec method IsAvailable()
                    bool availableToday = d.IsAvailable(DateTime.Today);
                    Console.ForegroundColor = availableToday ? ConsoleColor.Green : ConsoleColor.Yellow;
                    Console.WriteLine($"  Available Today : {(availableToday ? "Yes" : "No")}");
                    Console.ResetColor();

                    // Show schedule summary using spec method GetScheduleSummary()
                    Console.WriteLine($"  {d.GetScheduleSummary()}");
                    Console.WriteLine(new string('-', 50));
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }
            catch (SpecialisationNotFoundException ex)
            {
                Console.WriteLine($"\n  {ex.Message}");
            }

            Pause();
        }

        // Get and display a single doctor by ID
        public void GetDoctorById()
        {
            try
            {
                PrintHeader("Get Doctor by ID");
                Console.WriteLine("Type 'q' or 'back' to return.\n");

                // Get and validate doctor ID
                string raw = InputValidator.GetValidatedInput(
                    "Enter Doctor ID : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                Doctor doctor = _doctorService.GetDoctorById(int.Parse(raw));

                if (doctor == null)
                {
                    PrintError("Doctor not found.");
                    Pause();
                    return;
                }

                Console.WriteLine(new string('-', 36));
                Console.WriteLine($"ID             : {doctor.DoctorId}");
                Console.WriteLine($"Name           : {doctor.Name}");
                Console.WriteLine($"Specialisation : {doctor.Specialisation}");
                Console.WriteLine($"Experience     : {doctor.YearsOfExperience} years");
                Console.WriteLine($"Fee            : Rs.{doctor.ConsultationFee}");
                Console.WriteLine($"Active         : {(doctor.IsActive ? "Yes" : "No")}");
                Console.WriteLine($"Slots          : {string.Join(", ", doctor.AvailableSlots)}");
                Console.WriteLine(new string('-', 36));
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }

            Pause();
        }

        // Display all doctors in the system
        public void ViewAllDoctors()
        {
            PrintHeader("All Doctors");

            var doctors = _doctorService.GetAllDoctors();

            if (doctors == null || doctors.Count == 0)
            {
                PrintError("No doctors available.");
                Pause();
                return;
            }

            foreach (var doctor in doctors)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine($"ID             : {doctor.DoctorId}");
                Console.WriteLine($"Name           : {doctor.Name}");
                Console.WriteLine($"Specialisation : {doctor.Specialisation}");
                Console.WriteLine($"Experience     : {doctor.YearsOfExperience} years");
                Console.WriteLine($"Fee            : Rs.{doctor.ConsultationFee}");
                Console.WriteLine($"Active         : {(doctor.IsActive ? "Yes" : "No")}");
            }

            Console.WriteLine(new string('-', 40));
            Pause();
        }
        public void UpdateDoctor()
        {
            try
            {
                PrintHeader("Get Doctor by ID");
                Console.WriteLine("Type 'q' or 'back' to return.\n");

                // Get and validate doctor ID
                string raw = InputValidator.GetValidatedInput(
                    "Enter Doctor ID : ",
                    InputValidator.IsValidId,
                    "Please enter a valid positive number.")!;

                Doctor doctor = _doctorService.GetDoctorById(int.Parse(raw));

                if (doctor == null)
                {
                    PrintError("Doctor not found.");
                    Pause();
                    return;
                }

            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
            }

            Pause();

        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        private static void PrintHeader(string title)
        {
            Console.WriteLine($"\n--- {title} ---\n");
        }

        private static void PrintSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR : {message}");
            Console.ResetColor();
        }

        private static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(intercept: true);
        }
    }
}