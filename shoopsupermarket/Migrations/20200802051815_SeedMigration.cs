using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shoopsupermarket.Migrations
{
    public partial class SeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { 2, "Jugo de Manzana", "https://res.cloudinary.com/almacendo/image/upload/v1569273056/Jugos/Jugo-Santal-Sabor-Manzana_-200ml-Caja-_24-uds_-Turn.jpg", 15.0, 15.0, 1, 20 });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "CAT_ID", "DESC", "IMG", "PRE_COMP", "PRE_VENT", "PROV_ID", "STOCK" },
                values: new object[] { 2, "Jugo de Naranja", "https://res.cloudinary.com/almacendo/image/upload/v1569273056/Jugos/Jugo-Santal-Sabor-Manzana_-200ml-Caja-_24-uds_-Turn.jpg", 15.0, 15.0, 2, 50 });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "CAT_ID", "DESC", "IMG", "PRE_COMP", "PRE_VENT", "PROV_ID", "STOCK" },
                values: new object[] { 1, "Salami", "https://res.cloudinary.com/almacendo/image/upload/v1569273056/Jugos/Jugo-Santal-Sabor-Manzana_-200ml-Caja-_24-uds_-Turn.jpg", 50.0, 20.0, 3, 100 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
