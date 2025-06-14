﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.AvailableProgram", b =>
                {
                    b.Property<int>("AvailableProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvailableProgramId"));

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<int>("WashingMachineId")
                        .HasColumnType("int");

                    b.HasKey("AvailableProgramId");

                    b.HasIndex("ProgramId");

                    b.HasIndex("WashingMachineId");

                    b.ToTable("Available_Program");

                    b.HasData(
                        new
                        {
                            AvailableProgramId = 1,
                            Price = 100.99m,
                            ProgramId = 1,
                            WashingMachineId = 1
                        },
                        new
                        {
                            AvailableProgramId = 2,
                            Price = 120.99m,
                            ProgramId = 2,
                            WashingMachineId = 1
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "999999999"
                        },
                        new
                        {
                            CustomerId = 2,
                            FirstName = "Jane",
                            LastName = "Doe",
                            PhoneNumber = "999999999"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.MyProgram", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgramId"));

                    b.Property<int>("DurationMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TemperatureCelsius")
                        .HasColumnType("int");

                    b.HasKey("ProgramId");

                    b.ToTable("Program");

                    b.HasData(
                        new
                        {
                            ProgramId = 1,
                            DurationMinutes = 2,
                            Name = "Program1",
                            TemperatureCelsius = 12
                        },
                        new
                        {
                            ProgramId = 2,
                            DurationMinutes = 10,
                            Name = "Program2",
                            TemperatureCelsius = 12
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.PurchaseHistory", b =>
                {
                    b.Property<int>("AvailableProgramId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("AvailableProgramId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Purchase_History");

                    b.HasData(
                        new
                        {
                            AvailableProgramId = 1,
                            CustomerId = 1,
                            PurchaseDate = new DateTime(2025, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 12
                        },
                        new
                        {
                            AvailableProgramId = 2,
                            CustomerId = 2,
                            PurchaseDate = new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Rating = 10
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.WashingMachine", b =>
                {
                    b.Property<int>("WashingMachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WashingMachineId"));

                    b.Property<decimal>("MaxWeight")
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("WashingMachineId");

                    b.ToTable("Wasching_Machine");

                    b.HasData(
                        new
                        {
                            WashingMachineId = 1,
                            MaxWeight = 50.5m,
                            SerialNumber = "12345678"
                        },
                        new
                        {
                            WashingMachineId = 2,
                            MaxWeight = 10.5m,
                            SerialNumber = "987654321"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.AvailableProgram", b =>
                {
                    b.HasOne("WebApplication1.Models.MyProgram", "MyProgram")
                        .WithMany("AvailablePrograms")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.WashingMachine", "WashingMachine")
                        .WithMany("AvailablePrograms")
                        .HasForeignKey("WashingMachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyProgram");

                    b.Navigation("WashingMachine");
                });

            modelBuilder.Entity("WebApplication1.Models.PurchaseHistory", b =>
                {
                    b.HasOne("WebApplication1.Models.AvailableProgram", "AvailableProgram")
                        .WithMany()
                        .HasForeignKey("AvailableProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Customer", "Customer")
                        .WithMany("PurchaseHistory")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AvailableProgram");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("WebApplication1.Models.Customer", b =>
                {
                    b.Navigation("PurchaseHistory");
                });

            modelBuilder.Entity("WebApplication1.Models.MyProgram", b =>
                {
                    b.Navigation("AvailablePrograms");
                });

            modelBuilder.Entity("WebApplication1.Models.WashingMachine", b =>
                {
                    b.Navigation("AvailablePrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
