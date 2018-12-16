using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService.App.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 13, 18, 55, 99, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 13, 18, 55, 99, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 13, 18, 55, 99, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 13, 18, 55, 99, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 13, 18, 55, 99, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 13, 18, 55, 99, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 13, 18, 55, 99, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 13, 18, 55, 99, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc));
        }
    }
}
