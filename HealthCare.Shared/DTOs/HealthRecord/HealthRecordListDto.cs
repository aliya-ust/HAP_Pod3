namespace HealthCare.Shared.DTOs.HealthRecord
{
    public class HealthRecordListDto
    {
        public int RecordId { get; set; }
        public string PatientName { get; set; } = null!;
        public string DoctorName { get; set; } = null!;
        public DateOnly VisitDate { get; set; }
        public string Diagnosis { get; set; } = null!;
        public string Prescription { get; set; } = null!;
        public string? Notes { get; set; }
    }
}
