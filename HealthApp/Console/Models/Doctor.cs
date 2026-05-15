using System;
using System.Collections.Generic;
using System.Linq;

public class Doctor
{
    public int DoctorId { get; set; }
    public string FullName { get; set; } = "";
    public string Specialisation { get; set; } = "";
    public int YearsOfExperience { get; set; }
    public decimal ConsultationFee { get; set; }
    public bool IsActive { get; set; }

    public List<DateTime> Appointments { get; set; } = new List<DateTime>();

    public bool IsAvailable(DateTime date)
    {
        return Appointments.Any(a => a.Date == date.Date);
    }

    public string GetScheduleSummary()
    {
        int count = Appointments.Count(a => a.Date >= DateTime.Today);
        return "Upcoming appointments count: " + count;
    }

    public string GetDoctorDetails()
    {
        return "Doctor ID: " + DoctorId +
               "\nFull Name: " + FullName +
               "\nSpecialisation: " + Specialisation +
               "\nYears Of Experience: " + YearsOfExperience +
               "\nConsultation Fee: Rs. " + ConsultationFee +
               "\nActive: " + (IsActive ? "Yes" : "No");
    }
}