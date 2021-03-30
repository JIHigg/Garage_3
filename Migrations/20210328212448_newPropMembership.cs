using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3.Migrations
{
    public partial class newPropMembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base_Rate",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "Hourly_Rate",
                table: "Membership");

            migrationBuilder.AddColumn<bool>(
                name: "StayPro",
                table: "Membership",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StayPro",
                table: "Membership");

            migrationBuilder.AddColumn<decimal>(
                name: "Base_Rate",
                table: "Membership",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Hourly_Rate",
                table: "Membership",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Base_Rate", "Birthdate", "Hourly_Rate", "RegistrationDate" },
                values: new object[] { 1.2m, new DateTime(1991, 3, 26, 13, 21, 25, 536, DateTimeKind.Local).AddTicks(3498), 2.3m, new DateTime(2021, 3, 26, 13, 21, 25, 528, DateTimeKind.Local).AddTicks(9030) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Base_Rate", "Birthdate", "Hourly_Rate", "RegistrationDate" },
                values: new object[] { 1.2m, new DateTime(1971, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(2968), 2.3m, new DateTime(2021, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(2915) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Base_Rate", "Birthdate", "Hourly_Rate", "RegistrationDate" },
                values: new object[] { 1.2m, new DateTime(1956, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(3022), 2.3m, new DateTime(2021, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(3007) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 4,
                columns: new[] { "Base_Rate", "Birthdate", "Hourly_Rate", "RegistrationDate" },
                values: new object[] { 1.2m, new DateTime(1951, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(3056), 2.3m, new DateTime(2017, 3, 26, 13, 21, 25, 537, DateTimeKind.Local).AddTicks(3042) });
        }
    }
}
