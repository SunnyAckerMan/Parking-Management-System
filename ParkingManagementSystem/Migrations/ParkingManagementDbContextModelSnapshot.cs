﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingManagementSystem.DBContext;

#nullable disable

namespace ParkingManagementSystem.Migrations
{
    [DbContext(typeof(ParkingManagementDbContext))]
    partial class ParkingManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ParkingManagementSystem.Models.Billing", b =>
                {
                    b.Property<long>("BillingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BillingId"), 1L, 1);

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<long>("TicketIdFk")
                        .HasColumnType("bigint");

                    b.HasKey("BillingId");

                    b.ToTable("Billings");
                });

            modelBuilder.Entity("ParkingManagementSystem.Models.ParkingSpot", b =>
                {
                    b.Property<long>("ParkingSpotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ParkingSpotId"), 1L, 1);

                    b.Property<double>("AvailableSpaceInSquareFeet")
                        .HasColumnType("float");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<double>("TotalSpaceInSquareFeet")
                        .HasColumnType("float");

                    b.HasKey("ParkingSpotId");

                    b.ToTable("ParkingSpots");
                });

            modelBuilder.Entity("ParkingManagementSystem.Models.Rate", b =>
                {
                    b.Property<long>("RateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RateId"), 1L, 1);

                    b.Property<long>("ParkingSpotIdFk")
                        .HasColumnType("bigint");

                    b.Property<decimal>("RatePerHour")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("RateId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("ParkingManagementSystem.Models.Ticket", b =>
                {
                    b.Property<long>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TicketId"), 1L, 1);

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExitTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OwnerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerNID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerPhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ParkingSpotIdFk")
                        .HasColumnType("bigint");

                    b.Property<long>("RateIdFk")
                        .HasColumnType("bigint");

                    b.Property<string>("VehicleNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketId");

                    b.ToTable("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
