﻿// <auto-generated />
using System;
using Garage_3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Garage_3.Migrations
{
    [DbContext(typeof(Garage_3Context))]
    [Migration("20210328212448_newPropMembership")]
    partial class newPropMembership
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Garage_3.Models.Entites.Garage", b =>
                {
                    b.Property<int>("GarageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GarageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfParkingPlaces")
                        .HasColumnType("int");

                    b.HasKey("GarageId");

                    b.ToTable("Garage");

                    b.HasData(
                        new
                        {
                            GarageId = 1,
                            GarageName = "Badass Garage",
                            NumberOfParkingPlaces = 20
                        });
                });

            modelBuilder.Entity("Garage_3.Models.Entites.Membership", b =>
                {
                    b.Property<int>("MembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("GarageId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Personnummer")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("PostNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StayPro")
                        .HasColumnType("bit");

                    b.HasKey("MembershipId");

                    b.HasIndex("GarageId");

                    b.ToTable("Membership");

                    b.HasData(
                        new
                        {
                            MembershipId = 1,
                            Address = "123 Johan St",
                            Birthdate = new DateTime(1991, 3, 28, 23, 24, 47, 836, DateTimeKind.Local).AddTicks(9181),
                            City = "Stockholm",
                            FirstName = "Kalle",
                            GarageId = 1,
                            LastName = "Anka",
                            Personnummer = "198706051234",
                            PostNumber = "11111",
                            RegistrationDate = new DateTime(2021, 3, 28, 23, 24, 47, 834, DateTimeKind.Local).AddTicks(4750),
                            StayPro = false
                        },
                        new
                        {
                            MembershipId = 2,
                            Address = "123 Johan St",
                            Birthdate = new DateTime(1971, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2220),
                            City = "Bag End",
                            FirstName = "Frodo",
                            GarageId = 1,
                            LastName = "Baggins",
                            Personnummer = "198706051234",
                            PostNumber = "22222",
                            RegistrationDate = new DateTime(2021, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2201),
                            StayPro = false
                        },
                        new
                        {
                            MembershipId = 3,
                            Address = "123 Johan St",
                            Birthdate = new DateTime(1956, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2234),
                            City = "Hobbiton",
                            FirstName = "Samwise",
                            GarageId = 1,
                            LastName = "Gamgee",
                            Personnummer = "198706051234",
                            PostNumber = "33333",
                            RegistrationDate = new DateTime(2021, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2232),
                            StayPro = false
                        },
                        new
                        {
                            MembershipId = 4,
                            Address = "123 Johan St",
                            Birthdate = new DateTime(1951, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2242),
                            City = "Stockholm",
                            FirstName = "Meriadoc",
                            GarageId = 1,
                            LastName = "Brandybuck",
                            Personnummer = "198706051234",
                            PostNumber = "44444",
                            RegistrationDate = new DateTime(2017, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2239),
                            StayPro = false
                        });
                });

            modelBuilder.Entity("Garage_3.Models.Entites.ParkingPlace", b =>
                {
                    b.Property<int>("ParkingPlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Column_position")
                        .HasColumnType("int");

                    b.Property<int>("GarageId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("bit");

                    b.Property<int>("Row_position")
                        .HasColumnType("int");

                    b.HasKey("ParkingPlaceId");

                    b.HasIndex("GarageId");

                    b.ToTable("ParkingPlace");

                    b.HasData(
                        new
                        {
                            ParkingPlaceId = 1,
                            Column_position = 1,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 1
                        },
                        new
                        {
                            ParkingPlaceId = 2,
                            Column_position = 2,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 1
                        },
                        new
                        {
                            ParkingPlaceId = 3,
                            Column_position = 3,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 1
                        },
                        new
                        {
                            ParkingPlaceId = 4,
                            Column_position = 1,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 3
                        },
                        new
                        {
                            ParkingPlaceId = 5,
                            Column_position = 2,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 3
                        },
                        new
                        {
                            ParkingPlaceId = 6,
                            Column_position = 3,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 3
                        },
                        new
                        {
                            ParkingPlaceId = 7,
                            Column_position = 1,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 4
                        },
                        new
                        {
                            ParkingPlaceId = 8,
                            Column_position = 2,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 4
                        },
                        new
                        {
                            ParkingPlaceId = 9,
                            Column_position = 3,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 4
                        },
                        new
                        {
                            ParkingPlaceId = 10,
                            Column_position = 4,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 1
                        },
                        new
                        {
                            ParkingPlaceId = 11,
                            Column_position = 5,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 1
                        },
                        new
                        {
                            ParkingPlaceId = 12,
                            Column_position = 4,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 3
                        },
                        new
                        {
                            ParkingPlaceId = 13,
                            Column_position = 5,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 3
                        },
                        new
                        {
                            ParkingPlaceId = 14,
                            Column_position = 4,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 4
                        },
                        new
                        {
                            ParkingPlaceId = 15,
                            Column_position = 5,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 4
                        },
                        new
                        {
                            ParkingPlaceId = 16,
                            Column_position = 1,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 6
                        },
                        new
                        {
                            ParkingPlaceId = 17,
                            Column_position = 2,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 6
                        },
                        new
                        {
                            ParkingPlaceId = 18,
                            Column_position = 3,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 6
                        },
                        new
                        {
                            ParkingPlaceId = 19,
                            Column_position = 4,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 6
                        },
                        new
                        {
                            ParkingPlaceId = 20,
                            Column_position = 5,
                            GarageId = 1,
                            IsOccupied = false,
                            Row_position = 6
                        });
                });

            modelBuilder.Entity("Garage_3.Models.Entites.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckInTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("IsParked")
                        .HasColumnType("bit");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("MembershipId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("NumberOfWheels")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("VehicleId");

                    b.HasIndex("MembershipId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicle");

                    b.HasData(
                        new
                        {
                            VehicleId = 1,
                            CheckInTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOutTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Color = "Red",
                            IsParked = false,
                            Make = "Banana",
                            MembershipId = 1,
                            Model = "Volvo",
                            NumberOfWheels = 4,
                            RegistrationNumber = "asedf",
                            VehicleTypeId = 1,
                            Year = "1993"
                        },
                        new
                        {
                            VehicleId = 2,
                            CheckInTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOutTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Color = "Yellow",
                            IsParked = false,
                            Make = "Banana",
                            MembershipId = 2,
                            Model = "Volvo",
                            NumberOfWheels = 4,
                            RegistrationNumber = "fdsa",
                            VehicleTypeId = 1,
                            Year = "1996"
                        },
                        new
                        {
                            VehicleId = 3,
                            CheckInTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOutTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Color = "Blue",
                            IsParked = false,
                            Make = "F150",
                            MembershipId = 3,
                            Model = "Ford",
                            NumberOfWheels = 4,
                            RegistrationNumber = "zxcve",
                            VehicleTypeId = 2,
                            Year = "2001"
                        },
                        new
                        {
                            VehicleId = 4,
                            CheckInTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CheckOutTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Color = "Green",
                            IsParked = false,
                            Make = "Fancy Car",
                            MembershipId = 4,
                            Model = "Porsche",
                            NumberOfWheels = 4,
                            RegistrationNumber = "qewrty",
                            VehicleTypeId = 1,
                            Year = "2020"
                        });
                });

            modelBuilder.Entity("Garage_3.Models.Entites.VehicleType", b =>
                {
                    b.Property<int>("VehicleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Size")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("VehicleTypeId");

                    b.ToTable("VehicleType");

                    b.HasData(
                        new
                        {
                            VehicleTypeId = 1,
                            Size = 2m,
                            Type_Name = "Banana"
                        },
                        new
                        {
                            VehicleTypeId = 2,
                            Size = 1m,
                            Type_Name = "Not-Banana"
                        });
                });

            modelBuilder.Entity("ParkingPlaceVehicle", b =>
                {
                    b.Property<int>("ParkingPlacesParkingPlaceId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("ParkingPlacesParkingPlaceId", "VehicleId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ParkingPlaceVehicle");
                });

            modelBuilder.Entity("Garage_3.Models.Entites.Membership", b =>
                {
                    b.HasOne("Garage_3.Models.Entites.Garage", "Garage")
                        .WithMany("Memberships")
                        .HasForeignKey("GarageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garage");
                });

            modelBuilder.Entity("Garage_3.Models.Entites.ParkingPlace", b =>
                {
                    b.HasOne("Garage_3.Models.Entites.Garage", "Garage")
                        .WithMany("ParkingPlaces")
                        .HasForeignKey("GarageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garage");
                });

            modelBuilder.Entity("Garage_3.Models.Entites.Vehicle", b =>
                {
                    b.HasOne("Garage_3.Models.Entites.Membership", "Membership")
                        .WithMany("Vehicles")
                        .HasForeignKey("MembershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage_3.Models.Entites.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membership");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("ParkingPlaceVehicle", b =>
                {
                    b.HasOne("Garage_3.Models.Entites.ParkingPlace", null)
                        .WithMany()
                        .HasForeignKey("ParkingPlacesParkingPlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Garage_3.Models.Entites.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Garage_3.Models.Entites.Garage", b =>
                {
                    b.Navigation("Memberships");

                    b.Navigation("ParkingPlaces");
                });

            modelBuilder.Entity("Garage_3.Models.Entites.Membership", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
