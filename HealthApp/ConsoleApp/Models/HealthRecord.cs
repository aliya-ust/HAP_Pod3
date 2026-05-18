namespace HealthApp.ConsoleApp.Models
{
    public class HealthRecord
    {
        public int RecordId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string DoctorNotes { get; set; }

        public string GetSummary()
        {
            return $"Patient: {Patient} | Doctor: {Doctor} | Date: {VisitDate.ToShortDateString()} | Diagnosis: {Diagnosis} | Prescription: {Prescription} | Notes: {DoctorNotes}";
        }

        public override string ToString()
        {
            return $"Record Id: {RecordId} | Patient: {Patient} | Doctor: {Doctor} | Visit Date: {VisitDate.ToShortDateString()} | Diagnosis: {Diagnosis} | Prescription: {Prescription} | Doctor Notes: {DoctorNotes}";
        }
    }
}