using HealthCareApi.Data.Seed;
using HealthCareApi.Models;
using HealthCareApi.Models.Views;
using System.Data.Entity;

namespace HealthCareApi.Data.Context
{
    public class HealthCareDbContext : DbContext
    {
        public HealthCareDbContext()
            : base("name=HealthCareConnection")   // matches Web.config connection string
        {
            Database.SetInitializer(new HealthCareDbInitializer());
        }

        // Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<DoctorAvailableSlot> DoctorAvailableSlots { get; set; }
        public DbSet<DoctorLeave> DoctorLeaves { get; set; }

        // Views (read-only)
        //public DbSet<VwPatientAppointment> VwPatientAppointments { get; set; }
        //public DbSet<VwDoctorSchedule> VwDoctorSchedules { get; set; }
        //public DbSet<VwPatientHealthHistory> VwPatientHealthHistories { get; set; }
        //public DbSet<VwDoctorProfile> VwDoctorProfiles { get; set; }
        //public DbSet<VwPatientProfile> VwPatientProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----------------------------------------------------------
            // User -> Patient (optional 1-to-1)
            // EF6 maps as one-to-many; UNIQUE on UserId enforces 1-to-1 in DB
            // ----------------------------------------------------------
            modelBuilder.Entity<Patient>()
                .HasOptional(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId);

            // ----------------------------------------------------------
            // User -> Doctor (required 1-to-1)
            // Same pattern — UNIQUE on UserId enforces 1-to-1 in DB
            // ----------------------------------------------------------
            modelBuilder.Entity<Doctor>()
                .HasRequired(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId);

            // ----------------------------------------------------------
            // Appointment -> HealthRecord (optional 1-to-1)
            // HealthRecord.AppointmentId is FK; UNIQUE enforces 1-to-1 in DB
            // ----------------------------------------------------------
            modelBuilder.Entity<HealthRecord>()
                .HasRequired(hr => hr.Appointment)
                .WithOptional(a => a.HealthRecord);

            // ----------------------------------------------------------
            // Appointment -> Patient / Doctor (many-to-one, straightforward)
            // ----------------------------------------------------------
            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasRequired(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            // ----------------------------------------------------------
            // Doctor -> Slots / Leaves (one-to-many, straightforward)
            // ----------------------------------------------------------
            modelBuilder.Entity<DoctorAvailableSlot>()
                .HasRequired(s => s.Doctor)
                .WithMany(d => d.AvailableSlots)
                .HasForeignKey(s => s.DoctorId);

            modelBuilder.Entity<DoctorLeave>()
                .HasRequired(l => l.Doctor)
                .WithMany(d => d.Leaves)
                .HasForeignKey(l => l.DoctorId);
        }
    }
}