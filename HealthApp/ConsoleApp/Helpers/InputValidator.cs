using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Helpers
{
    //All console input reading and validation.

    public static class InputValidator
    {

        // Reads an integer. Returns false and prints an error if input is not a valid number.
        public static bool TryReadInt(string prompt, out int value)
        {
            try
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                CheckForExit(input);
                if (!int.TryParse(input.Trim(), out value))
                {
                    PrintError($"'{input}' is not a valid number. Please enter a whole number.");
                    return false;
                }

                return true;
            }
            catch (UserExitException)
            {
                value = -1;
                Console.WriteLine("\nReturning to Main Menu...");
                return false;
            }
        }

        // Reads an integer that must be greater than zero.
        public static bool TryReadPositiveInt(string prompt, out int value)
        {
            try{
            if (!TryReadInt(prompt, out value)) return false;

            if (value <= 0)
            {
                PrintError("Value must be greater than zero.");
                return false;
            }

            return true;
            }
            catch(UserExitException)
            {
                value = -1;
                Console.WriteLine("\nReturning to Main Menu...");
                return false;
            }
        }

        // Reads a decimal (e.g. consultation fee). Must be >= 0.
        public static bool TryReadDecimal(string prompt, out decimal value)
        {
            try
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                CheckForExit(input);
                if (!decimal.TryParse(input.Trim(), out value) || value < 0)
                {
                    PrintError($"'{input}' is not a valid positive number. Try again (e.g. 500 or 1200.50).");
                    return false;
                }

                return true;
            }
            catch (UserExitException)
            {
                value = -1;
                Console.WriteLine("\nReturning to Main Menu...");
                return false;
            }
        }


        // Reads a non-empty string.
        public static bool TryReadString(string prompt, out string value)
        {
            try
            {
                Console.Write(prompt);
                value = Console.ReadLine()?.Trim() ?? "";
                CheckForExit(value);

                if (string.IsNullOrWhiteSpace(value))
                {
                    PrintError("This field cannot be empty. Try again.");
                    return false;
                }

                return true;
            }
            catch (UserExitException)
            {
                value = "";
                Console.WriteLine("\nReturning to Main Menu...");
                return false;
            }
        }
        public static bool TryReadGender(string prompt, out Gender result)
        {
            try
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim() ?? "";

                CheckForExit(input);

                if (string.IsNullOrWhiteSpace(input))
                {
                    PrintError("Gender cannot be empty. Try again.");
                    result = default;
                    return false;
                }

                // Case-insensitive enum parsing
                if (Enum.TryParse(input, true, out result) &&
                    Enum.IsDefined(typeof(Gender), result))
                {
                    return true;
                }

                PrintError("Invalid gender. Please enter Male, Female, or Other.");
                return false;
            }
            catch (UserExitException)
            {
                result = default;
                Console.WriteLine("\nReturning to Main Menu...");
                return false;
            }
        }
        public static bool TryReadName(string prompt, out string value)
        {
            try
            {
                value = "";

                while (true)
                {
                    Console.Write(prompt);

                    value = Console.ReadLine()?.Trim() ?? "";

                    // CHECK USER INPUT HERE
                    CheckForExit(value);

                    // EMPTY VALIDATION
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        PrintError
                        (
                            "Name cannot be empty. Try again."
                        );

                        continue;
                    }

                    // LETTER VALIDATION
                    bool isValid = value.All(c =>
                        char.IsLetter(c) ||
                        char.IsWhiteSpace(c) ||
                        c == '.');

                    if (!isValid)
                    {
                        PrintError
                        (
                            "Name can contain only letters."
                        );

                        continue;
                    }

                    return true;
                }
            }

            catch (UserExitException)
            {
                value = "";

                Console.WriteLine
                (
                    "\nReturning to Main Menu..."
                );

                return false;
            }
        }

        // Reads an optional string (can be empty — used for Notes, InsuranceId etc.)
        // Never fails; empty string is valid.
        public static string ReadOptionalString(string prompt)
        {
            try
            {
                Console.Write(prompt);
                string value = Console.ReadLine()?.Trim() ?? "";
                CheckForExit(value);
                return value; // can be empty
            }
            catch (UserExitException)
            {
                Console.WriteLine("\nReturning to Main Menu...");
                return "";
            }
        }



        // Reads an email that must contain '@' and a '.' after it.
        public static bool TryReadEmail(string prompt, out string value)
        {
            try
            {
                value = "";
                while (true)
                {
                    Console.Write(prompt);
                    value = Console.ReadLine()?.Trim() ?? "";
                    CheckForExit(value);
                    string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";//("^[\\w.-]+@[\\w.-]+\\.\\w+$");

                    // int atIndex = value.IndexOf('@');
                    // bool valid  = atIndex > 0 && value.LastIndexOf('.') > atIndex;

                    if (!Regex.IsMatch(value, pattern))
                    {
                        PrintError($"'{value}' is not a valid email address. Try example like: john@email.com");
                        //return false;
                        continue;
                    }

                    return true;
                }
            }
            catch
            {
                value = "";
                Console.WriteLine("\nReturning to Main Menu...");
                return false;
            }
        }

        // Reads a phone number — must be 10 digits (Indian standard).
        public static bool TryReadPhone(string prompt, out string value)
        {
            try
            {
                value = "";
                while (true)
                {
                    Console.Write(prompt);
                    value = Console.ReadLine()?.Trim() ?? "";
                    CheckForExit(value);
                    string pattern = @"^[6-9]\d{9}$";
                    if(!Regex.IsMatch(value,pattern))
                    {
                        PrintError("Phone number must be exactly 10 digits (e.g. 9876543210).");
                        return false;
                    }

                    // Strip spaces/dashes for validation, keep original
                    // string digits = value.Replace(" ", "").Replace("-", "");

                    // if (digits.Length != 10 || !long.TryParse(digits, out _))
                    // {
                    //     PrintError("Phone number must be exactly 10 digits (e.g. 9876543210).Try again.");
                    //     continue;
                    // }

                    return true;
                }
            }
            catch
            {
                value = "";
                Console.WriteLine("\nReturning to Main Menu...");
                return false;
            }
        }

        // Reads a date in dd/MM/yyyy format. Cannot be in the future (for DOB).
        public static bool TryReadPastDate(string prompt, out DateTime value)
        {
            try
            {
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine()?.Trim() ?? "";
                    CheckForExit(input);

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
                        //return false;
                    }

                    return true;
                }
            }
            catch
            {
                value = DateTime.MinValue;
                Console.WriteLine("\nReturning to Main Menu...");
                return false;
            }
        }

        // Reads a date in dd/MM/yyyy format. Cannot be in the past (for appointments).
        public static bool TryReadFutureDate(string prompt, out DateTime value)
        {
            try
            {
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine()?.Trim() ?? "";
                    CheckForExit(input);

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
            catch
            {
                value = DateTime.MinValue;
                Console.WriteLine("\nReturning to Main Menu...");
                return false;
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
        public static void CheckForExit(string input)
        {
            if
            (
                input.Equals("back",
                StringComparison.OrdinalIgnoreCase) ||
                input.Equals("exit",
                StringComparison.OrdinalIgnoreCase)
            )
            {
                throw new UserExitException("User chose to exit.");
            }
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