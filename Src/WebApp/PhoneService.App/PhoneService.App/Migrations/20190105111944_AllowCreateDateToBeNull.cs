using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService.App.Migrations
{
    public partial class AllowCreateDateToBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Repairs",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2019, 1, 5, 11, 19, 43, 933, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2019, 1, 5, 11, 19, 43, 933, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2019, 1, 5, 11, 19, 43, 933, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2019, 1, 5, 11, 19, 43, 933, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2019, 1, 5, 11, 19, 43, 933, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2019, 1, 5, 11, 19, 43, 933, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2019, 1, 5, 11, 19, 43, 933, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2019, 1, 5, 11, 19, 43, 933, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Repairs",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2019, 1, 3, 20, 59, 17, 453, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2019, 1, 3, 20, 59, 17, 453, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2019, 1, 3, 20, 59, 17, 453, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2019, 1, 3, 20, 59, 17, 453, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2019, 1, 3, 20, 59, 17, 453, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2019, 1, 3, 20, 59, 17, 453, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2019, 1, 3, 20, 59, 17, 453, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2019, 1, 3, 20, 59, 17, 453, DateTimeKind.Utc));
        }
    }
}
