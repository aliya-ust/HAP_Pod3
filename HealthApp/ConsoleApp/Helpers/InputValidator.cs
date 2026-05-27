using System.Globalization;
using HealthApp.ConsoleApp.Models;
using System.Text.RegularExpressions;

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

                if (input?.ToLower() == "q" || input?.ToLower() == "back")
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


                if (!Enum.TryParse<GenderType>(input, true, out var gender))
                    throw new ArgumentException("Invalid gender");


                //if (Enum.GetNames(typeof(GenderType))
                //        .Any(n => n.Equals(input, StringComparison.OrdinalIgnoreCase)))
                {
                    return Enum.Parse<GenderType>(input, true);
                }
 

                //Console.WriteLine("Invalid gender.");
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

                if (Enum.GetNames(typeof(GenderType))
                        .Any(n => n.Equals(input, StringComparison.OrdinalIgnoreCase)))
                {
                    return Enum.Parse<GenderType>(input, true);
                }
 

                Console.WriteLine("Invalid gender.");
            }
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

        public static bool IsValidName(string input)
{
    if (string.IsNullOrWhiteSpace(input))
        return false;
 
    string pattern = @"^[A-Za-z]+([.\s]?[A-Za-z]+)*$";
    return Regex.IsMatch(input.Trim(), pattern);
}
        public static bool IsValidPhone(string input)
        {
            string pattern = @"^[6-9]\d{9}$";
            return Regex.IsMatch(input, pattern);
        }

        public static bool IsValidEmail(string input)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(input, pattern);
        }

        public static bool IsValidInsuranceId(string input) =>
            !string.IsNullOrWhiteSpace(input) &&
            System.Text.RegularExpressions.Regex.IsMatch(input, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$");

        public static bool IsValidExperience(string input)
        {
        return int.TryParse(input, out int val) && val >= 0 && val <= 50;
        }

        public static bool IsValidFee(string input) =>
            decimal.TryParse(input, out decimal val) && val >= 0;

        public static bool IsValidId(string input) =>
            int.TryParse(input, out int id) && id > 0;

        public static bool IsNonEmpty(string input) =>
            !string.IsNullOrWhiteSpace(input);

        public static bool IsValidText(string input) =>
            !string.IsNullOrWhiteSpace(input) &&
            input.Length >= 5 &&
            input.Any(char.IsLetter);
        
        //cancelation
        public static bool IsValidCancellationReason(string input) =>
            IsValidText(input);
 
        public static bool IsValidDiagnosis(string input) =>
            IsValidText(input);
 
        public static bool IsValidPrescription(string input) =>
            IsValidText(input);
 
        public static bool IsValidDoctorNotes(string input) =>
            IsValidText(input);
    }
}