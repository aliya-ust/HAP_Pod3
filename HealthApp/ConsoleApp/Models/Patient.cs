using System;
namespace HealthApp.ConsoleApp.Models
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
        public int Age => GetAge();

        // Constructor to initialize CreatedAt
        public Patient()
        {
            CreatedAt = DateTime.Now;
        }

        // Method to calculate age based on Dob
        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - Dob.Year;

            if (Dob.Date > today.AddYears(-age))
                age--;

            return age;
        }

        // Method to get a summary of the patient's profile
        public string GetProfileSummary()
        {
            return
           $"Patient Id     : {PatientId}\n" +
           $"Name         : {Name}\n" +
           $"DOB          : {Dob:dd/MM/yyyy}\n" +
           $"Gender       : {Gender}\n" +
           $"Phone        : {PhoneNumber}\n" +
           $"Email        : {Email}\n" +
           $"Insurance Id : {InsuranceId}";

        }

    }
}
