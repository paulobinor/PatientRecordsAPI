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
                new Patient { PatientId = System.Guid.Parse("e8597616-e7eb-4395-9630-50100bfbee3a"), FirstName = "John", Surname = "Doe", DateOfBirth = Convert.ToDateTime("1990-05-10"), Gender = "M", IsDeleted = 0 },
                new Patient { PatientId = System.Guid.Parse("4240c65f-f39b-4eed-b8a3-7e13a6eb9f55"), FirstName = "Alice", Surname = "Smith", DateOfBirth = Convert.ToDateTime("1985-07-20"), Gender = "F", IsDeleted = 0 }
            );
        }
    }
}
