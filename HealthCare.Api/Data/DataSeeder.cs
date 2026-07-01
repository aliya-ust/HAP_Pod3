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

            // Always seed users regardless of existing data
            await SeedDoctorUser(context, userManager);
            await SeedPatientUser(context, userManager);
            await context.SaveChangesAsync();

            // Only seed appointments if none exist
            var tomorrow = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
            var dayAfter = DateOnly.FromDateTime(DateTime.Today.AddDays(2));
            var nextWeek = DateOnly.FromDateTime(DateTime.Today.AddDays(7));

            if (!await context.Appointments.AnyAsync())
            {
                context.Appointments.AddRange(
                    new Appointment
                    {
                        PatientId = 3,
                        DoctorId = 3,
                        ScheduledDate = tomorrow,
                        TimeSlot = "09:00",
                        Status = AppointmentStatus.Pending,
                        CreatedDate = DateTimeOffset.UtcNow,
                    },
                    new Appointment
                    {
                        PatientId = 3,
                        DoctorId = 3,
                        ScheduledDate = tomorrow,
                        TimeSlot = "10:00",
                        Status = AppointmentStatus.Completed,
                        CreatedDate = DateTimeOffset.UtcNow,
                    },
                    new Appointment
                    {
                        PatientId = 3,
                        DoctorId = 3,
                        ScheduledDate = dayAfter,
                        TimeSlot = "11:00",
                        Status = AppointmentStatus.Pending,
                        CreatedDate = DateTimeOffset.UtcNow,
                    },
                    new Appointment
                    {
                        PatientId = 3,
                        DoctorId = 3,
                        ScheduledDate = nextWeek,
                        TimeSlot = "11:00",
                        Status = AppointmentStatus.Confirmed,
                        CreatedDate = DateTimeOffset.UtcNow,
                    }
                );

                await context.SaveChangesAsync();

                // Seed a health record for the confirmed appointment
                var confirmedAppt = await context.Appointments
                    .FirstAsync(a => a.ScheduledDate == tomorrow && a.TimeSlot == "10:00");

                if (!await context.HealthRecords.AnyAsync())
                {
                    context.HealthRecords.Add(new HealthRecord
                    {
                        AppointmentId = confirmedAppt.AppointmentId,
                        PatientId = 3,
                        DoctorId = 3,
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
            if (doctorUser != null) return;

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

            var doctor = await context.Doctors.FindAsync(3);
            if (doctor != null)
            {
                doctor.UserId = doctorUser.Id;
            }
        }

        private static async Task SeedPatientUser(HealthCareDbContext context, UserManager<User> userManager)
        {
            var patientUser = await userManager.FindByEmailAsync("patient@test.com");
            if (patientUser != null) return;

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

            var patient = await context.Patients.FindAsync(3);
            if (patient != null)
            {
                patient.UserId = patientUser.Id;
            }
        }
    }
}
