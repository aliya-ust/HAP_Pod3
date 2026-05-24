using System.Globalization;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Helpers
{
    public static class InputValidator
    {
        public static string? GetValidatedInput(
            string prompt,
            Func<string, bool> validator,
            string errorMessage,
            bool allowEmpty = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    throw new OperationCanceledException();

                if (allowEmpty && string.IsNullOrWhiteSpace(input))
                    return null;

                if (!string.IsNullOrWhiteSpace(input) && validator(input))
                    return input.Trim();

                Console.WriteLine(errorMessage);
            }
        }

        public static DateTime GetValidDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    throw new OperationCanceledException();

                if (DateTime.TryParseExact(
                    input,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var date))
                {
                    return date;
                }

                Console.WriteLine("Invalid date.");
            }
        }

        public static DateTime? GetOptionalDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    return null;

                if (input?.ToLower() == "q")
                    throw new OperationCanceledException();

                if (DateTime.TryParseExact(
                    input,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var date))
                {
                    return date;
                }

                Console.WriteLine("Invalid date.");
            }
        }

        public static GenderType? GetOptionalGender(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    return null;

                if (input?.ToLower() == "q")
                    throw new OperationCanceledException();

                if (Enum.TryParse<GenderType>(input, true, out var gender))
                    return gender;

                Console.WriteLine("Invalid gender.");
            }
        }

        public static GenderType GetValidGender(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (input?.ToLower() == "q")
                    throw new OperationCanceledException();

                if (Enum.TryParse<GenderType>(input, true, out var gender))
                    return gender;

                Console.WriteLine("Invalid gender.");
            }
        }

        public static bool IsValidName(string input) =>
        !string.IsNullOrWhiteSpace(input) && !input.Any(char.IsDigit);

        public static bool IsValidPhone(string input) =>
            input.Length == 10 && input.All(char.IsDigit);

        public static bool IsValidEmail(string input) =>
            input.Contains('@');

        public static bool IsValidInsuranceId(string input) =>
            int.TryParse(input, out int id) && id >= 0;

        public static bool IsValidExperience(string input) =>
            int.TryParse(input, out int val) && val >= 0;

        public static bool IsValidFee(string input) =>
            decimal.TryParse(input, out decimal val) && val >= 0;

        public static bool IsValidId(string input) =>
            int.TryParse(input, out int id) && id > 0;

        public static bool IsNonEmpty(string input) =>
            !string.IsNullOrWhiteSpace(input);
    }
}