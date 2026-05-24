
using HealthApp.ConsoleApp.Exceptions;
using HealthApp.ConsoleApp.Interfaces;
using HealthApp.ConsoleApp.Models;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepo;

    public PatientService(IPatientRepository patientRepo)
    {
        this._patientRepo = patientRepo;
    }

    private void ValidatePatient(Patient patient)
    {
        if (patient == null)
            throw new PatientInvalidException();

        if (string.IsNullOrWhiteSpace(patient.Name))
            throw new PatientInvalidException();

        if (patient.Dob > DateTime.Now)
            throw new PatientInvalidException();
    }

    public void AddPatient(Patient patient)
    {
        //ValidatePatient(patient);
        _patientRepo.AddPatient(patient);
    }

    public void UpdatePatient(Patient patient)
    {
        ValidatePatient(patient);

        var existing = _patientRepo.GetPatientById(patient.Id);

        _patientRepo.UpdatePatient(patient);
    }

    public void DeletePatient(int id)
    {
        if (id <= 0)
            throw new PatientInvalidException();

        var patient = _patientRepo.GetPatientById(id);
        if (patient == null)
            throw new PatientNotFoundException();

        _patientRepo.DeletePatient(id);
    }

    public Patient GetPatientById(int id)
    {
        var patient = _patientRepo.GetPatientById(id);

        if (patient == null)
            throw new PatientNotFoundException();

        return patient;
    }

    public List<Patient> GetAllPatients()
    {
        return _patientRepo.GetAllPatients();
    }

    public int GetPatientAge(int id)
    {
        return GetPatientById(id).GetAge();
    }

    public string GetPatientProfileSummary(int id)
    {
        return GetPatientById(id).GetProfileSummary();
    }
}
