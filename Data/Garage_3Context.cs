using Garage_3.Models.Entites;
using Microsoft.EntityFrameworkCore;
using System;

namespace Garage_3.Data
{
    public class Garage_3Context : DbContext
    {
        internal int Personnummer;

        public Garage_3Context (DbContextOptions<Garage_3Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Garage>().HasData(
                new Garage
                {
                    GarageId = 1,
                    GarageName = "Badass Garage",
                    NumberOfParkingPlaces = 20
                });

            modelBuilder.Entity<Membership>().HasData(
                new Membership
                {
                    MembershipId = 1,
                    Personnummer = "198706051234",
                    FirstName = "Kalle",
                    LastName = "Anka",
                    RegistrationDate = DateTime.Now,
                    Birthdate = (DateTime.Now.AddYears(-30)),
                    Address = "123 Johan St",
                    PostNumber = "11111",
                    City = "Stockholm",
                    Base_Rate = 1.2M,
                    Hourly_Rate = 2.3M,
                    GarageId = 1
                },
                new Membership
                {
                    MembershipId = 2,
                    Personnummer = "198706051234",
                    FirstName = "Frodo",
                    LastName = "Baggins",
                    RegistrationDate = DateTime.Now,
                    Birthdate = (DateTime.Now.AddYears(-50)),
                    Address = "123 Johan St",
                    PostNumber = "22222",
                    City = "Bag End",
                    Base_Rate = 1.2M,
                    Hourly_Rate = 2.3M,
                    GarageId = 1
                },
                new Membership
                {
                    MembershipId = 3,
                    Personnummer = "198706051234",
                    FirstName = "Samwise",
                    LastName = "Gamgee",
                    RegistrationDate = DateTime.Now,
                    Birthdate = (DateTime.Now.AddYears(-65)),
                    Address = "123 Johan St",
                    PostNumber = "33333",
                    City = "Hobbiton",
                    Base_Rate = 1.2M,
                    Hourly_Rate = 2.3M,
                    GarageId = 1
                },
                new Membership
                {
                    MembershipId = 4,
                    Personnummer = "198706051234",
                    FirstName = "Meriadoc",
                    LastName = "Brandybuck",
                    RegistrationDate = (DateTime.Now.AddYears(-4)),
                    Birthdate = (DateTime.Now.AddYears(-70)),
                    Address = "123 Johan St",
                    PostNumber = "44444",
                    City = "Stockholm",
                    Base_Rate = 1.2M,
                    Hourly_Rate = 2.3M,
                    GarageId = 1
                });

            modelBuilder.Entity<ParkingPlace>().HasData(
                new ParkingPlace
                {
                    ParkingPlaceId = 1,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 1,
                    Row_position = 1,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 2,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 2,
                    Row_position = 1,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 3,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 3,
                    Row_position = 1,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 4,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 1,
                    Row_position = 3,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 5,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 2,
                    Row_position = 3,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 6,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 3,
                    Row_position = 3,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 7,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 1,
                    Row_position = 4,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 8,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 2,
                    Row_position = 4,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 9,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 3,
                    Row_position = 4,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 10,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 4,
                    Row_position = 1,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 11,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 5,
                    Row_position = 1,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 12,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 4,
                    Row_position = 3,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 13,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 5,
                    Row_position = 3,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 14,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 4,
                    Row_position = 4,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 15,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 5,
                    Row_position = 4,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 16,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 1,
                    Row_position = 6,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 17,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 2,
                    Row_position = 6,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 18,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 3,
                    Row_position = 6,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 19,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 4,
                    Row_position = 6,
                },
                new ParkingPlace
                {
                    ParkingPlaceId = 20,
                    GarageId = 1,
                    IsOccupied = false,
                    Column_position = 5,
                    Row_position = 6,
                });

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    VehicleId = 1,
                    RegistrationNumber = "asedf",
                    NumberOfWheels = 4,
                    Year = "1993",
                    Model = "Volvo",
                    Make = "Banana",
                    Color = "Red",
                    MembershipId = 1,
                    VehicleTypeId = 1


                },
                new Vehicle
                {
                    VehicleId = 2,
                    RegistrationNumber = "fdsa",
                    NumberOfWheels = 4,
                    Year = "1996",
                    Model = "Volvo",
                    Make = "Banana",
                    Color = "Yellow",
                    MembershipId = 2,
                    VehicleTypeId = 1


                },
                new Vehicle
                {
                    VehicleId = 3,
                    RegistrationNumber = "zxcve",
                    NumberOfWheels = 4,
                    Year = "2001",
                    Model = "Ford",
                    Make = "F150",
                    Color = "Blue",
                    MembershipId = 3,
                    VehicleTypeId = 2


                },
                new Vehicle
                {
                    VehicleId = 4,
                    RegistrationNumber = "qewrty",
                    NumberOfWheels = 4,
                    Year = "2020",
                    Model = "Porsche",
                    Make = "Fancy Car",
                    Color = "Green",
                    MembershipId = 4,
                    VehicleTypeId = 1

                });

            modelBuilder.Entity<VehicleType>().HasData(
                new VehicleType
                {
                    VehicleTypeId = 1,
                    Size = 2,
                    Type_Name = "Banana",

                },
                new VehicleType
                {
                    VehicleTypeId = 2,
                    Size = 1,
                    Type_Name = "Not-Banana"
                }
                   );
        }

        public DbSet<Garage> Garage { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<ParkingPlace> ParkingPlace { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }

    }
}
