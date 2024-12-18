﻿// <auto-generated />
using System;
using Consultorio.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Consultorio.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Consultorio.Entities.Consulta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Appoinmentlength")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BeginingScheduleHour")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ConsultorioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("EndingScheduleHour")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PractitionerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ScheduleDay")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConsultorioId");

                    b.HasIndex("PatientId");

                    b.HasIndex("PractitionerId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("Consultorio.Entities.ConsultorioEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("Date");

                    b.Property<int>("MedicalOficceNumber")
                        .HasColumnType("int");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ConsultorioEntity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("39017484-9b5a-406b-a8cd-f62d9a60b46e"),
                            Active = true,
                            CreationDate = new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MedicalOficceNumber = 1,
                            Speciality = "Cardiology"
                        },
                        new
                        {
                            Id = new Guid("500e8c7a-5b2c-4dd7-9728-e9cc9f4d4eb7"),
                            Active = true,
                            CreationDate = new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MedicalOficceNumber = 2,
                            Speciality = "Neumology"
                        },
                        new
                        {
                            Id = new Guid("b9002d5c-415c-419c-a9da-0ac6f6b88243"),
                            Active = true,
                            CreationDate = new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MedicalOficceNumber = 3,
                            Speciality = "Pediatric Cardiology"
                        });
                });

            modelBuilder.Entity("Consultorio.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("Date");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("Consultorio.Entities.Practitioner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("Date");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Practitioner");
                });

            modelBuilder.Entity("Consultorio.Entities.Consulta", b =>
                {
                    b.HasOne("Consultorio.Entities.ConsultorioEntity", "Consultorio")
                        .WithMany("Consultas")
                        .HasForeignKey("ConsultorioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Consultorio.Entities.Patient", "Patient")
                        .WithMany("Consultas")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Consultorio.Entities.Practitioner", "Practitioner")
                        .WithMany("Consultas")
                        .HasForeignKey("PractitionerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultorio");

                    b.Navigation("Patient");

                    b.Navigation("Practitioner");
                });

            modelBuilder.Entity("Consultorio.Entities.ConsultorioEntity", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("Consultorio.Entities.Patient", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("Consultorio.Entities.Practitioner", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
