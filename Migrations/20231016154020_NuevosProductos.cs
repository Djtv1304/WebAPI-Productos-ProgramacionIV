using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_Productos_ProgramacionIV.Migrations
{
    /// <inheritdoc />
    public partial class NuevosProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "IdProducto", "Cantidad", "Descripcion", "Nombre" },
                values: new object[] { 1, 34, "Descripcion Producto 1", "Producto 1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: 1);
        }
    }
}
