using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3.Migrations
{
    public partial class Init : Migration
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
                    StayPro = table.Column<bool>(type: "bit", nullable: false),
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
                    GarageId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true)
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
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsParked = table.Column<bool>(type: "bit", nullable: false),
                    MembershipId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    ParkingPlaceId = table.Column<int>(type: "int", nullable: true)
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
                name: "ParkingPlaceVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    ParkingPlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPlaceVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingPlaceVehicles_ParkingPlace_ParkingPlaceId",
                        column: x => x.ParkingPlaceId,
                        principalTable: "ParkingPlace",
                        principalColumn: "ParkingPlaceId");
                    table.ForeignKey(
                        name: "FK_ParkingPlaceVehicles_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleId");
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
                columns: new[] { "MembershipId", "Address", "Birthdate", "City", "FirstName", "GarageId", "LastName", "Personnummer", "PostNumber", "RegistrationDate", "StayPro" },
                values: new object[,]
                {
                    { 1, "123 Johan St", new DateTime(1991, 3, 30, 11, 46, 56, 706, DateTimeKind.Local).AddTicks(6374), "Stockholm", "Kalle", 1, "Anka", "198706051234", "11111", new DateTime(2021, 3, 30, 11, 46, 56, 702, DateTimeKind.Local).AddTicks(833), false },
                    { 2, "123 Johan St", new DateTime(1971, 3, 30, 11, 46, 56, 706, DateTimeKind.Local).AddTicks(9283), "Bag End", "Frodo", 1, "Baggins", "198706051234", "22222", new DateTime(2021, 3, 30, 11, 46, 56, 706, DateTimeKind.Local).AddTicks(9253), false },
                    { 3, "123 Johan St", new DateTime(1956, 3, 30, 11, 46, 56, 706, DateTimeKind.Local).AddTicks(9327), "Hobbiton", "Samwise", 1, "Gamgee", "198706051234", "33333", new DateTime(2021, 3, 30, 11, 46, 56, 706, DateTimeKind.Local).AddTicks(9312), false },
                    { 4, "123 Johan St", new DateTime(1951, 3, 30, 11, 46, 56, 706, DateTimeKind.Local).AddTicks(9366), "Stockholm", "Meriadoc", 1, "Brandybuck", "198706051234", "44444", new DateTime(2017, 3, 30, 11, 46, 56, 706, DateTimeKind.Local).AddTicks(9351), false }
                });

            migrationBuilder.InsertData(
                table: "ParkingPlace",
                columns: new[] { "ParkingPlaceId", "Column_position", "GarageId", "IsOccupied", "Row_position", "VehicleId" },
                values: new object[,]
                {
                    { 18, 3, 1, false, 6, null },
                    { 17, 2, 1, false, 6, null },
                    { 16, 1, 1, false, 6, null },
                    { 15, 5, 1, false, 4, null },
                    { 14, 4, 1, false, 4, null },
                    { 13, 5, 1, false, 3, null },
                    { 12, 4, 1, false, 3, null },
                    { 11, 5, 1, false, 1, null },
                    { 10, 4, 1, false, 1, null },
                    { 8, 2, 1, false, 4, null },
                    { 19, 4, 1, false, 6, null },
                    { 7, 1, 1, false, 4, null },
                    { 6, 3, 1, false, 3, null },
                    { 5, 2, 1, false, 3, null },
                    { 4, 1, 1, false, 3, null },
                    { 3, 3, 1, false, 1, null },
                    { 2, 2, 1, false, 1, null },
                    { 1, 1, 1, false, 1, null },
                    { 9, 3, 1, false, 4, null },
                    { 20, 5, 1, false, 6, null }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "VehicleId", "CheckInTime", "CheckOutTime", "Color", "IsParked", "Make", "MembershipId", "Model", "NumberOfWheels", "ParkingPlaceId", "RegistrationNumber", "VehicleTypeId", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red", false, "Banana", 1, "Volvo", 4, null, "asedf", 1, "1993" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yellow", false, "Banana", 2, "Volvo", 4, null, "fdsa", 1, "1996" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue", false, "F150", 3, "Ford", 4, null, "zxcve", 2, "2001" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Green", false, "Fancy Car", 4, "Porsche", 4, null, "qewrty", 1, "2020" }
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
                name: "IX_ParkingPlaceVehicles_ParkingPlaceId",
                table: "ParkingPlaceVehicles",
                column: "ParkingPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingPlaceVehicles_VehicleId",
                table: "ParkingPlaceVehicles",
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
                name: "ParkingPlaceVehicles");

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
