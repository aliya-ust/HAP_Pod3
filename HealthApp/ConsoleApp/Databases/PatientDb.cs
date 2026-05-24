using HealthApp.ConsoleApp.Models;

namespace HealthApp.ConsoleApp.Databases;

public class PatientDb
{
    private List<Patient> _patients = new List<Patient>();

    public List<Patient> Patients
    {
        get { return _patients; }
        set { _patients = value; }
    }

}
