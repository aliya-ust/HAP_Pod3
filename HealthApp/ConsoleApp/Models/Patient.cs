using System;

namespace HealthApp.ConsoleApp.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime Dob { get; set; }

        public string Gender { get; set; } = string.Empty;

        public long PhoneNumber { get; set; }

        public string Email { get; set; } = string.Empty;

        public int InsuranceId { get; set; }

        public DateTime CreatedAt { get; private set; }

        public int Age => CalculateAge();

        public Patient()
        {
            CreatedAt = DateTime.Now;
        }

        private int CalculateAge()
        {
            if (Dob == default)
                return 0;

            var today = DateTime.Today;
            int age = today.Year - Dob.Year;

            if (Dob > today.AddYears(-age))
                age--;

            return age;
        }

        public string GetProfileSummary()
        {
            return $"ID: {Id} | Name: {Name} | Age: {Age} | Gender: {Gender} | Email: {Email} | Phone: {PhoneNumber}";
        }
    }
}