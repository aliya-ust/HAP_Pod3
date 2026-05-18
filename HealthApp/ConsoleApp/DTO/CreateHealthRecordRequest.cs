public class CreateHealthRecordRequest
{
    public int RecordId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId   { get; set; }
    public string VisitDate { get; set; }
    public string Diagnosis { get; set; }
    public string Prescription { get; set; }
    public string Notes { get; set; }
}