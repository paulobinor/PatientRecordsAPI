using Microsoft.EntityFrameworkCore;
using PatientRecords.Core.models;
using System;

namespace PatientRecords.Repo
{
    public class SQLiteDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<VitalSign> VitalSigns { get; set; }

        public SQLiteDbContext(DbContextOptions<SQLiteDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Sample Data
            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = Guid.NewGuid(), FirstName = "John", Surname = "Doe", DateOfBirth = new DateTime(1990, 5, 10), Gender = "M", IsDeleted = 0 },
                new Patient { PatientId = Guid.NewGuid(), FirstName = "Alice", Surname = "Smith", DateOfBirth = new DateTime(1985, 7, 20), Gender = "F", IsDeleted = 0 }
            );
        }
    }
}
