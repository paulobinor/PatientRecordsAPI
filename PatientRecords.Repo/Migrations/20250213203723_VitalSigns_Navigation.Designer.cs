﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientRecords.Repo;

#nullable disable

namespace PatientRecords.Repo.Migrations
{
    [DbContext(typeof(SQLiteDbContext))]
    [Migration("20250213203723_VitalSigns_Navigation")]
    partial class VitalSigns_Navigation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("PatientRecords.Core.models.Consultation", b =>
                {
                    b.Property<Guid>("ConsultationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("TEXT");

                    b.HasKey("ConsultationId");

                    b.HasIndex("PatientId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("PatientRecords.Core.models.Medication", b =>
                {
                    b.Property<Guid>("MedicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DrugName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PrescriptionId")
                        .HasColumnType("TEXT");

                    b.HasKey("MedicationId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("PatientRecords.Core.models.Patient", b =>
                {
                    b.Property<Guid>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            PatientId = new Guid("e8597616-e7eb-4395-9630-50100bfbee3a"),
                            DateOfBirth = new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            Gender = "M",
                            IsDeleted = (byte)0,
                            Surname = "Doe"
                        },
                        new
                        {
                            PatientId = new Guid("4240c65f-f39b-4eed-b8a3-7e13a6eb9f55"),
                            DateOfBirth = new DateTime(1985, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Alice",
                            Gender = "F",
                            IsDeleted = (byte)0,
                            Surname = "Smith"
                        });
                });

            modelBuilder.Entity("PatientRecords.Core.models.Prescription", b =>
                {
                    b.Property<Guid>("PrescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorizingMedic")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("InstructionNotes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("IsDeleted")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PrescriptionDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PrescriptionId");

                    b.HasIndex("PatientId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("PatientRecords.Core.models.VitalSign", b =>
                {
                    b.Property<Guid>("VitalSignsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BMI")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pulse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Respiration")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Temperature")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("VitalSignsId");

                    b.HasIndex("PatientId");

                    b.ToTable("VitalSigns");
                });

            modelBuilder.Entity("PatientRecords.Core.models.Consultation", b =>
                {
                    b.HasOne("PatientRecords.Core.models.Patient", null)
                        .WithMany("Consultations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PatientRecords.Core.models.Medication", b =>
                {
                    b.HasOne("PatientRecords.Core.models.Patient", null)
                        .WithMany("Medications")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatientRecords.Core.models.Prescription", null)
                        .WithMany("Medications")
                        .HasForeignKey("PrescriptionId");
                });

            modelBuilder.Entity("PatientRecords.Core.models.Prescription", b =>
                {
                    b.HasOne("PatientRecords.Core.models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PatientRecords.Core.models.VitalSign", b =>
                {
                    b.HasOne("PatientRecords.Core.models.Patient", null)
                        .WithMany("VitalSigns")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PatientRecords.Core.models.Patient", b =>
                {
                    b.Navigation("Consultations");

                    b.Navigation("Medications");

                    b.Navigation("VitalSigns");
                });

            modelBuilder.Entity("PatientRecords.Core.models.Prescription", b =>
                {
                    b.Navigation("Medications");
                });
#pragma warning restore 612, 618
        }
    }
}
