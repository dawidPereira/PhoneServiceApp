using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService.App.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmailSubjects",
                columns: new[] { "EmailSubjectId", "Subject" },
                values: new object[,]
                {
                    { 5, "Zarejestrowaliśmy Twoją naprawę" },
                    { 6, "Twoje konto zostało zarejestrowane" }
                });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "EmailTemplateId", "TemplateName" },
                values: new object[,]
                {
                    { 2, "CustomerDecisionTemplate.html" },
                    { 3, "RepairAddTemplate.html" },
                    { 4, "CustomerCreateTemplate.html" }
                });

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 12, 30, 12, 47, 52, 765, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 12, 30, 12, 47, 52, 765, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 12, 30, 12, 47, 52, 765, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 12, 30, 12, 47, 52, 765, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 12, 30, 12, 47, 52, 765, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 12, 30, 12, 47, 52, 765, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 12, 30, 12, 47, 52, 765, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 12, 30, 12, 47, 52, 765, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailSubjects",
                keyColumn: "EmailSubjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmailSubjects",
                keyColumn: "EmailSubjectId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "EmailTemplateId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 12, 29, 11, 11, 52, 500, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 12, 29, 11, 11, 52, 500, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 12, 29, 11, 11, 52, 500, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 12, 29, 11, 11, 52, 500, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 12, 29, 11, 11, 52, 500, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 12, 29, 11, 11, 52, 500, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 12, 29, 11, 11, 52, 500, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 12, 29, 11, 11, 52, 500, DateTimeKind.Utc));
        }
    }
}
