using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiVenta.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Cantidad", "DateCreate", "DateDelete", "Name", "Precio", "SoftDelete" },
                values: new object[,]
                {
                    { 1, 100, new DateTime(2024, 8, 8, 20, 48, 8, 459, DateTimeKind.Local).AddTicks(7355), new DateTime(2024, 8, 8, 20, 48, 8, 459, DateTimeKind.Local).AddTicks(7368), "Procuto1", 194.34m, false },
                    { 2, 65, new DateTime(2024, 8, 8, 20, 48, 8, 459, DateTimeKind.Local).AddTicks(7370), new DateTime(2024, 8, 8, 20, 48, 8, 459, DateTimeKind.Local).AddTicks(7370), "Procuto2", 56.34m, false },
                    { 3, 20, new DateTime(2024, 8, 8, 20, 48, 8, 459, DateTimeKind.Local).AddTicks(7372), new DateTime(2024, 8, 8, 20, 48, 8, 459, DateTimeKind.Local).AddTicks(7372), "Procuto3", 15.34m, false }
                });

            migrationBuilder.InsertData(
                table: "Codigos",
                columns: new[] { "Id", "NoCodigo", "ProductoId" },
                values: new object[,]
                {
                    { 1, "Codigo1", 1 },
                    { 2, "Codigo2", 1 },
                    { 3, "Codigo3", 2 },
                    { 4, "Codigo4", 2 },
                    { 5, "Codigo5", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Codigos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Codigos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Codigos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Codigos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Codigos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
