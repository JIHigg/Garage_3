using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    GarageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfParkingPlaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.GarageId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.VehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    MembershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Personnummer = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Base_Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hourly_Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.MembershipId);
                    table.ForeignKey(
                        name: "FK_Membership_Garage_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garage",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingPlace",
                columns: table => new
                {
                    ParkingPlaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    Column_position = table.Column<int>(type: "int", nullable: false),
                    Row_position = table.Column<int>(type: "int", nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPlace", x => x.ParkingPlaceId);
                    table.ForeignKey(
                        name: "FK_ParkingPlace_Garage_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garage",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfWheels = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Make = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MembershipId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicle_Membership_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Membership",
                        principalColumn: "MembershipId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingPlaceVehicle",
                columns: table => new
                {
                    ParkingPlacesParkingPlaceId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPlaceVehicle", x => new { x.ParkingPlacesParkingPlaceId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_ParkingPlaceVehicle_ParkingPlace_ParkingPlacesParkingPlaceId",
                        column: x => x.ParkingPlacesParkingPlaceId,
                        principalTable: "ParkingPlace",
                        principalColumn: "ParkingPlaceId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ParkingPlaceVehicle_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Garage",
                columns: new[] { "GarageId", "GarageName", "NumberOfParkingPlaces" },
                values: new object[] { 1, "Badass Garage", 20 });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "VehicleTypeId", "Size", "Type_Name" },
                values: new object[] { 1, 2m, "Banana" });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "VehicleTypeId", "Size", "Type_Name" },
                values: new object[] { 2, 1m, "Not-Banana" });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "MembershipId", "Address", "Base_Rate", "Birthdate", "City", "FirstName", "GarageId", "Hourly_Rate", "LastName", "Personnummer", "PostNumber", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "123 Johan St", 1.2m, new DateTime(1991, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(1925), "Stockholm", "Kalle", 1, 2.3m, "Anka", "198706051234", "11111", new DateTime(2021, 3, 25, 15, 56, 52, 405, DateTimeKind.Local).AddTicks(9318) },
                    { 2, "123 Johan St", 1.2m, new DateTime(1971, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4410), "Bag End", "Frodo", 1, 2.3m, "Baggins", "198706051234", "22222", new DateTime(2021, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4394) },
                    { 3, "123 Johan St", 1.2m, new DateTime(1956, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4422), "Hobbiton", "Samwise", 1, 2.3m, "Gamgee", "198706051234", "33333", new DateTime(2021, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4419) },
                    { 4, "123 Johan St", 1.2m, new DateTime(1951, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4429), "Stockholm", "Meriadoc", 1, 2.3m, "Brandybuck", "198706051234", "44444", new DateTime(2017, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4426) }
                });

            migrationBuilder.InsertData(
                table: "ParkingPlace",
                columns: new[] { "ParkingPlaceId", "Column_position", "GarageId", "IsOccupied", "Row_position" },
                values: new object[,]
                {
                    { 18, 3, 1, false, 6 },
                    { 17, 2, 1, false, 6 },
                    { 16, 1, 1, false, 6 },
                    { 15, 5, 1, false, 4 },
                    { 14, 4, 1, false, 4 },
                    { 13, 5, 1, false, 3 },
                    { 12, 4, 1, false, 3 },
                    { 11, 5, 1, false, 1 },
                    { 10, 4, 1, false, 1 },
                    { 8, 2, 1, false, 4 },
                    { 19, 4, 1, false, 6 },
                    { 7, 1, 1, false, 4 },
                    { 6, 3, 1, false, 3 },
                    { 5, 2, 1, false, 3 },
                    { 4, 1, 1, false, 3 },
                    { 3, 3, 1, false, 1 },
                    { 2, 2, 1, false, 1 },
                    { 1, 1, 1, false, 1 },
                    { 9, 3, 1, false, 4 },
                    { 20, 5, 1, false, 6 }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "VehicleId", "Color", "Make", "MembershipId", "Model", "NumberOfWheels", "RegistrationNumber", "VehicleTypeId", "Year" },
                values: new object[,]
                {
                    { 1, "Red", "Banana", 1, "Volvo", 4, "asedf", 1, "1993" },
                    { 2, "Yellow", "Banana", 2, "Volvo", 4, "fdsa", 1, "1996" },
                    { 3, "Blue", "F150", 3, "Ford", 4, "zxcve", 2, "2001" },
                    { 4, "Green", "Fancy Car", 4, "Porsche", 4, "qewrty", 1, "2020" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Membership_GarageId",
                table: "Membership",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPlace_GarageId",
                table: "ParkingPlace",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPlaceVehicle_VehicleId",
                table: "ParkingPlaceVehicle",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_MembershipId",
                table: "Vehicle",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingPlaceVehicle");

            migrationBuilder.DropTable(
                name: "ParkingPlace");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropTable(
                name: "Garage");
        }
    }
}
