using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Api.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace HealthCare.Tests.Services
{
    public class DashboardServiceTests
    {
        private static HealthCareDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<HealthCareDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new HealthCareDbContext(options);
        }

        private static DashboardService GetService(HealthCareDbContext context)
        {
            var logger = new Mock<ILogger<DashboardService>>();


            logger.Setup(x => x.IsEnabled(It.IsAny<LogLevel>()))
                      .Returns(true);


            return new DashboardService(
                context,
                logger.Object);
        }

        private static Doctor CreateDoctor(int id = 1, bool active = true, int fee = 500)
        {
            return new Doctor
            {
                DoctorId = id,
                FullName = "Doctor " + id,
                YearsOfExperience = 5,
                ConsultationFee = fee,
                Specialisation = "Cardiology",
                IsActive = active
            };
        }

        private static Patient CreatePatient(int id = 1)
        {
            return new Patient
            {
                PatientId = id,
                FullName = "Patient " + id,
                DateOfBirth = new DateOnly(2000, 1, 1),
                Gender = "Female",
                PhoneNumber = "9876543210",
                CreatedDate = DateTimeOffset.UtcNow,
                IsActive = true
            };
        }

        private static Appointment CreateAppointment(
            int patientId,
            int doctorId,
            string status,
            DateOnly date,
            string slot = "09:00 AM")
        {
            return new Appointment
            {
                PatientId = patientId,
                DoctorId = doctorId,
                ScheduledDate = date,
                TimeSlot = slot,
                Status = status
            };
        }

        [Fact]
        public async Task GetDashboardSummaryAsync_ShouldReturnDoctorCount()
        {
            var context = GetDbContext();

            context.Doctors.Add(CreateDoctor(1));
            context.Doctors.Add(CreateDoctor(2));

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDashboardSummaryAsync();

            Assert.Equal(2, result.TotalDoctors);
        }

        [Fact]
        public async Task GetDashboardSummaryAsync_ShouldReturnActiveDoctorCount()
        {
            var context = GetDbContext();

            context.Doctors.Add(CreateDoctor(1, true));
            context.Doctors.Add(CreateDoctor(2, false));
            context.Doctors.Add(CreateDoctor(3, true));

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDashboardSummaryAsync();

            Assert.Equal(2, result.ActiveDoctors);
        }

        [Fact]
        public async Task GetDashboardSummaryAsync_ShouldReturnPatientCount()
        {
            var context = GetDbContext();

            context.Patients.Add(CreatePatient(1));
            context.Patients.Add(CreatePatient(2));
            context.Patients.Add(CreatePatient(3));

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDashboardSummaryAsync();

            Assert.Equal(3, result.TotalPatients);
        }

        [Fact]
        public async Task GetDashboardSummaryAsync_ShouldReturnAppointmentCount()
        {
            var context = GetDbContext();

            var doctor = CreateDoctor();
            var patient = CreatePatient();

            context.Doctors.Add(doctor);
            context.Patients.Add(patient);

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "09:00 AM",
                Status = "Pending"
            });

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                TimeSlot = "10:00 AM",
                Status = "Confirmed"
            });

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDashboardSummaryAsync();

            Assert.Equal(2, result.TotalAppointments);
        }

        [Fact]
        public async Task GetDashboardSummaryAsync_ShouldReturnPendingAppointmentCount()
        {
            var context = GetDbContext();

            var doctor = CreateDoctor();
            var patient = CreatePatient();

            context.Doctors.Add(doctor);
            context.Patients.Add(patient);

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = 1,
                PatientId = 1,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "09:00 AM",
                Status = "Pending"
            });

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = 1,
                PatientId = 1,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                TimeSlot = "10:00 AM",
                Status = "Confirmed"
            });

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDashboardSummaryAsync();

            Assert.Equal(1, result.PendingAppointments);
        }

        [Fact]
        public async Task GetDashboardSummaryAsync_ShouldReturnConfirmedAppointmentCount()
        {
            var context = GetDbContext();

            var doctor = CreateDoctor();
            var patient = CreatePatient();

            context.Doctors.Add(doctor);
            context.Patients.Add(patient);

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "09:00 AM",
                Status = "Confirmed"
            });

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                TimeSlot = "10:00 AM",
                Status = "Confirmed"
            });

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDashboardSummaryAsync();

            Assert.Equal(2, result.ConfirmedAppointments);
        }

        [Fact]
        public async Task GetDashboardSummaryAsync_ShouldReturnCancelledAppointmentCount()
        {
            var context = GetDbContext();

            var doctor = CreateDoctor();
            var patient = CreatePatient();

            context.Doctors.Add(doctor);
            context.Patients.Add(patient);

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "09:00 AM",
                Status = "Cancelled"
            });

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                TimeSlot = "10:00 AM",
                Status = "Confirmed"
            });

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDashboardSummaryAsync();

            Assert.Equal(1, result.CancelledAppointments);
        }

        [Fact]
        public async Task GetDashboardSummaryAsync_ShouldReturnCompletedAppointmentCount()
        {
            var context = GetDbContext();

            var doctor = CreateDoctor();
            var patient = CreatePatient();

            context.Doctors.Add(doctor);
            context.Patients.Add(patient);

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "09:00 AM",
                Status = "Completed"
            });

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                TimeSlot = "10:00 AM",
                Status = "Pending"
            });

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDashboardSummaryAsync();

            Assert.Equal(1, result.CompletedAppointments);
        }

        [Fact]
        public async Task GetDashboardSummaryAsync_ShouldReturnRevenue()
        {
            var context = GetDbContext();

            var doctor = CreateDoctor(1, true, 800);
            var patient = CreatePatient();

            context.Doctors.Add(doctor);
            context.Patients.Add(patient);

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "09:00 AM",
                Status = "Completed"
            });

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDashboardSummaryAsync();

            Assert.Equal(800, result.TotalRevenue);
        }

        [Fact]
        public async Task GetDashboardSummaryAsync_ShouldReturnZeroRevenue_WhenNoCompletedAppointments()
        {
            var context = GetDbContext();

            var doctor = CreateDoctor(1, true, 1000);
            var patient = CreatePatient();

            context.Doctors.Add(doctor);
            context.Patients.Add(patient);

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "09:00 AM",
                Status = "Pending"
            });

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDashboardSummaryAsync();

            Assert.Equal(0, result.TotalRevenue);
        }

        [Fact]
        public async Task GetPatientDashboardSummaryAsync_ShouldReturnPatientName()
        {
            var context = GetDbContext();

            var patient = CreatePatient(1);

            context.Patients.Add(patient);

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetPatientDashboardSummaryAsync(1);

            Assert.Equal("Patient 1", result.PatientName);
        }

        [Fact]
        public async Task GetPatientDashboardSummaryAsync_ShouldReturnUpcomingAppointments()
        {
            var context = GetDbContext();

            var doctor = CreateDoctor();
            var patient = CreatePatient();

            context.Doctors.Add(doctor);
            context.Patients.Add(patient);

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
                TimeSlot = "09:00 AM",
                Status = "Confirmed"
            });

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetPatientDashboardSummaryAsync(patient.PatientId);

            Assert.Equal(1, result.UpcomingAppointments);
        }

        [Fact]
        public async Task GetDoctorDashboardSummaryAsync_ShouldReturnCompletedAppointments()
        {
            var context = GetDbContext();

            var doctor = CreateDoctor();
            var patient = CreatePatient();

            context.Doctors.Add(doctor);
            context.Patients.Add(patient);

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "09:00 AM",
                Status = "Completed"
            });

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDoctorDashboardSummaryAsync(doctor.DoctorId);

            Assert.Equal(1, result.CompletedAppointments);
        }

        [Fact]
        public async Task GetDoctorDashboardSummaryAsync_ShouldReturnTodayAppointments()
        {
            var context = GetDbContext();

            var doctor = CreateDoctor();
            var patient = CreatePatient();

            context.Doctors.Add(doctor);
            context.Patients.Add(patient);

            context.Appointments.Add(new Appointment
            {
                Doctor = doctor,
                Patient = patient,
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                ScheduledDate = DateOnly.FromDateTime(DateTime.Today),
                TimeSlot = "09:00 AM",
                Status = "Confirmed"
            });

            await context.SaveChangesAsync();

            var service = GetService(context);

            var result = await service.GetDoctorDashboardSummaryAsync(doctor.DoctorId);

            Assert.Single(result.TodayAppointments);
            Assert.Equal("09:00 AM", result.TodayAppointments[0].Slot);
        }
    }
}