using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService.Persistance.Migrations
{
    public partial class InitialCreate : Migration
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
                    CustomerAddresId = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddres", x => x.CustomerAddresId);
                    table.ForeignKey(
                        name: "FK_CustomerAddres_Customers_CustomerAddresId",
                        column: x => x.CustomerAddresId,
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
                    RepairStatusId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.RepairId);
                    table.ForeignKey(
                        name: "FK_Repairs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repairs_RepairStatuses_RepairStatusId",
                        column: x => x.RepairStatusId,
                        principalTable: "RepairStatuses",
                        principalColumn: "RepairStatusId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "CustomerRepair",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false),
                    RepairId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRepair", x => new { x.RepairId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_CustomerRepair_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerRepair_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "RepairId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairProduct",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    RepairId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairProduct", x => new { x.RepairId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_RepairProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairProduct_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "RepairId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaparePartItems",
                columns: table => new
                {
                    SaparePartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    RepairId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaparePartItems", x => x.SaparePartItemId);
                    table.ForeignKey(
                        name: "FK_SaparePartItems_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "RepairId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaparePartSaparePartItem",
                columns: table => new
                {
                    SaparePartItemId = table.Column<int>(nullable: false),
                    SaparePartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaparePartSaparePartItem", x => new { x.SaparePartId, x.SaparePartItemId });
                    table.ForeignKey(
                        name: "FK_SaparePartSaparePartItem_SapareParts_SaparePartId",
                        column: x => x.SaparePartId,
                        principalTable: "SapareParts",
                        principalColumn: "SaparePartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaparePartSaparePartItem_SaparePartItems_SaparePartItemId",
                        column: x => x.SaparePartItemId,
                        principalTable: "SaparePartItems",
                        principalColumn: "SaparePartItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRepair_CustomerId",
                table: "CustomerRepair",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSapareParts_SaparePartId",
                table: "ProductSapareParts",
                column: "SaparePartId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairProduct_ProductId",
                table: "RepairProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_CustomerId",
                table: "Repairs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_RepairStatusId",
                table: "Repairs",
                column: "RepairStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SaparePartItems_RepairId",
                table: "SaparePartItems",
                column: "RepairId");

            migrationBuilder.CreateIndex(
                name: "IX_SaparePartSaparePartItem_SaparePartItemId",
                table: "SaparePartSaparePartItem",
                column: "SaparePartItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddres");

            migrationBuilder.DropTable(
                name: "CustomerRepair");

            migrationBuilder.DropTable(
                name: "ProductSapareParts");

            migrationBuilder.DropTable(
                name: "RepairProduct");

            migrationBuilder.DropTable(
                name: "SaparePartSaparePartItem");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SapareParts");

            migrationBuilder.DropTable(
                name: "SaparePartItems");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RepairStatuses");
        }
    }
}
