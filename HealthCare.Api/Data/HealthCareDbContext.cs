using HealthCare.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Data
{
    public class HealthCareDbContext : IdentityDbContext<User>
    {
        // Db Context connection setup
        public HealthCareDbContext(DbContextOptions<HealthCareDbContext> options) : base(options) { }

        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<HealthRecord> HealthRecords => Set<HealthRecord>();
        public DbSet<AvailableSlots> AvailableSlots => Set<AvailableSlots>();
        public DbSet<DoctorLeaves> DoctorLeaves => Set<DoctorLeaves>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // -- Constraints not expressible via data annotations --

            builder.Entity<Appointment>()
                .HasIndex(a => new { a.DoctorId, a.ScheduledDate, a.TimeSlot })
                .IsUnique()
                .HasFilter("[Status] != 'Cancelled'")
                .HasDatabaseName("UQ_Appointments_Doctor_Date_Slot");

            builder.Entity<Appointment>()
                .HasIndex(a => new { a.DoctorId, a.ScheduledDate })
                .HasDatabaseName("IX_Appointments_Doctor_Date");

            builder.Entity<Appointment>()
                .HasIndex(a => new { a.PatientId, a.ScheduledDate })
                .HasDatabaseName("IX_Appointments_Patient_Date");

            builder.Entity<HealthRecord>()
                .HasIndex(hr => new { hr.PatientId, hr.VisitDate })
                .HasDatabaseName("IX_HealthRecords_Patient_VisitDate");

            builder.Entity<HealthRecord>()
                .Property(hr => hr.VisitDate)
                .HasColumnType("date");

            // -- Delete behaviour (can't be set via annotations) --

            builder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<HealthRecord>()
                .HasOne(hr => hr.Appointment)
                .WithOne(a => a.HealthRecord)
                .HasForeignKey<HealthRecord>(hr => hr.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<HealthRecord>()
                .HasOne(hr => hr.Patient)
                .WithMany(p => p.HealthRecords)
                .HasForeignKey(hr => hr.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<HealthRecord>()
                .HasOne(hr => hr.Doctor)
                .WithMany(d => d.HealthRecords)
                .HasForeignKey(hr => hr.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // -- Seed data --
            SeedData(builder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, FullName = "Dr. Anil Mehta", Specialisation = "Cardiology", YearsOfExperience = 12, ConsultationFee = 800, IsActive = true, CreatedDate = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero) }
                );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = 1, FullName = "Arjun Raj", DateOfBirth = new DateOnly(1990, 5, 12), Gender = "Male", PhoneNumber = "9876543210", CreatedDate = new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero) }
                );
        }
    }
}