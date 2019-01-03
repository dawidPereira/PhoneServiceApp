using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService.App.Migrations
{
    public partial class EmailSender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RepairItems",
                keyColumns: new[] { "RepairId", "SaparePartId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RepairItems",
                keyColumns: new[] { "RepairId", "SaparePartId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RepairItems",
                keyColumns: new[] { "RepairId", "SaparePartId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RepairItems",
                keyColumns: new[] { "RepairId", "SaparePartId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RepairItems",
                keyColumns: new[] { "RepairId", "SaparePartId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "RepairItems",
                keyColumns: new[] { "RepairId", "SaparePartId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "RepairItems",
                keyColumns: new[] { "RepairId", "SaparePartId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "RepairItems",
                keyColumns: new[] { "RepairId", "SaparePartId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "RepairItems",
                keyColumns: new[] { "RepairId", "SaparePartId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "RepairItems",
                keyColumns: new[] { "RepairId", "SaparePartId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "RepairItems",
                keyColumns: new[] { "RepairId", "SaparePartId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.CreateTable(
                name: "EmailSubjects",
                columns: table => new
                {
                    EmailSubjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSubjects", x => x.EmailSubjectId);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    EmailTemplateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TemplateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.EmailTemplateId);
                });

            migrationBuilder.InsertData(
                table: "EmailSubjects",
                columns: new[] { "EmailSubjectId", "Subject" },
                values: new object[,]
                {
                    { 1, "Twoja naprawa została wyceniona" },
                    { 2, "Twoja naprawa została przekazana do realizacji" },
                    { 3, "Status Twojej naprawy został zmieniony" },
                    { 4, "Twój telefon jest gotowy do odbioru" }
                });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "EmailTemplateId", "TemplateName" },
                values: new object[] { 1, "StatusChangeTemplate.html" });

            migrationBuilder.UpdateData(
                table: "RepairStatuses",
                keyColumn: "RepairStatusId",
                keyValue: 5,
                column: "Name",
                value: "Zakończona");

            migrationBuilder.UpdateData(
                table: "RepairStatuses",
                keyColumn: "RepairStatusId",
                keyValue: 6,
                column: "Name",
                value: "Odrzucona");

            migrationBuilder.InsertData(
                table: "RepairStatuses",
                columns: new[] { "RepairStatusId", "Name" },
                values: new object[] { 7, "Zakończona bez naprawy" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailSubjects");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DeleteData(
                table: "RepairStatuses",
                keyColumn: "RepairStatusId",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "RepairItems",
                columns: new[] { "RepairId", "SaparePartId", "Quantity" },
                values: new object[,]
                {
                    { 2, 3, 1 },
                    { 2, 1, 1 },
                    { 5, 5, 10 },
                    { 4, 4, 1 },
                    { 3, 3, 3 },
                    { 2, 2, 2 },
                    { 5, 1, 1 },
                    { 4, 5, 1 },
                    { 1, 1, 1 },
                    { 1, 2, 2 },
                    { 3, 4, 2 }
                });

            migrationBuilder.UpdateData(
                table: "RepairStatuses",
                keyColumn: "RepairStatusId",
                keyValue: 5,
                column: "Name",
                value: "Odrzucona");

            migrationBuilder.UpdateData(
                table: "RepairStatuses",
                keyColumn: "RepairStatusId",
                keyValue: 6,
                column: "Name",
                value: "Będziesz Pan zadowolony");

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 21, 29, 8, 837, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 21, 29, 8, 837, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 21, 29, 8, 837, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 21, 29, 8, 837, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 21, 29, 8, 837, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 6,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 21, 29, 8, 837, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 7,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 21, 29, 8, 837, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 8,
                column: "CreateDate",
                value: new DateTime(2018, 12, 16, 21, 29, 8, 837, DateTimeKind.Utc));
        }
    }
}
