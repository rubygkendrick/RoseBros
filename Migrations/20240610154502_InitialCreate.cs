using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoseBros.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Habits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ColorId = table.Column<int>(type: "integer", nullable: false),
                    HabitId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roses_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roses_Habits_HabitId",
                        column: x => x.HabitId,
                        principalTable: "Habits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsFulfilled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderRoses",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    RoseId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRoses", x => new { x.OrderId, x.RoseId });
                    table.ForeignKey(
                        name: "FK_OrderRoses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRoses_Roses_RoseId",
                        column: x => x.RoseId,
                        principalTable: "Roses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "21f9d35c-e06a-485c-8ee0-308eb452e89c", "admina@strator.comx", false, false, null, null, null, "AQAAAAIAAYagAAAAEOtGunb6q9xi6aOjRZs/wwXWyasoDe2wl+YqiRBtgod5JYfCzkwZ7sltSKMNZrSokw==", null, false, "70233aa7-02f2-4129-a29f-79135acb1a3f", false, "Administrator" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Apricot & Orange" },
                    { 2, "Pink" },
                    { 3, "Red" },
                    { 4, "White & Cream" },
                    { 5, "Yellow" }
                });

            migrationBuilder.InsertData(
                table: "Habits",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Climbing" },
                    { 2, "Shrub" },
                    { 3, "Tree" },
                    { 4, "Rambling" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.InsertData(
                table: "Roses",
                columns: new[] { "Id", "ColorId", "Description", "HabitId", "Image", "Name", "PricePerUnit" },
                values: new object[,]
                {
                    { 1, 2, "Its pretty, semi-double flowers, each about 2” across, are held in sprays on long, slender and flexible stems. They are a pale pink color and of open formation, each exposing a nice boss of golden stamens. They have a fresh citrus fragrance. Named after the ruler of Avalon in the Arthurian legend. She also plays a pivotal role in Sir Walter Scott’s famous poem of the same name.", 4, "https://www.davidaustinroses.com/cdn/shop/products/358bc42b0d8f9ba59b76aad2d2ed90f2_795x.jpg?v=1595523644", "The Lady of The Lake", 35.00m },
                    { 2, 1, "Rich orange-red buds open to chalice-shaped blooms, filled with loosely arranged, orange petals. The surrounding outer petals are salmon-pink with beautifully contrasting golden-yellow undersides. There is a pleasant, warm Tea fragrance, with hints of spiced apple and cloves. It quickly forms a bushy shrub with slightly arching stems and mid-green leaves, which have attractive, slightly bronzed tones when young. The name is taken from one of Alfred, Lord Tennyson’s poems to commemorate the 200th anniversary of his birth.", 2, "https://www.davidaustinroses.com/cdn/shop/products/783d07a90fbff613fc0a0d0506858ccd_795x.jpg?v=1617282312", "Lady Of Shallot", 36.00m },
                    { 3, 5, "A vigorous, upright climber bearing cupped blooms in an unusually rich shade of yellow. There is a light Tea fragrance with hints of violets. It is clothed in attractive, smooth green foliage.", 1, "https://www.davidaustinroses.com/cdn/shop/products/09e82fb705e43e9f3c3d31b9495757ac_ac2531c1-c620-410b-9a07-4b4a6bd66fc7_795x.jpg?v=1595522786", "Graham Thomas", 55.00m },
                    { 4, 4, "Peachy pink buds open to beautiful, white, chalice-shaped blooms, with a pinkish hue. The incurved petals create an arresting interplay of light and shadow. The strong Old Rose fragrance has hints of almond blossom, cucumber and lemon zest. It forms a most attractive neat, rounded, bushy shrub. Named after the tragic heroine of Shakespeare’s Othello.", 2, "https://www.davidaustinroses.com/cdn/shop/products/ffd44b06340221e58080644cd3ad5c87_795x.jpg?v=1616146482", "Desdemona", 35.00m },
                    { 5, 3, "When young, the outer petals of each bloom form a perfect ring around an inner cup, gradually opening out to form a perfect, medium sized rosette. The color is a deep, rich crimson-pink, taking on a tinge of mauve just before the petals drop. There is a light-medium fruity scent. Named after the highly acclaimed ballerina.", 3, "https://www.davidaustinroses.com/cdn/shop/products/4f715479e7dbb2b800beda26869cbbb5_e15646fa-eda9-41ae-bec2-1d6dffcc10e3_795x.jpg?v=1595522050", "Darcy Bussel", 70.00m },
                    { 6, 2, "Red buds open to beautifully formed, upward facing, coral-pink rosettes. Small petals of varying shades mingle to provide a most pleasing effect. The myrrh fragrance has delicious hints of hawthorn, elderflower, pear and almond. It forms an upright shrub. Charles II hid in an oak tree at Boscobel House during the English Civil War.", 2, "https://www.davidaustinroses.com/cdn/shop/products/4dff2acd3891f03d26c87e66efa32606_795x.jpg?v=1595521190", "Boscobel", 50.00m },
                    { 7, 5, "Bears rich yellow flowers, which pale over time. Their formation is most pleasing, having a neat outer ring of petals enclosing an informal group of petals within. There is a strong, wonderfully rich fragrance with a hint of lemon, which becomes sweeter and stronger with age. It forms a bushy, nicely rounded tree with arching branches and rather shiny foliage.", 3, "https://www.davidaustinroses.com/cdn/shop/products/ec42c2f8ba68d786f220a5fdd3738b89_795x.jpg?v=1595524724", "The Poet's Wife", 50.00m },
                    { 8, 3, "A variety of unusual coloring that changes with age to a glowing deep pink-red. The deeply cupped flowers soon open to slightly cupped rosettes. The fragrance is fruity, with aspects of wine and pear drops. It forms a dense, rather upright shrub.", 2, "https://www.davidaustinroses.com/cdn/shop/products/e3ce5bfc923712cc3fa0f4c423e49f1f_9d85aab2-745d-4b96-9448-10ee85a83937_795x.jpg?v=1595521072", "Benjamin Britten", 50.00m },
                    { 9, 4, "Small, single flowers held in very large heads, rather like a hydrangea, produced almost continuously from early summer into Fall. Soft apricot buds open to pure white, with a hint of soft lemon behind the stamens. It is extremely healthy and almost thornless. The growth is bushy and rather upright.", 2, "https://www.davidaustinroses.com/cdn/shop/products/f05472b357e002125394e843afc1e5a5_795x.jpg?v=1616501617", "Benjamin Britten", 35.00m }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IdentityUserId", "LastName" },
                values: new object[] { 1, "101 Main Street", "admina@strator.comx", "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "IsFulfilled", "PurchaseDate", "UserProfileId" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2024, 6, 10, 10, 45, 1, 943, DateTimeKind.Local).AddTicks(3640), 1 },
                    { 2, true, new DateTime(2024, 6, 10, 10, 45, 1, 943, DateTimeKind.Local).AddTicks(3690), 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderRoses",
                columns: new[] { "OrderId", "RoseId", "Quantity" },
                values: new object[,]
                {
                    { 1, 2, 1m },
                    { 1, 3, 2m },
                    { 2, 4, 2m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderRoses_RoseId",
                table: "OrderRoses",
                column: "RoseId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserProfileId",
                table: "Orders",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Roses_ColorId",
                table: "Roses",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Roses_HabitId",
                table: "Roses",
                column: "HabitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
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
                name: "OrderRoses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Roses");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Habits");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
