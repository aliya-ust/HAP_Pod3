using HealthApp.ConsoleApp.Models;
using Microsoft.VisualBasic;
namespace HealthApp.ConsoleApp.Databases
{
public class AppointmentDb
{
    PatientDb patientDb = new PatientDb();
    DoctorDb doctorDb = new DoctorDb();
    public List<Appointment> appointments ;
    public AppointmentDb()
    {
        appointments = new List<Appointment>
        {
        // new Appointment{AppointmentId = 301, Patient = new Patient{PatientId = 1, Name = "John Doe"}, Doctor = new Doctor{DoctorId = 207, Name = "Dr. Smith"}, ScheduledDate = DateTime.Now.AddDays(1), TimeSlot = "10:00 AM", Status = AppointmentStatus.Confirmed},
        // new Appointment{AppointmentId = 302, Patient = new Patient{PatientId = 2, Name = "Jane Doe"}, Doctor = new Doctor{DoctorId = 208, Name = "Dr. Brown"}, ScheduledDate = DateTime.Now.AddDays(2), TimeSlot = "11:00 AM", Status = AppointmentStatus.Pending},
        // new Appointment{AppointmentId = 303, Patient = new Patient{PatientId = 3, Name = "Alice Smith"}, Doctor = new Doctor{DoctorId = 209, Name = "Dr. Smith"}, ScheduledDate = DateTime.Now.AddDays(3), TimeSlot = "02:00 PM", Status = AppointmentStatus.Cancelled, CancellationReason = "Patient requested cancellation"},
        // new Appointment{AppointmentId = 304, Patient = new Patient{PatientId = 4, Name = "Bob Johnson"}, Doctor = new Doctor{DoctorId = 210, Name = "Dr. Green"}, ScheduledDate = DateTime.Now.AddDays(4), TimeSlot = "03:00 PM", Status = AppointmentStatus.Completed},
       // new Appointment{AppointmentId = 305, Patient= patientDb.Patients.FirstOrDefault(p => p.PatientId == 101),Doctor= doctorDb.Doctors.FirstOrDefault(d => d.DoctorId == 202), ScheduledDate=doctorDb.Doctors.FirstOrDefault(d => d.DoctorId == 202).ScheduledDate, TimeSlot = "09:00 AM", Status = AppointmentStatus.Confirmed}
         new Appointment
                {
                    AppointmentId = 301,

                    Patient = patientDb.Patients
                        .FirstOrDefault(p => p.PatientId == 101),

                    Doctor = doctorDb.Doctors
                        .FirstOrDefault(d => d.DoctorId == 201),

                   ScheduledDate = DateTime.Today.AddDays(1),

                    TimeSlot = "10:00 AM",

                    Status = AppointmentStatus.Confirmed
                },

                new Appointment
                {
                    AppointmentId = 302,

                    Patient = patientDb.Patients
                        .FirstOrDefault(p => p.PatientId == 102),

                    Doctor = doctorDb.Doctors
                        .FirstOrDefault(d => d.DoctorId == 202),

                    ScheduledDate = DateTime.Today.AddDays(2),

                    TimeSlot = "12:00 PM",

                    Status = AppointmentStatus.Pending
                }
            
    };

    }
}
}