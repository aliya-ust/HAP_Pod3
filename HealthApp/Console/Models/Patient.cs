using System;
namespace HealthApp.Console.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int InsuranceId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Patient()
        {
            CreatedAt = DateTime.Now;
        }

        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - Dob.Year;

            if (Dob.Date > today.AddYears(-age))
                age--;

            return age;
        }

        public string GetProfileSummary()
        {
            return $"ID: {Id} | Name: {Name} | Age: {GetAge()} | Gender: {Gender} | Email: {Email} | Phone: {PhoneNumber}";
        }
    }
}
