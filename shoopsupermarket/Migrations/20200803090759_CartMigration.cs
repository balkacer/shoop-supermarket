using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shoopsupermarket.Migrations
{
    public partial class CartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Articulos_ART_ID",
                table: "DetallePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Pedidos_ORD_ID",
                table: "DetallePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Estados_ESTADOID",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ESTADOID",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedidos_ART_ID",
                table: "DetallePedidos");

            migrationBuilder.DropColumn(
                name: "ADDR",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "CLI_ID",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "COMENT",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ESTADOID",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EST_ID",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "FECH_ORD",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "LAT",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "LONG",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "USER",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DESC",
                table: "DetallePedidos");

            migrationBuilder.DropColumn(
                name: "IMG",
                table: "DetallePedidos");

            migrationBuilder.RenameColumn(
                name: "TOTAL",
                table: "Pedidos",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "Pedidos",
                newName: "Email");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Pedidos",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Pedidos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PRE_UNIT",
                table: "DetallePedidos",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "ArticuloID",
                table: "DetallePedidos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "DetallePedidos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PedidoID",
                table: "DetallePedidos",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PRE_VENT",
                table: "Articulos",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PRE_COMP",
                table: "Articulos",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<string>(nullable: true),
                    ArticuloId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Carts_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartId);
                });

            migrationBuilder.UpdateData(
                table: "Articulos",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "PRE_COMP", "PRE_VENT" },
                values: new object[] { 15m, 15m });

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_ArticuloID",
                table: "DetallePedidos",
                column: "ArticuloID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_PedidoID",
                table: "DetallePedidos",
                column: "PedidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ArticuloId",
                table: "Carts",
                column: "ArticuloId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Articulos_ArticuloID",
                table: "DetallePedidos",
                column: "ArticuloID",
                principalTable: "Articulos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Pedidos_PedidoID",
                table: "DetallePedidos",
                column: "PedidoID",
                principalTable: "Pedidos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Articulos_ArticuloID",
                table: "DetallePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallePedidos_Pedidos_PedidoID",
                table: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedidos_ArticuloID",
                table: "DetallePedidos");

            migrationBuilder.DropIndex(
                name: "IX_DetallePedidos_PedidoID",
                table: "DetallePedidos");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ArticuloID",
                table: "DetallePedidos");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "DetallePedidos");

            migrationBuilder.DropColumn(
                name: "PedidoID",
                table: "DetallePedidos");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Pedidos",
                newName: "TOTAL");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Pedidos",
                newName: "EMAIL");

            migrationBuilder.AlterColumn<double>(
                name: "TOTAL",
                table: "Pedidos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "ADDR",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CLI_ID",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "COMENT",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ESTADOID",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EST_ID",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FECH_ORD",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "LAT",
                table: "Pedidos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LONG",
                table: "Pedidos",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "USER",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PRE_UNIT",
                table: "DetallePedidos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "DESC",
                table: "DetallePedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IMG",
                table: "DetallePedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PRE_VENT",
                table: "Articulos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<double>(
                name: "PRE_COMP",
                table: "Articulos",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.UpdateData(
                table: "Articulos",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "PRE_COMP", "PRE_VENT" },
                values: new object[] { 15.0, 15.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ESTADOID",
                table: "Pedidos",
                column: "ESTADOID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_ART_ID",
                table: "DetallePedidos",
                column: "ART_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Articulos_ART_ID",
                table: "DetallePedidos",
                column: "ART_ID",
                principalTable: "Articulos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePedidos_Pedidos_ORD_ID",
                table: "DetallePedidos",
                column: "ORD_ID",
                principalTable: "Pedidos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Estados_ESTADOID",
                table: "Pedidos",
                column: "ESTADOID",
                principalTable: "Estados",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
