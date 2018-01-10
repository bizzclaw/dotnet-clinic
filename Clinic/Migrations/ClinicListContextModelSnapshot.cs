using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Clinic.Models;

namespace Clinic.Migrations
{
    [DbContext(typeof(ClinicListContext))]
    partial class ClinicListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Clinic.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("doctors");
                });

            modelBuilder.Entity("Clinic.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("BloodType");

                    b.Property<int>("DoctorId");

                    b.Property<string>("Name");

                    b.Property<bool>("NeedsCare");

                    b.Property<string>("Sex");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("Clinic.Models.Patient", b =>
                {
                    b.HasOne("Clinic.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
