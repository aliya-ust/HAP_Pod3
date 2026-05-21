using System;
using System.Linq;
using System.Globalization;

namespace HealthApp.ConsoleApp.Helpers
{
    public static class InputValidator
    {
        // ✅ Integer
        public static bool TryReadInt(string prompt, out int value)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out value))
            {
                PrintError("Invalid number.");
                return false;
            }

            return true;
        }

        public static bool TryReadPositiveInt(string prompt, out int value)
        {
            if (!TryReadInt(prompt, out value))
                return false;

            if (value <= 0)
            {
                PrintError("Value must be greater than zero.");
                return false;
            }

            return true;
        }

        // ✅ Decimal
        public static bool TryReadDecimal(string prompt, out decimal value)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (!decimal.TryParse(input, out value) || value < 0)
            {
                PrintError("Invalid amount.");
                return false;
            }

            return true;
        }

        // ✅ String
        public static bool TryReadString(string prompt, out string value)
        {
            Console.Write(prompt);
            value = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(value))
            {
                PrintError("Cannot be empty.");
                return false;
            }

            return true;
        }

        // ✅ Doctor Name
        public static bool TryReadDoctorName(string prompt, out string value)
        {
            Console.Write(prompt);
            value = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(value))
            {
                PrintError("Name cannot be empty.");
                return false;
            }

            if (!value.All(c => char.IsLetter(c) || c == ' '))
            {
                PrintError("Only alphabets allowed.");
                return false;
            }

            return true;
        }

        // ✅ Specialisation
        public static bool TryReadSpecialisation(string prompt, out string value)
        {
            Console.Write(prompt);
            value = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrWhiteSpace(value))
            {
                PrintError("Specialisation required.");
                return false;
            }

            return true;
        }

        // ✅ Experience
        public static bool TryReadExperience(string prompt, out int value)
        {
            if (!TryReadInt(prompt, out value))
                return false;

            if (value < 0)
            {
                PrintError("Invalid experience.");
                return false;
            }

            return true;
        }

        // ✅ Fee
        public static bool TryReadConsultationFee(string prompt, out decimal value)
        {
            if (!TryReadDecimal(prompt, out value))
                return false;

            if (value <= 0)
            {
                PrintError("Fee must be greater than zero.");
                return false;
            }

            return true;
        }

        // ✅ Active
        public static bool TryReadIsActive(string prompt, out bool value)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.ToLower();

            if (input == "yes" || input == "y" || input == "true")
            {
                value = true;
                return true;
            }

            if (input == "no" || input == "n" || input == "false")
            {
                value = false;
                return true;
            }

            PrintError("Enter yes/no.");
            value = false;
            return false;
        }

        // ✅ Date
        public static bool TryReadFutureDate(string prompt, out DateTime value)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (!DateTime.TryParseExact(input, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
            {
                PrintError("Invalid format (dd/MM/yyyy).");
                return false;
            }

            if (value.Date < DateTime.Today)
            {
                PrintError("Date cannot be in the past.");
                return false;
            }

            return true;
        }

        // ✅ Helper
        private static void PrintError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✗ {msg}");
            Console.ResetColor();
        }

        public static void Pause()
        {
            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}
