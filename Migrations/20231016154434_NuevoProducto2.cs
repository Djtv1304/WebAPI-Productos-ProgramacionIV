using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_Productos_ProgramacionIV.Migrations
{
    /// <inheritdoc />
    public partial class NuevoProducto2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "IdProducto", "Cantidad", "Descripcion", "Nombre" },
                values: new object[] { 2, 25, "Descripción Producto 2", "Producto 2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Producto",
                keyColumn: "IdProducto",
                keyValue: 2);
        }
    }
}
