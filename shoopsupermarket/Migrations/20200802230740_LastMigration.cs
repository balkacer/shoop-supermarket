using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shoopsupermarket.Migrations
{
    public partial class LastMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
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
                    Id = table.Column<string>(nullable: false),
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
                name: "Categorias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CAT = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ESTADO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(maxLength: 50, nullable: false),
                    PHONE1 = table.Column<string>(maxLength: 10, nullable: false),
                    PHONE2 = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SliderConfiguracion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONT = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderConfiguracion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "Pedidos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLI_ID = table.Column<string>(nullable: true),
                    USER = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true),
                    ADDR = table.Column<string>(nullable: true),
                    LONG = table.Column<float>(nullable: false),
                    LAT = table.Column<float>(nullable: false),
                    COMENT = table.Column<string>(nullable: true),
                    EST_ID = table.Column<int>(nullable: false),
                    ESTADOID = table.Column<int>(nullable: true),
                    TOTAL = table.Column<double>(nullable: false),
                    FECH_ORD = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pedidos_Estados_ESTADOID",
                        column: x => x.ESTADOID,
                        principalTable: "Estados",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESC = table.Column<string>(maxLength: 50, nullable: false),
                    PRE_VENT = table.Column<double>(nullable: false),
                    STOCK = table.Column<int>(nullable: false),
                    PRE_COMP = table.Column<double>(nullable: false),
                    PROV_ID = table.Column<int>(nullable: false),
                    CAT_ID = table.Column<int>(nullable: false),
                    IMG = table.Column<string>(nullable: false),
                    EST_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Articulos_Categorias_CAT_ID",
                        column: x => x.CAT_ID,
                        principalTable: "Categorias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Estados_EST_ID",
                        column: x => x.EST_ID,
                        principalTable: "Estados",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_Proveedores_PROV_ID",
                        column: x => x.PROV_ID,
                        principalTable: "Proveedores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    ORD_ID = table.Column<int>(nullable: false),
                    ART_ID = table.Column<int>(nullable: false),
                    DESC = table.Column<string>(nullable: true),
                    CANT = table.Column<int>(nullable: false),
                    PRE_UNIT = table.Column<double>(nullable: false),
                    IMG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => new { x.ORD_ID, x.ART_ID });
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Articulos_ART_ID",
                        column: x => x.ART_ID,
                        principalTable: "Articulos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedidos_Pedidos_ORD_ID",
                        column: x => x.ORD_ID,
                        principalTable: "Pedidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            // CATEGORIAS
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CAT" },
                values: new object[] { "Comida" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CAT" },
                values: new object[] { "Bebida" });

            // PROVEEDORES
            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] {"NAME", "PHONE1", "PHONE2" },
                values: new object[] { "Santal", "8297576437", null });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "NAME", "PHONE1", "PHONE2" },
                values: new object[] { "Rica", "8097576438", null });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "NAME", "PHONE1", "PHONE2" },
                values: new object[] { "Induveca", "8497576439", null });

            // SliderConfiguracion
            migrationBuilder.InsertData(
                table: "SliderConfiguracion",
                columns: new[] { "CONT" },
                values: new object[] { "https://s1.eestatic.com/2019/04/11/actualidad/Actualidad_390223215_120196577_1706x960.jpg" });

            migrationBuilder.InsertData(
                table: "SliderConfiguracion",
                columns: new[] { "CONT" },
                values: new object[] { "https://www.eluniversal.com.mx/sites/default/files/2020/03/26/jugos_multivitaminicos.jpg" });

            // ARTICULOS
            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "CAT_ID", "DESC", "IMG", "PRE_COMP", "PRE_VENT", "PROV_ID", "STOCK" },
                values: new object[] { 2, "Jugo de Manzana", "https://res.cloudinary.com/almacendo/image/upload/v1569273056/Jugos/Jugo-Santal-Sabor-Manzana_-200ml-Caja-_24-uds_-Turn.jpg", 15.0, 20.0, 1, 20 });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "CAT_ID", "DESC", "IMG", "PRE_COMP", "PRE_VENT", "PROV_ID", "STOCK" },
                values: new object[] { 2, "Jugo de Naranja", "https://cdn.shopify.com/s/files/1/0123/4455/7664/products/JUGO_RICA_NARANJA_200_ML_codigo_7460111102568_da10438b-5c9e-4ad2-8f18-eff78065074b.jpg?v=1585719021", 15.49, 25.0, 2, 50 });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "CAT_ID", "DESC", "IMG", "PRE_COMP", "PRE_VENT", "PROV_ID", "STOCK" },
                values: new object[] { 1, "Salami", "https://cdn.shopify.com/s/files/1/0123/4455/7664/products/edit_5307156f-30bf-4116-8b06-202545f24df2.jpg?v=1593010340", 50.40, 70.0, 3, 100 });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CAT_ID",
                table: "Articulos",
                column: "CAT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_EST_ID",
                table: "Articulos",
                column: "EST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_PROV_ID",
                table: "Articulos",
                column: "PROV_ID");

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
                name: "IX_DetallePedidos_ART_ID",
                table: "DetallePedidos",
                column: "ART_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ESTADOID",
                table: "Pedidos",
                column: "ESTADOID");
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
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "SliderConfiguracion");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
