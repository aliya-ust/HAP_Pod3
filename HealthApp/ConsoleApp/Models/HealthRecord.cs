namespace HealthApp.ConsoleApp.Models
{
    public class HealthRecord
    {
        public int RecordId { get; set; }
        public required Patient Patient { get; set; }
        public required Doctor Doctor { get; set; }
        public DateTime VisitDate { get; set; }
        public required string Diagnosis { get; set; }
        public required string Prescription { get; set; }
        public required string DoctorNotes { get; set; }

        public string GetSummary()
        {
            return $"Record Id: {RecordId} | Patient: {Patient.FullName} | Doctor: {Doctor.FullName} | Date: {VisitDate.ToShortDateString()} | Diagnosis: {Diagnosis} | Prescription: {Prescription} | Notes: {DoctorNotes}";
        }

        public override string ToString()
        {
            return $"Record Id: {RecordId} | Patient: {Patient} | Doctor: {Doctor} | Visit Date: {VisitDate.ToShortDateString()} | Diagnosis: {Diagnosis} | Prescription: {Prescription} | Doctor Notes: {DoctorNotes}";
        }
    }
}