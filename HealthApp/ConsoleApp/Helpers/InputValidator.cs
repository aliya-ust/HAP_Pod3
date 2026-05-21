using System;
using System.Globalization;


namespace HealthApp.ConsoleApp.Helpers
{
    public static class InputValidator
    {
        // ── Integers ─────────────────────────────────────────

        public static bool TryReadInt(string prompt, out int value)
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

        public static bool TryReadPositiveInt(string prompt, out int value)
        {
            if (!TryReadInt(prompt, out value)) return false;

            if (value <= 0)
            {
                PrintError("Value must be greater than zero.");
                return false;
            }

            return true;
        }

        // ── Decimals ─────────────────────────────────────────

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

        // ── Strings ──────────────────────────────────────────

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

        public static string ReadOptionalString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()?.Trim() ?? "";
        }

        // ── Email ────────────────────────────────────────────

        public static bool TryReadEmail(string prompt, out string value)
        {
            Console.Write(prompt);
            value = Console.ReadLine()?.Trim() ?? "";

            int atIndex = value.IndexOf('@');
            bool valid = atIndex > 0 && value.LastIndexOf('.') > atIndex;

            if (!valid)
            {
                PrintError($"'{value}' is not a valid email address. Example: john@email.com");
                return false;
            }

            return true;
        }

        // ── Phone ────────────────────────────────────────────

        public static bool TryReadPhone(string prompt, out string value)
        {
            Console.Write(prompt);
            value = Console.ReadLine()?.Trim() ?? "";

            string digits = value.Replace(" ", "").Replace("-", "");

            if (digits.Length != 10 || !long.TryParse(digits, out _))
            {
                PrintError("Phone number must be exactly 10 digits (e.g. 9876543210).");
                return false;
            }

            return true;
        }

        // ── Dates ────────────────────────────────────────────

        public static bool TryReadPastDate(string prompt, out DateTime value)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (!DateTime.TryParseExact(input, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
            {
                PrintError($"'{input}' is not a valid date. Use format dd/MM/yyyy (e.g. 15/08/1995).");
                return false;
            }

            if (value.Date >= DateTime.Today)
            {
                PrintError("Date of birth cannot be today or in the future.");
                return false;
            }

            return true;
        }

        public static bool TryReadFutureDate(string prompt, out DateTime value)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";

            if (!DateTime.TryParseExact(input, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
            {
                PrintError($"'{input}' is not a valid date. Use format dd/MM/yyyy (e.g. 25/12/2025).");
                return false;
            }

            if (value.Date < DateTime.Today)
            {
                PrintError("Appointment date cannot be in the past.");
                return false;
            }

            return true;
        }

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

        // ── Yes / No ─────────────────────────────────────────

        public static bool Confirm(string prompt)
        {
            Console.Write(prompt + " (y/n): ");
            string answer = Console.ReadLine()?.Trim().ToLower() ?? "n";
            return answer == "y" || answer == "yes";
        }

        // ── Menu choice ──────────────────────────────────────

        public static string ReadMenuChoice(string prompt = "Enter your choice: ")
        {
            Console.Write(prompt);
            return Console.ReadLine()?.Trim() ?? "";
        }

        public static bool TryReadMenuChoice(out int choice)
        {
            choice = -1;
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return false;

            return int.TryParse(input.Trim(), out choice);
        }

        // ── Helpers ──────────────────────────────────────────

        private static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  ✗ {message}");
            Console.ResetColor();
        }

        public static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(intercept: true);
        }
    }
}