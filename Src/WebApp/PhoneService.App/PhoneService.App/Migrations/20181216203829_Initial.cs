using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService.App.Migrations
{
    public partial class Initial : Migration
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
                    CreateDate = table.Column<DateTime>(nullable: false),
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
                name: "RepairItems",
                columns: table => new
                {
                    Quantity = table.Column<int>(nullable: false),
                    SaparePartId = table.Column<int>(nullable: false),
                    RepairId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairItems", x => new { x.RepairId, x.SaparePartId });
                    table.ForeignKey(
                        name: "FK_RepairItems_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "RepairId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairItems_SapareParts_SaparePartId",
                        column: x => x.SaparePartId,
                        principalTable: "SapareParts",
                        principalColumn: "SaparePartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "LastName", "Name", "PhoneNum", "TaxNum" },
                values: new object[,]
                {
                    { 1, "pereiradawid@example.com", "Pereira", "Dawid", "123456789", "987654321" },
                    { 2, "maksymilainmatula@example.com", "Matuła", "Maksymilian", "123456789", "987654321" },
                    { 3, "miloszwinnicki@example.com", "Winnicki", "Miłosz", "123456789", "987654321" },
                    { 4, "rafalpasek@example.com", "Pasek", "Rafał", "123456789", "987654321" },
                    { 5, "grzegorzwojcik@example.com", "Wójcik", "Grzegorz", "123456789", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Model", "Producer" },
                values: new object[,]
                {
                    { 1, "Nie wiem po co nam opis produktu", "S8", "Samsung" },
                    { 2, "Mam wrażenie, że trzeba usunąć opis", "3310", "Nokia" },
                    { 3, "Przepraszam czy to pomyłka", "Lepszy", "Xiaomi" },
                    { 4, "Policja? - Proszę przyjechać na facebooka", "XXX", "Apple" },
                    { 5, "Co jam ma tu wpisać ?", "Ericson Sony", "Sony Ericson" }
                });

            migrationBuilder.InsertData(
                table: "RepairStatuses",
                columns: new[] { "RepairStatusId", "Name" },
                values: new object[,]
                {
                    { 6, "Będziesz Pan zadowolony" },
                    { 5, "Odrzucona" },
                    { 4, "Zrealizowana" },
                    { 1, "Przyjeta" },
                    { 2, "Wyceniona" },
                    { 3, "W trakcie realizacji" }
                });

            migrationBuilder.InsertData(
                table: "SapareParts",
                columns: new[] { "SaparePartId", "Name", "Price", "ReferenceNumebr" },
                values: new object[,]
                {
                    { 4, "O co to za śróbka", 10m, null },
                    { 1, "Dioda W34", 10m, null },
                    { 2, "Tranzystor BX11", 10m, null },
                    { 3, "Wyświetlacz uniwersalny", 10m, null },
                    { 5, "Klawiatura 3310", 10m, null }
                });

            migrationBuilder.InsertData(
                table: "CustomerAddres",
                columns: new[] { "CustomerAddresId", "Adress", "City", "CustomerId", "PostCode" },
                values: new object[,]
                {
                    { 1, null, "Przeworsk", 1, "37-200" },
                    { 2, null, "Dąbrowa Górnicza", 2, "43-204" },
                    { 3, null, "Rzeszów", 3, "35-356" },
                    { 4, null, "Sosnowiec", 4, "30-300" },
                    { 5, null, "Żwirki i Muchomorki", 5, "11-222" }
                });

            migrationBuilder.InsertData(
                table: "ProductSapareParts",
                columns: new[] { "ProductId", "SaparePartId" },
                values: new object[,]
                {
                    { 3, 4 },
                    { 5, 3 },
                    { 3, 3 },
                    { 1, 3 },
                    { 4, 2 },
                    { 2, 2 },
                    { 4, 1 },
                    { 1, 1 },
                    { 2, 5 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "RepairId", "CreateDate", "CustomerId", "Description", "ProductId", "RepairStatusId" },
                values: new object[,]
                {
                    { 5, new DateTime(2018, 12, 16, 20, 38, 29, 111, DateTimeKind.Utc), 3, "Popsuty głośnik", 4, 5 },
                    { 4, new DateTime(2018, 12, 16, 20, 38, 29, 111, DateTimeKind.Utc), 3, "Klientowi nie działa klawiatura", 3, 4 },
                    { 3, new DateTime(2018, 12, 16, 20, 38, 29, 111, DateTimeKind.Utc), 2, "Klient nie może dodzwonić się do nikogo - nie opłacił abonamentu", 2, 3 },
                    { 7, new DateTime(2018, 12, 16, 20, 38, 29, 111, DateTimeKind.Utc), 5, "Coś nie diała", 2, 2 },
                    { 2, new DateTime(2018, 12, 16, 20, 38, 29, 111, DateTimeKind.Utc), 1, "Opis z produktu dodamu tutaj", 5, 2 },
                    { 1, new DateTime(2018, 12, 16, 20, 38, 29, 111, DateTimeKind.Utc), 1, "Tutaj powinien być jakiś opis naprawy", 1, 1 },
                    { 8, new DateTime(2018, 12, 16, 20, 38, 29, 111, DateTimeKind.Utc), 5, "Pan nie był zadowolony", 5, 6 },
                    { 6, new DateTime(2018, 12, 16, 20, 38, 29, 111, DateTimeKind.Utc), 4, "Klient przyniusł zalany telefon w skarpecie z ryżem", 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "RepairItems",
                columns: new[] { "RepairId", "SaparePartId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 2 },
                    { 2, 3, 1 },
                    { 2, 2, 2 },
                    { 2, 1, 1 },
                    { 3, 4, 2 },
                    { 3, 3, 3 },
                    { 4, 5, 1 },
                    { 4, 4, 1 },
                    { 5, 1, 1 },
                    { 5, 5, 10 }
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
                name: "IX_RepairItems_SaparePartId",
                table: "RepairItems",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddres");

            migrationBuilder.DropTable(
                name: "ProductSapareParts");

            migrationBuilder.DropTable(
                name: "RepairItems");

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
