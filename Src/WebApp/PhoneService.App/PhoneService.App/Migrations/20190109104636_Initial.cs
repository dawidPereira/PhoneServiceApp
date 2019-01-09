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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                    ReferenceNumber = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapareParts", x => x.SaparePartId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CreateDate = table.Column<DateTime>(nullable: true),
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
                    { 1, "pereiradawid@example.com", "Pereira", "Dawid", "781 361 182", "91032298349" },
                    { 2, "maksymilainmatula@example.com", "Matuła", "Maksymilian", "685 432 234", "89022338243" },
                    { 3, "miloszwinnicki@example.com", "Winnicki", "Miłosz", "783 234 432", "88113029383" },
                    { 4, "rafalpasek@example.com", "Pasek", "Rafał", "984 343 234", "94022829304" },
                    { 5, "grzegorzwojcik@example.com", "Wójcik", "Grzegorz", "745 543 321", "90010129348" },
                    { 6, "zbigniewwolski@example.com", "Wolski", "Zbigniew", "500 433 333", "70071429378" },
                    { 7, "tomaszbrzyski@example.com", "Brzyski", "Tomasz", "678 432 342", "66052229304" },
                    { 8, "monikazawadzka@example.com", "Zawadzka", "Monika", "787 438 282", "99011039456" },
                    { 9, "zofiawlodarczyk@example.com", "Włodarczyk", "Zofia", "378 392 234", "51031993845" },
                    { 10, "nataliabudzinska@example.com", "Brudzińska", "Natalia", "878 984 774", "87083095743" },
                    { 11, "emanuelmazowiecki@example.com", "Mazowiecki", "Emanuel", "577 573 572", "98070574834" },
                    { 12, "ewelinadobkowska@example.com", "Dobkowska", "Ewelina", "675 584 994", "65091138596" }
                });

            migrationBuilder.InsertData(
                table: "EmailSubjects",
                columns: new[] { "EmailSubjectId", "Subject" },
                values: new object[,]
                {
                    { 6, "Twoje konto zostało zarejestrowane" },
                    { 5, "Zarejestrowaliśmy Twoją naprawę" },
                    { 4, "Twój telefon jest gotowy do odbioru" },
                    { 2, "Twoja naprawa została przekazana do realizacji" },
                    { 1, "Twoja naprawa została wyceniona" },
                    { 3, "Status Twojej naprawy został zmieniony" }
                });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "EmailTemplateId", "TemplateName" },
                values: new object[,]
                {
                    { 1, "StatusChangeTemplate.html" },
                    { 2, "CustomerDecisionTemplate.html" },
                    { 3, "RepairAddTemplate.html" },
                    { 4, "CustomerCreateTemplate.html" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Model", "Producer" },
                values: new object[,]
                {
                    { 7, "Policja? - Proszę przyjechać na facebooka", "X1", "PocoPhone" },
                    { 10, "Co jam ma tu wpisać ?", "SE6", "Sony Ericson" },
                    { 9, "Policja? - Proszę przyjechać na facebooka", "X", "Apple" },
                    { 8, "Policja? - Proszę przyjechać na facebooka", "Desire 10", "HTC" },
                    { 6, "Policja? - Proszę przyjechać na facebooka", "Xperia 10", "Sony" },
                    { 3, "Przepraszam czy to pomyłka", "Mi 8", "Xiaomi" },
                    { 4, "Policja? - Proszę przyjechać na facebooka", "4A", "Redmi" },
                    { 5, "Policja? - Proszę przyjechać na facebooka", "P20", "Huwawei" },
                    { 2, "Mam wrażenie, że trzeba usunąć opis", "3310", "Nokia" },
                    { 1, "Nie wiem po co nam opis produktu", "S8", "Samsung" }
                });

            migrationBuilder.InsertData(
                table: "RepairStatuses",
                columns: new[] { "RepairStatusId", "Name" },
                values: new object[,]
                {
                    { 6, "Odrzucona" },
                    { 5, "Zakończona" },
                    { 4, "Zrealizowana" },
                    { 7, "Zakończona bez naprawy" },
                    { 2, "Wyceniona" },
                    { 1, "Przyjeta" },
                    { 3, "W trakcie realizacji" }
                });

            migrationBuilder.InsertData(
                table: "SapareParts",
                columns: new[] { "SaparePartId", "Name", "Price", "ReferenceNumber" },
                values: new object[,]
                {
                    { 9, "Ładowarka", 49m, "5DS352" },
                    { 1, "Wyświetlacz 5,5 cala", 150m, "253FG32" },
                    { 2, "Wyświetlacz 6,5 cala", 220m, "2352s32" },
                    { 3, "Powłoka ochronna 5,5 cala", 18m, "23XX32" },
                    { 4, "Powłoka ochronna 6,5 cala", 22m, "5DS352" },
                    { 5, "Bateria 2200 mAh", 180m, "5DS352" },
                    { 6, "Bateria 3000 mAh", 275m, "5DS352" },
                    { 7, "Pokrowiec ochronny 5,5 cala", 29m, "5DS352" },
                    { 8, "Pokrowiec ochronny 6,5 cala", 49m, "5DS352" },
                    { 10, "Spersonalizowane Etui", 149m, "5DS352" }
                });

            migrationBuilder.InsertData(
                table: "CustomerAddres",
                columns: new[] { "CustomerAddresId", "Adress", "City", "CustomerId", "PostCode" },
                values: new object[,]
                {
                    { 1, "Maćkówka 155", "Przeworsk", 1, "37-200" },
                    { 12, "Podgórze 9", "Rzeszów", 12, "21-765" },
                    { 11, "Kolorowa 93", "Przemyśl", 11, "43-432" },
                    { 10, "Osiedle Spokojna Dolina 23", "Jarosław", 10, "45-342" },
                    { 8, "Wesoła 11", "Łańcut", 8, "94-675" },
                    { 7, "Tadeusza Kościuszki 558", "Rzeszów", 7, "45 -432" },
                    { 9, "Zarzecze 87", "Tarnów", 9, "65-987" },
                    { 5, "1000-lecia 89", "Żwirki i Muchomorki", 5, "11-222" },
                    { 4, "Zaczernie 23", "Sosnowiec", 4, "30-300" },
                    { 3, "Przy Torze 3", "Rzeszów", 3, "35-356" },
                    { 2, "Zawiła 12", "Dąbrowa Górnicza", 2, "43-204" },
                    { 6, "Powstańców Warszawy 56", "Rzeszów", 6, "25-567" }
                });

            migrationBuilder.InsertData(
                table: "ProductSapareParts",
                columns: new[] { "ProductId", "SaparePartId" },
                values: new object[,]
                {
                    { 3, 8 },
                    { 10, 8 },
                    { 8, 8 },
                    { 6, 8 },
                    { 4, 8 },
                    { 2, 8 },
                    { 8, 6 },
                    { 7, 7 },
                    { 5, 7 },
                    { 1, 7 },
                    { 10, 6 },
                    { 1, 9 },
                    { 6, 6 },
                    { 9, 7 },
                    { 2, 9 },
                    { 8, 9 },
                    { 4, 9 },
                    { 8, 10 },
                    { 7, 10 },
                    { 6, 10 },
                    { 5, 10 },
                    { 4, 10 },
                    { 3, 10 },
                    { 3, 9 },
                    { 2, 10 },
                    { 10, 9 },
                    { 9, 9 },
                    { 4, 6 },
                    { 7, 9 },
                    { 6, 9 },
                    { 5, 9 },
                    { 1, 10 },
                    { 3, 6 },
                    { 10, 4 },
                    { 9, 5 },
                    { 1, 1 },
                    { 5, 1 },
                    { 7, 1 },
                    { 9, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 2, 6 },
                    { 8, 2 },
                    { 10, 2 },
                    { 1, 3 },
                    { 6, 2 },
                    { 7, 3 },
                    { 5, 3 },
                    { 5, 5 },
                    { 1, 5 },
                    { 9, 10 },
                    { 8, 4 },
                    { 7, 5 },
                    { 4, 4 },
                    { 3, 4 },
                    { 2, 4 },
                    { 9, 3 },
                    { 6, 4 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "RepairId", "CreateDate", "CustomerId", "Description", "ProductId", "RepairStatusId" },
                values: new object[,]
                {
                    { 8, new DateTime(2019, 1, 9, 10, 46, 36, 145, DateTimeKind.Utc), 5, "Klient prosi o szybki czas realizacji", 5, 1 },
                    { 7, new DateTime(2019, 1, 9, 10, 46, 36, 145, DateTimeKind.Utc), 5, "Klient serwisował telefon u konkurencji, naprawa nie odniosła pozytynego skutku. Zgłosił sie do nas z prośba o rozwiązanie problemu z niedziałajacą baterią, oraz z prosbą o personalizację etiu.", 2, 1 },
                    { 6, new DateTime(2019, 1, 9, 10, 46, 36, 145, DateTimeKind.Utc), 4, "Telefon został zalany przez klienta. Po zdarzeniu przestał działać wyświetlacz oraz głośnik", 1, 1 },
                    { 5, new DateTime(2019, 1, 9, 10, 46, 36, 145, DateTimeKind.Utc), 3, "Popsuty głośnik", 4, 1 },
                    { 4, new DateTime(2019, 1, 9, 10, 46, 36, 145, DateTimeKind.Utc), 3, "Klientowi nie działa klawiatura", 3, 1 },
                    { 3, new DateTime(2019, 1, 9, 10, 46, 36, 145, DateTimeKind.Utc), 2, "Klient nie może dodzwonić się do nikogo", 2, 1 },
                    { 2, new DateTime(2019, 1, 9, 10, 46, 36, 145, DateTimeKind.Utc), 1, "Po aktualizacji systemu, telefon znacznie spowolnił. Pojawiają się błędy graficzne, a telefon się przegrzewa", 5, 1 },
                    { 1, new DateTime(2019, 1, 9, 10, 46, 36, 145, DateTimeKind.Utc), 1, "Klient zgłasza problem z krótkim czasem pracy telefonu", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerAddres");

            migrationBuilder.DropTable(
                name: "EmailSubjects");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "ProductSapareParts");

            migrationBuilder.DropTable(
                name: "RepairItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
