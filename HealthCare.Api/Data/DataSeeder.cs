using HealthCare.Api.Constants;
using HealthCare.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Data
{
    public static class DataSeeder
    {
        public static async Task SeedTestDataAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HealthCareDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            await SeedDoctorUser(context, userManager);
            await SeedPatientUser(context, userManager);
            await context.SaveChangesAsync();

            var doctor = await context.Doctors.FirstOrDefaultAsync(d => d.FullName == "Dr. Anil Mehta");
            var patient = await context.Patients.FirstOrDefaultAsync(p => p.FullName == "Arjun Raj");
            if (doctor == null || patient == null) return;

            var tomorrow = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
            var dayAfter = DateOnly.FromDateTime(DateTime.Today.AddDays(2));
            var nextWeek = DateOnly.FromDateTime(DateTime.Today.AddDays(7));

            if (!await context.Appointments.AnyAsync())
            {
                context.Appointments.AddRange(
                    new Appointment
                    {
                        PatientId = patient.PatientId,
                        DoctorId = doctor.DoctorId,
                        ScheduledDate = tomorrow,
                        TimeSlot = "09:00",
                        Status = AppointmentStatus.Pending,
                        CreatedDate = DateTimeOffset.UtcNow,
                    },
                    new Appointment
                    {
                        PatientId = patient.PatientId,
                        DoctorId = doctor.DoctorId,
                        ScheduledDate = tomorrow,
                        TimeSlot = "10:00",
                        Status = AppointmentStatus.Completed,
                        CreatedDate = DateTimeOffset.UtcNow,
                    },
                    new Appointment
                    {
                        PatientId = patient.PatientId,
                        DoctorId = doctor.DoctorId,
                        ScheduledDate = dayAfter,
                        TimeSlot = "11:00",
                        Status = AppointmentStatus.Pending,
                        CreatedDate = DateTimeOffset.UtcNow,
                    },
                    new Appointment
                    {
                        PatientId = patient.PatientId,
                        DoctorId = doctor.DoctorId,
                        ScheduledDate = nextWeek,
                        TimeSlot = "11:00",
                        Status = AppointmentStatus.Confirmed,
                        CreatedDate = DateTimeOffset.UtcNow,
                    }
                );

                await context.SaveChangesAsync();

                var confirmedAppt = await context.Appointments
                    .FirstAsync(a => a.ScheduledDate == tomorrow && a.TimeSlot == "10:00");

                if (!await context.HealthRecords.AnyAsync())
                {
                    context.HealthRecords.Add(new HealthRecord
                    {
                        AppointmentId = confirmedAppt.AppointmentId,
                        PatientId = patient.PatientId,
                        DoctorId = doctor.DoctorId,
                        VisitDate = tomorrow,
                        Diagnosis = "Regular checkup - mild hypertension",
                        Prescription = "Prescribed lifestyle changes and follow-up in 3 months",
                        Notes = "Patient advised to reduce salt intake and exercise regularly",
                        CreatedDate = DateTimeOffset.UtcNow,
                    });

                    await context.SaveChangesAsync();
                }
            }
        }

        private static async Task SeedDoctorUser(HealthCareDbContext context, UserManager<User> userManager)
        {
            var doctorUser = await userManager.FindByEmailAsync("doctor@test.com");

            if (doctorUser == null)
            {
                doctorUser = new User
                {
                    UserName = "doctor@test.com",
                    Email = "doctor@test.com",
                    EmailConfirmed = true,
                };
                var result = await userManager.CreateAsync(doctorUser, "Doctor@123");
                if (!result.Succeeded)
                    throw new InvalidOperationException("Doctor user creation failed: " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));

                await userManager.AddToRoleAsync(doctorUser, "Doctor");
            }

            if (!await context.Doctors.AnyAsync(d => d.UserId == doctorUser.Id))
            {
                context.Doctors.Add(new Doctor
                {
                    FullName = "Dr. Anil Mehta",
                    Specialisation = "Cardiology",
                    YearsOfExperience = 12,
                    ConsultationFee = 800,
                    IsActive = true,
                    CreatedDate = DateTimeOffset.UtcNow,
                    UserId = doctorUser.Id,
                });
            }
        }

        private static async Task SeedPatientUser(HealthCareDbContext context, UserManager<User> userManager)
        {
            var patientUser = await userManager.FindByEmailAsync("patient@test.com");

            if (patientUser == null)
            {
                patientUser = new User
                {
                    UserName = "patient@test.com",
                    Email = "patient@test.com",
                    EmailConfirmed = true,
                };
                var result = await userManager.CreateAsync(patientUser, "Patient@123");
                if (!result.Succeeded)
                    throw new InvalidOperationException("Patient user creation failed: " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));

                await userManager.AddToRoleAsync(patientUser, "Patient");
            }

            if (!await context.Patients.AnyAsync(p => p.UserId == patientUser.Id))
            {
                context.Patients.Add(new Patient
                {
                    FullName = "Arjun Raj",
                    DateOfBirth = new DateOnly(1990, 5, 12),
                    Gender = "Male",
                    PhoneNumber = "9876543210",
                    CreatedDate = DateTimeOffset.UtcNow,
                    UserId = patientUser.Id,
                });
            }
        }
    }
}
