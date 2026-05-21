using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases
{
    public class HealthRecordDB
    {
        public List<HealthRecord> Records = new List<HealthRecord>()
        {
            new HealthRecord
            {
                RecordId = 301,
                Patient = new Patient { PatientId = 101, Name = "Arjun" },
                Doctor = new Doctor { DoctorId = 201, FullName = "Dr. Meera" },
                VisitDate = new DateTime(2026, 5, 10)
            },
            new HealthRecord
            {
                RecordId = 302,
                Patient = new Patient { PatientId = 101, Name = "Arjun" },
                Doctor = new Doctor { DoctorId = 202, FullName = "Dr. Anjali" },
                VisitDate = new DateTime(2026, 5, 12)
            },
            new HealthRecord
            {
                RecordId = 303,
                Patient = new Patient { PatientId = 101, Name = "Arjun" },
                Doctor = new Doctor { DoctorId = 201, FullName = "Dr. Meera" },
                VisitDate = new DateTime(2026, 5, 8)
            },
            new HealthRecord
            {
                RecordId = 304,
                Patient = new Patient { PatientId = 101, Name = "Arjun" },
                Doctor = new Doctor { DoctorId = 203, FullName = "Dr. Kumar" },
                VisitDate = new DateTime(2026, 5, 12)
            },
            new HealthRecord
            {
                RecordId = 305,
                Patient = new Patient { PatientId = 102, Name = "Rahul" },
                Doctor = new Doctor { DoctorId = 201, FullName = "Dr. Meera" },
                VisitDate = new DateTime(2026, 5, 11)
            },
            new HealthRecord
            {
                RecordId = 306,
                Patient = new Patient { PatientId = 103, Name = "Sneha" },
                Doctor = new Doctor { DoctorId = 202, FullName = "Dr. Anjali" },
                VisitDate = new DateTime(2026, 5, 9)
            },
            new HealthRecord
            {
                RecordId = 307,
                Patient = null,
                Doctor = new Doctor { DoctorId = 204, FullName = "Dr. Test" },
                VisitDate = new DateTime(2026, 5, 13)
            }
        };
    }
}