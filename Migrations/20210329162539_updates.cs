using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "ParkingPlace",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetailsViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleSize = table.Column<int>(type: "int", nullable: false),
                    MemberSpaces = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StayPro = table.Column<bool>(type: "bit", nullable: false),
                    IsPro = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptViewModel", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1991, 3, 29, 18, 25, 38, 704, DateTimeKind.Local).AddTicks(1329), new DateTime(2021, 3, 29, 18, 25, 38, 700, DateTimeKind.Local).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1971, 3, 29, 18, 25, 38, 704, DateTimeKind.Local).AddTicks(4375), new DateTime(2021, 3, 29, 18, 25, 38, 704, DateTimeKind.Local).AddTicks(4341) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1956, 3, 29, 18, 25, 38, 704, DateTimeKind.Local).AddTicks(4414), new DateTime(2021, 3, 29, 18, 25, 38, 704, DateTimeKind.Local).AddTicks(4399) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 4,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1951, 3, 29, 18, 25, 38, 704, DateTimeKind.Local).AddTicks(4448), new DateTime(2017, 3, 29, 18, 25, 38, 704, DateTimeKind.Local).AddTicks(4434) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsViewModel");

            migrationBuilder.DropTable(
                name: "ReceiptViewModel");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "ParkingPlace");

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1991, 3, 28, 23, 24, 47, 836, DateTimeKind.Local).AddTicks(9181), new DateTime(2021, 3, 28, 23, 24, 47, 834, DateTimeKind.Local).AddTicks(4750) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1971, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2220), new DateTime(2021, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2201) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1956, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2234), new DateTime(2021, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2232) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 4,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1951, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2242), new DateTime(2017, 3, 28, 23, 24, 47, 837, DateTimeKind.Local).AddTicks(2239) });
        }
    }
}
