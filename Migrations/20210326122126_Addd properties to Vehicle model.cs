using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3.Migrations
{
    public partial class AdddpropertiestoVehiclemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInTime",
                table: "Vehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOutTime",
                table: "Vehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsParked",
                table: "Vehicle",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1991, 3, 26, 13, 21, 25, 536, DateTimeKind.Local).AddTicks(3498), new DateTime(2021, 3, 26, 13, 21, 25, 528, DateTimeKind.Local).AddTicks(9030) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1971, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(2968), new DateTime(2021, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(2915) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1956, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(3022), new DateTime(2021, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(3007) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 4,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1951, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(3056), new DateTime(2017, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(3042) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckInTime",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "CheckOutTime",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "IsParked",
                table: "Vehicle");

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1991, 3, 25, 23, 3, 50, 889, DateTimeKind.Local).AddTicks(5283), new DateTime(2021, 3, 25, 23, 3, 50, 883, DateTimeKind.Local).AddTicks(7697) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1971, 3, 25, 23, 3, 50, 891, DateTimeKind.Local).AddTicks(389), new DateTime(2021, 3, 25, 23, 3, 50, 891, DateTimeKind.Local).AddTicks(311) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1956, 3, 25, 23, 3, 50, 891, DateTimeKind.Local).AddTicks(437), new DateTime(2021, 3, 25, 23, 3, 50, 891, DateTimeKind.Local).AddTicks(432) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 4,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1951, 3, 25, 23, 3, 50, 891, DateTimeKind.Local).AddTicks(451), new DateTime(2017, 3, 25, 23, 3, 50, 891, DateTimeKind.Local).AddTicks(446) });
        }
    }
}
