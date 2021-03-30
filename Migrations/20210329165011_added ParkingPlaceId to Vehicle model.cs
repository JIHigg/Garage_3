using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3.Migrations
{
    public partial class addedParkingPlaceIdtoVehiclemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkingPlaceId",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1991, 3, 29, 18, 50, 9, 889, DateTimeKind.Local).AddTicks(2575), new DateTime(2021, 3, 29, 18, 50, 9, 884, DateTimeKind.Local).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1971, 3, 29, 18, 50, 9, 889, DateTimeKind.Local).AddTicks(5713), new DateTime(2021, 3, 29, 18, 50, 9, 889, DateTimeKind.Local).AddTicks(5679) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1956, 3, 29, 18, 50, 9, 889, DateTimeKind.Local).AddTicks(5757), new DateTime(2021, 3, 29, 18, 50, 9, 889, DateTimeKind.Local).AddTicks(5743) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 4,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1951, 3, 29, 18, 50, 9, 889, DateTimeKind.Local).AddTicks(5791), new DateTime(2017, 3, 29, 18, 50, 9, 889, DateTimeKind.Local).AddTicks(5777) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkingPlaceId",
                table: "Vehicle");

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
    }
}
