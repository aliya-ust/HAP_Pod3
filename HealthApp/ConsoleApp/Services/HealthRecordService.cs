using System;
using System.Collections.Generic;
using System.Linq;

//Temporary HealthRecord class for sampling
public class HealthRecord
{
    public int RecordId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime VisitDate { get; set; }
}


public class HealthRecordService
{
    private List<HealthRecord> _records = new List<HealthRecord>();

    //Add new record
    public void AddRecord(HealthRecord record)
    {
        
    }

    //Get records by patient ID in descending order of VisitDate
    public IEnumerable<HealthRecord> GetRecordsByPatient(int patientId)
    {
        return _records;
    }

    //Get records by doctor ID in descending order of VisitDate
    public IEnumerable<HealthRecord> GetRecordsByDoctor(int doctorId)
    {
        return _records;
    }
}