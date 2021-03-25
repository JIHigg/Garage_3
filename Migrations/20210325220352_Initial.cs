using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_3.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 1,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1991, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(1925), new DateTime(2021, 3, 25, 15, 56, 52, 405, DateTimeKind.Local).AddTicks(9318) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 2,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1971, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4410), new DateTime(2021, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4394) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 3,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1956, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4422), new DateTime(2021, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4419) });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "MembershipId",
                keyValue: 4,
                columns: new[] { "Birthdate", "RegistrationDate" },
                values: new object[] { new DateTime(1951, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4429), new DateTime(2017, 3, 25, 15, 56, 52, 408, DateTimeKind.Local).AddTicks(4426) });
        }
    }
}
