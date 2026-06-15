using HealthCare.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Data
{
    public class HealthCareDbContext : DbContext
    {
        // Db Context connection setup
        public HealthCareDbContext(DbContextOptions<HealthCareDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<HealthRecord> HealthRecords => Set<HealthRecord>();
        public DbSet<AvailableSlots> DoctorAvailableSlots => Set<AvailableSlots>();
        public DbSet<DoctorLeaves> DoctorLeaves => Set<DoctorLeaves>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -- Constraints not expressible via data annotations --

            modelBuilder.Entity<Appointment>()
                .HasIndex(a => new { a.DoctorId, a.ScheduledDate, a.TimeSlot })
                .IsUnique()
                .HasFilter("[Status] != 'Cancelled'")
                .HasDatabaseName("UQ_Appointments_Doctor_Date_Slot");

            modelBuilder.Entity<Appointment>()
                .HasIndex(a => new { a.DoctorId, a.ScheduledDate })
                .HasDatabaseName("IX_Appointments_Doctor_Date");

            modelBuilder.Entity<Appointment>()
                .HasIndex(a => new { a.PatientId, a.ScheduledDate })
                .HasDatabaseName("IX_Appointments_Patient_Date");

            modelBuilder.Entity<HealthRecord>()
                .HasIndex(hr => new { hr.PatientId, hr.VisitDate })
                .HasDatabaseName("IX_HealthRecords_Patient_VisitDate");

            // -- Delete behaviour (can't be set via annotations) --

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne(u => u.Patient)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HealthRecord>()
                .HasOne(hr => hr.Appointment)
                .WithOne(a => a.HealthRecord)
                .HasForeignKey<HealthRecord>(hr => hr.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HealthRecord>()
                .HasOne(hr => hr.Patient)
                .WithMany(p => p.HealthRecords)
                .HasForeignKey(hr => hr.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HealthRecord>()
                .HasOne(hr => hr.Doctor)
                .WithMany(d => d.HealthRecords)
                .HasForeignKey(hr => hr.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // -- Seed data --
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                Email = "doctor1@test.com",

                // Adding sonar exclusion
                #pragma warning disable S2068
                PasswordHash = "$2a$12$3QNBAyYA6NKZfqyX9v14Eexx1qywJJPm1rXPK8ow/fWq6jpnk.1FS",
                #pragma warning restore S2068

                Role = "Doctor",
                CreatedDate = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
            },
            new User
            {
                UserId = 2,
                Email = "patient1@test.com",

                // Adding sonar exclusion
                #pragma warning disable S2068
                PasswordHash = "$2a$12$3QNBAyYA6NKZfqyX9v14Eexx1qywJJPm1rXPK8ow/fWq6jpnk.1FS",
                #pragma warning restore S2068

                Role = "Patient",
                CreatedDate = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero),
            }
);
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, UserId = 1, FullName = "Dr. Anil Mehta", Specialisation = "Cardiology", YearsOfExperience = 12, ConsultationFee = 800, IsActive = true, CreatedDate = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero) }
                );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = 1, UserId = 2, FullName = "Arjun Raj", DateOfBirth = new DateOnly(1990, 5, 12), Gender = "Male", PhoneNumber = "9876543210", CreatedDate = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero) }
                );
        }
    }
}