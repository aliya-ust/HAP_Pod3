using HealthApp.ConsoleApp.Models;
namespace HealthApp.ConsoleApp.Databases

{
    public class AppointmentDb
    {

        public List<Appointment> appointments = new List<Appointment>
    {

        new Appointment{Id = 1, Patient = new Patient{Id = 1, Name = "John Doe"}, Doctor = new Doctor{Id = 1, FullName = "Dr. Smith"}, ScheduledDate = DateTime.Now.AddDays(1), TimeSlot = "10:00 AM", Status = AppointmentStatus.Confirmed},

        new Appointment{Id = 2, Patient = new Patient{Id = 2, Name = "Jane Doe"}, Doctor = new Doctor{Id = 2, FullName = "Dr. Brown"}, ScheduledDate = DateTime.Now.AddDays(2), TimeSlot = "11:00 AM", Status = AppointmentStatus.Pending},

        new Appointment{Id = 3, Patient = new Patient{Id = 3, Name = "Alice Smith"}, Doctor = new Doctor{Id = 1, FullName = "Dr. Smith"}, ScheduledDate = DateTime.Now.AddDays(3), TimeSlot = "02:00 PM", Status = AppointmentStatus.Cancelled, CancellationReason = "Patient requested cancellation"},

        new Appointment{Id = 4, Patient = new Patient{Id = 4, Name = "Bob Johnson"}, Doctor = new Doctor{Id = 3, FullName = "Dr. Green"}, ScheduledDate = DateTime.Now.AddDays(4), TimeSlot = "03:00 PM", Status = AppointmentStatus.Completed}

    };


    }

}