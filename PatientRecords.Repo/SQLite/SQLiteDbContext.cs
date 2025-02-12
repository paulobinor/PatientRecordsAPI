using Microsoft.EntityFrameworkCore;
using PatientRecords.Core.models;

namespace PatientRecords.Repo
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<VitalSign> vitalSigns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.VitalSigns)
                .WithOne(r => r.Patient)
                .HasForeignKey(r => r.PatientId);


            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Consultations)
                .WithOne(r => r.Patient)
                .HasForeignKey(r => r.PatientId);


            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Prescriptions)
                .WithOne(r => r.Patient)
                .HasForeignKey(r => r.PatientId);


            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Medications)
                .WithOne(r => r.Patient)
                .HasForeignKey(r => r.PatientId);
        }
    }
}
