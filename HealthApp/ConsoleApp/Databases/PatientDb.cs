using HealthApp.ConsoleApp.Models;
namespace HealthApp.ConsoleApp.Databases
{
    public class PatientDb
    {
        private List<Patient> Patients = new()
        {
            // Pre-populated patients with unique IDs, contact details, and insurance information
            // PatientId starts from 101 to avoid conflict with test data
            new Patient
            {
                PatientId = 101,
                Name = "Arjun Kumar",
                Dob = new DateTime(1995, 5, 20),
                Gender = GenderType.Male,
                PhoneNumber = "9876543210",
                Email = "arjun@gmail.com",
                InsuranceId = "INS101",
                CreatedAt = DateTime.Now
            },

            new Patient
            {
                PatientId = 102,
                Name = "Kevin Raj",
                Dob = new DateTime(1998, 8, 15),
                Gender = GenderType.Male,
                PhoneNumber = "9123456789",
                Email = "kevin@gmail.com",
                InsuranceId = "INS102",
                CreatedAt = DateTime.Now
            },

namespace HealthApp.ConsoleApp.Databases;

public class PatientDb
{
    public List<Patient> Patients { get; set; } = new List<Patient>();
}
