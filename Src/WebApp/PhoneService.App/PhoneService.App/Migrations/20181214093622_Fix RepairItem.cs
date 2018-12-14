using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService.App.Migrations
{
    public partial class FixRepairItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaparePartItems_Repairs_RepairId",
                table: "SaparePartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaparePartItems",
                table: "SaparePartItems");

            migrationBuilder.DropIndex(
                name: "IX_SaparePartItems_RepairId",
                table: "SaparePartItems");

            migrationBuilder.DropColumn(
                name: "RepairItemId",
                table: "SaparePartItems");

            migrationBuilder.AlterColumn<int>(
                name: "RepairId",
                table: "SaparePartItems",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaparePartItems",
                table: "SaparePartItems",
                columns: new[] { "RepairId", "SaparePartId" });

            migrationBuilder.AddForeignKey(
                name: "FK_SaparePartItems_Repairs_RepairId",
                table: "SaparePartItems",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "RepairId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaparePartItems_Repairs_RepairId",
                table: "SaparePartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaparePartItems",
                table: "SaparePartItems");

            migrationBuilder.AlterColumn<int>(
                name: "RepairId",
                table: "SaparePartItems",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RepairItemId",
                table: "SaparePartItems",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaparePartItems",
                table: "SaparePartItems",
                column: "RepairItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SaparePartItems_RepairId",
                table: "SaparePartItems",
                column: "RepairId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaparePartItems_Repairs_RepairId",
                table: "SaparePartItems",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "RepairId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
