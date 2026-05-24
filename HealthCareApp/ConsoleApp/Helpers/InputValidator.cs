using System.Globalization;
using System.Text.RegularExpressions;

namespace HealthApp.ConsoleApp.Helpers
{
    //All console input reading and validation.

    public static class InputValidator
    {

        // Reads an integer. Returns false and prints an error if input is not a valid number.
        public static bool TryReadInt(string prompt, out int value)
        {while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";

                if (!int.TryParse(input.Trim(), out value))
                {
                    PrintError($"'{input}' is not a valid number. Please enter a whole number.");
                    return false;
                }

                return true;
            }
        }

        // Reads an integer that must be greater than zero.
        public static bool TryReadPositiveInt(string prompt, out int value)
           
        {
            while (true)
            {
                if (!TryReadInt(prompt, out value)) return false;

                if (value <= 0)
                {
                    PrintError("Value must be greater than zero.");
                    return false;
                }

                return true;
            }
        }

        // Reads a decimal (e.g. consultation fee). Must be >= 0.
        public static bool TryReadDecimal(string prompt, out decimal value)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (!decimal.TryParse(input.Trim(), out value) || value < 0)
            {
                PrintError("Please enter a valid positive number (e.g. 500 or 1200.50).");
                return false;
            }

            return true;
        }


        // Reads a non-empty string.
        public static bool TryReadString(string prompt, out string value)
        {
            Console.Write(prompt);
            value = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(value))
            {
                PrintError("This field cannot be empty.");
                return false;
            }

            return true;
        }
        public static bool TryReadName(string prompt, out string value)
        {
            value = "";

            while (true)
            {
                Console.Write(prompt);

                value = Console.ReadLine()?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(value))
                {
                    PrintError("Name cannot be empty.Try entering a valid name.");
                    continue;
                }

                bool isValid = value.All(c =>
                    char.IsLetter(c) ||
                    char.IsWhiteSpace(c) ||
                    c == '.');

                if (!isValid)
                {
                    PrintError("Name can contain only letters, spaces, and periods. Try entering a valid name.");
                    continue;
                }

                return true;
            }
        }

        // Reads an optional string (can be empty — used for Notes, InsuranceId etc.)
        // Never fails; empty string is valid.
       // add at top if not present

    public static string ReadOptionalString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            //Allow empty (optional field)
            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }

            //Validate Insurance ID format
            if (!Regex.IsMatch(input, @"^[A-Za-z0-9]{5,}$"))
            {
                Console.WriteLine("Invalid Insurance ID. Use letters/numbers (min 5 characters).");
                continue;
            }

            return input.Trim();
        }
    }



    // Reads an email that must contain '@' and a '.' after it.
    public static bool TryReadEmail(string prompt, out string value)
        {
            value = "";
            while (true)
            {
                Console.Write(prompt);
                value = Console.ReadLine()?.Trim() ?? "";
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (!Regex.IsMatch(value, pattern))
                {
                    PrintError($"'{value}' is not a valid email address. Try example like: john@email.com");
                    //return false;
                    continue;
                }

                return true;
            }
        }

        // Reads a phone number — must be 10 digits (Indian standard).
        public static bool TryReadPhone(string prompt, out string value)
        {
            value = "";
            while (true)
            {
                Console.Write(prompt);
                value = Console.ReadLine()?.Trim() ?? "";
               
                // Strip spaces/dashes for validation, keep original
                string digits = value.Replace(" ", "").Replace("-", "");

                if (digits.Length != 10 || !long.TryParse(digits, out _))
                {
                    PrintError("Phone number must be exactly 10 digits (e.g. 9876543210).Try again.");
                    continue;
                }

                return true;
            }
        }

        // Reads a date in dd/MM/yyyy format. Cannot be in the future (for DOB).
        public static bool TryReadPastDate(string prompt, out DateTime value)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim() ?? "";

                if (!DateTime.TryParseExact(input, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
                {
                    PrintError($"'{input}' is not a valid date. Use format dd/MM/yyyy (e.g. 15/08/1995).");
                    continue;
                }

                if (value.Date >= DateTime.Today)
                {
                    PrintError("Date of birth cannot be today or in the future.");
                    continue;
                }

                return true;
            }
        }

        // Reads a date in dd/MM/yyyy format. Cannot be in the past (for appointments).
        public static bool TryReadFutureDate(string prompt, out DateTime value)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim() ?? "";

                if (!DateTime.TryParseExact(input, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
                {
                    PrintError($"'{input}' is not a valid date. Use format dd/MM/yyyy (e.g. 25/12/2025).");
                    continue;
                }

                if (value.Date < DateTime.Today)
                {
                    PrintError("Appointment date cannot be in the past.");
                    continue;
                }

                return true;
            }
        }

        // Reads a date in dd/MM/yyyy format. Cannot be in the future (for health record visit date).
        public static bool TryReadVisitDate(string prompt, out DateTime value)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (!DateTime.TryParseExact(input, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
            {
                PrintError($"'{input}' is not a valid date. Use format dd/MM/yyyy (e.g. 01/05/2025).");
                return false;
            }

            if (value.Date > DateTime.Today)
            {
                PrintError("Visit date cannot be in the future.");
                return false;
            }

            return true;
        }

        
        public static bool TryValidateGender(string input, out string result)
        {
            result = input.Trim();

            return result.Equals("Male", StringComparison.OrdinalIgnoreCase)
                || result.Equals("Female", StringComparison.OrdinalIgnoreCase)
                || result.Equals("Other", StringComparison.OrdinalIgnoreCase);
        }

        public static bool TryValidateInsurance(string input, out string result)
        {
            result = input.Trim();

            return Regex.IsMatch(result, @"^[A-Za-z0-9]{3,}$");
        }

        public static bool TryValidateName(string input, out string result)
        {
            result = "";

            if (string.IsNullOrWhiteSpace(input))
                return false;

            bool isValid = input.All(c =>
                char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.');

            if (!isValid)
                return false;

            result = input.Trim();
            return true;
        }

        public static bool TryValidatePhone(string input, out string result)
        {
            result = input.Trim();

            string digits = result.Replace(" ", "").Replace("-", "");

            if (digits.Length != 10 || !long.TryParse(digits, out _))
                return false;

            return true;
        }

        public static bool TryValidateEmail(string input, out string result)
        {
            result = input.Trim();

            if (!Regex.IsMatch(result, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return false;

            return true;
        }

        public static bool TryValidatePastDate(string input, out DateTime value)
        {
            return DateTime.TryParseExact(
                input,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out value) && value < DateTime.Today;
        }



        // Asks a yes/no question. Returns true for 'y'/'yes', false for everything else.
        public static bool Confirm(string prompt)
        {
            Console.Write(prompt + " (y/n): ");
            string answer = Console.ReadLine()?.Trim().ToLower() ?? "n";
            return answer == "y" || answer == "yes";
        }

        // Reads a single menu option. Returns the string as-is ("1", "2", "0" etc.)
        // Never throws — if empty just returns empty string which hits the default case.

        private static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        // Pause until user presses a key — used at the end of every screen.
        public static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(intercept: true);
        }
        public static bool TryReadMenuChoice(out int choice)
        {
            choice = -1;
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return false;

            return int.TryParse(input.Trim(), out choice);
        }
    }
}