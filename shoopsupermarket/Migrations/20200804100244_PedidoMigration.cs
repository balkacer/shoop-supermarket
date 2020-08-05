using Microsoft.EntityFrameworkCore.Migrations;

namespace shoopsupermarket.Migrations
{
    public partial class PedidoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Estados_EST_ID",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_EST_ID",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EST_ID",
                table: "Articulos");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EstadoId",
                table: "Pedidos",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Estados_EstadoId",
                table: "Pedidos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Estados_EstadoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_EstadoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EST_ID",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_EST_ID",
                table: "Articulos",
                column: "EST_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Estados_EST_ID",
                table: "Articulos",
                column: "EST_ID",
                principalTable: "Estados",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
