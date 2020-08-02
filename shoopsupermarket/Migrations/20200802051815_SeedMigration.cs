using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shoopsupermarket.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLI_ID = table.Column<int>(nullable: false),
                    ESTADO = table.Column<string>(nullable: true),
                    NOM_CLI = table.Column<string>(nullable: true),
                    CLIENTE = table.Column<string>(nullable: true),
                    LONG = table.Column<decimal>(nullable: false),
                    LAT = table.Column<decimal>(nullable: false),
                    COMENT = table.Column<string>(nullable: true),
                    FECH_ORD = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArticulosOrdenes",
                columns: table => new
                {
                    ORD_ID = table.Column<int>(nullable: false),
                    ART_ID = table.Column<int>(nullable: false),
                    OrdenID = table.Column<int>(nullable: true),
                    ArticuloID = table.Column<int>(nullable: true),
                    DESC = table.Column<string>(nullable: true),
                    CANT = table.Column<int>(nullable: false),
                    PRE_UNIT = table.Column<double>(nullable: false),
                    IMG = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosOrdenes", x => new { x.ORD_ID, x.ART_ID });
                    table.ForeignKey(
                        name: "FK_ArticulosOrdenes_Articulos_ArticuloID",
                        column: x => x.ArticuloID,
                        principalTable: "Articulos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticulosOrdenes_Ordenes_OrdenID",
                        column: x => x.OrdenID,
                        principalTable: "Ordenes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ID", "CAT_ID", "DESC", "IMG", "PRE_COMP", "PRE_VENT", "PROV_ID", "STOCK" },
                values: new object[] { 2, 1, "Jugo de Manzana", "https://res.cloudinary.com/almacendo/image/upload/v1569273056/Jugos/Jugo-Santal-Sabor-Manzana_-200ml-Caja-_24-uds_-Turn.jpg", 15.0, 15.0, 1, 20 });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "ID", "CAT" },
                values: new object[] { 2, "Comida" });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "ID", "NAME", "PHONE1", "PHONE2" },
                values: new object[] { 2, "Santal", "8297576437", null });

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosOrdenes_ArticuloID",
                table: "ArticulosOrdenes",
                column: "ArticuloID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosOrdenes_OrdenID",
                table: "ArticulosOrdenes",
                column: "OrdenID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticulosOrdenes");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proveedores",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
