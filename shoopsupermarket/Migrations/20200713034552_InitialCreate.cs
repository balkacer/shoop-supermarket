using Microsoft.EntityFrameworkCore.Migrations;

namespace shoopsupermarket.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    PROV_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NAME = table.Column<string>(maxLength: 50, nullable: false),
                    PHONE1 = table.Column<string>(nullable: false),
                    PHONE2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.PROV_ID);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ARTI_ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DESC = table.Column<string>(maxLength: 50, nullable: false),
                    PRE_VENT = table.Column<double>(nullable: false),
                    STOCK = table.Column<int>(nullable: false),
                    PRE_COMP = table.Column<double>(nullable: false),
                    PROVRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ARTI_ID);
                    table.ForeignKey(
                        name: "FK_Articulos_Proveedores_PROVRefId",
                        column: x => x.PROVRefId,
                        principalTable: "Proveedores",
                        principalColumn: "PROV_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_PROVRefId",
                table: "Articulos",
                column: "PROVRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
