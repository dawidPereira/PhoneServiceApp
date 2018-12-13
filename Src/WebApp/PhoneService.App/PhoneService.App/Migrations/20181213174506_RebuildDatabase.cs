using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService.App.Migrations
{
    public partial class RebuildDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNum = table.Column<string>(nullable: true),
                    TaxNum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Producer = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "RepairStatuses",
                columns: table => new
                {
                    RepairStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairStatuses", x => x.RepairStatusId);
                });

            migrationBuilder.CreateTable(
                name: "SapareParts",
                columns: table => new
                {
                    SaparePartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ReferenceNumebr = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapareParts", x => x.SaparePartId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddres",
                columns: table => new
                {
                    CustomerAddresId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddres", x => x.CustomerAddresId);
                    table.ForeignKey(
                        name: "FK_CustomerAddres_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    RepairId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    RepairStatusId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.RepairId);
                    table.ForeignKey(
                        name: "FK_Repairs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_RepairStatuses_RepairStatusId",
                        column: x => x.RepairStatusId,
                        principalTable: "RepairStatuses",
                        principalColumn: "RepairStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSapareParts",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    SaparePartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSapareParts", x => new { x.ProductId, x.SaparePartId });
                    table.ForeignKey(
                        name: "FK_ProductSapareParts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSapareParts_SapareParts_SaparePartId",
                        column: x => x.SaparePartId,
                        principalTable: "SapareParts",
                        principalColumn: "SaparePartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaparePartItems",
                columns: table => new
                {
                    RepairItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    SaparePartId = table.Column<int>(nullable: false),
                    RepairId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaparePartItems", x => x.RepairItemId);
                    table.ForeignKey(
                        name: "FK_SaparePartItems_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "RepairId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaparePartItems_SapareParts_SaparePartId",
                        column: x => x.SaparePartId,
                        principalTable: "SapareParts",
                        principalColumn: "SaparePartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddres_CustomerId",
                table: "CustomerAddres",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSapareParts_SaparePartId",
                table: "ProductSapareParts",
                column: "SaparePartId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_CustomerId",
                table: "Repairs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ProductId",
                table: "Repairs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_RepairStatusId",
                table: "Repairs",
                column: "RepairStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SaparePartItems_RepairId",
                table: "SaparePartItems",
                column: "RepairId");

            migrationBuilder.CreateIndex(
                name: "IX_SaparePartItems_SaparePartId",
                table: "SaparePartItems",
                column: "SaparePartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddres");

            migrationBuilder.DropTable(
                name: "ProductSapareParts");

            migrationBuilder.DropTable(
                name: "SaparePartItems");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "SapareParts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RepairStatuses");
        }
    }
}
