using System;

namespace HealthcareApp
{
    public class HealthRecord
    {
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string DoctorNotes { get; set; }

        public string GetSummary()
        {
            return $"Patient: {Patient} | Doctor: {Doctor} | Date: {VisitDate.ToShortDateString()} | Diagnosis: {Diagnosis} | Prescription: {Prescription} | Notes: {DoctorNotes}";
        }
    }
}