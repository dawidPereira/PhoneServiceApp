using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService.App.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaparePartItems_Repairs_RepairId",
                table: "SaparePartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SaparePartItems_SapareParts_SaparePartId",
                table: "SaparePartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaparePartItems",
                table: "SaparePartItems");

            migrationBuilder.RenameTable(
                name: "SaparePartItems",
                newName: "RepairItems");

            migrationBuilder.RenameIndex(
                name: "IX_SaparePartItems_SaparePartId",
                table: "RepairItems",
                newName: "IX_RepairItems_SaparePartId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Repairs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepairItems",
                table: "RepairItems",
                columns: new[] { "RepairId", "SaparePartId" });

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
                    { 5, new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc), 3, "Popsuty głośnik", 4, 5 },
                    { 4, new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc), 3, "Klientowi nie działa klawiatura", 3, 4 },
                    { 3, new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc), 2, "Klient nie może dodzwonić się do nikogo - nie opłacił abonamentu", 2, 3 },
                    { 7, new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc), 5, "Coś nie diała", 2, 2 },
                    { 2, new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc), 1, "Opis z produktu dodamu tutaj", 5, 2 },
                    { 1, new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc), 1, "Tutaj powinien być jakiś opis naprawy", 1, 1 },
                    { 8, new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc), 5, "Pan nie był zadowolony", 5, 6 },
                    { 6, new DateTime(2018, 12, 15, 17, 58, 38, 682, DateTimeKind.Utc), 4, "Klient przyniusł zalany telefon w skarpecie z ryżem", 1, 6 }
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

            migrationBuilder.AddForeignKey(
                name: "FK_RepairItems_Repairs_RepairId",
                table: "RepairItems",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "RepairId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairItems_SapareParts_SaparePartId",
                table: "RepairItems",
                column: "SaparePartId",
                principalTable: "SapareParts",
                principalColumn: "SaparePartId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairItems_Repairs_RepairId",
                table: "RepairItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairItems_SapareParts_SaparePartId",
                table: "RepairItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepairItems",
                table: "RepairItems");

            migrationBuilder.DeleteData(
                table: "CustomerAddres",
                keyColumn: "CustomerAddresId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerAddres",
                keyColumn: "CustomerAddresId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomerAddres",
                keyColumn: "CustomerAddresId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CustomerAddres",
                keyColumn: "CustomerAddresId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CustomerAddres",
                keyColumn: "CustomerAddresId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductSapareParts",
                keyColumns: new[] { "ProductId", "SaparePartId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSapareParts",
                keyColumns: new[] { "ProductId", "SaparePartId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSapareParts",
                keyColumns: new[] { "ProductId", "SaparePartId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSapareParts",
                keyColumns: new[] { "ProductId", "SaparePartId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductSapareParts",
                keyColumns: new[] { "ProductId", "SaparePartId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSapareParts",
                keyColumns: new[] { "ProductId", "SaparePartId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSapareParts",
                keyColumns: new[] { "ProductId", "SaparePartId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSapareParts",
                keyColumns: new[] { "ProductId", "SaparePartId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSapareParts",
                keyColumns: new[] { "ProductId", "SaparePartId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSapareParts",
                keyColumns: new[] { "ProductId", "SaparePartId" },
                keyValues: new object[] { 5, 4 });

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

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RepairStatuses",
                keyColumn: "RepairStatusId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "RepairId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SapareParts",
                keyColumn: "SaparePartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SapareParts",
                keyColumn: "SaparePartId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SapareParts",
                keyColumn: "SaparePartId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SapareParts",
                keyColumn: "SaparePartId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SapareParts",
                keyColumn: "SaparePartId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RepairStatuses",
                keyColumn: "RepairStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RepairStatuses",
                keyColumn: "RepairStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RepairStatuses",
                keyColumn: "RepairStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RepairStatuses",
                keyColumn: "RepairStatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RepairStatuses",
                keyColumn: "RepairStatusId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Repairs");

            migrationBuilder.RenameTable(
                name: "RepairItems",
                newName: "SaparePartItems");

            migrationBuilder.RenameIndex(
                name: "IX_RepairItems_SaparePartId",
                table: "SaparePartItems",
                newName: "IX_SaparePartItems_SaparePartId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SaparePartItems_SapareParts_SaparePartId",
                table: "SaparePartItems",
                column: "SaparePartId",
                principalTable: "SapareParts",
                principalColumn: "SaparePartId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
