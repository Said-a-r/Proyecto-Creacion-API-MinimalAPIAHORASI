using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoAPICatalogoW.Migrations
{
    /// <inheritdoc />
    public partial class CartasDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Personajes",
                columns: new[] { "Id", "Afiliacion", "Especie", "Estado", "Faccion", "FuerzaSensitivo", "Nombre" },
                values: new object[,]
                {
                    { 1, "Imperio", "Humano", "vivo", "Imperio", false, "Darth Vader" },
                    { 2, "Alianza Rebelde", "Humano", "vivo", "Rebelde", false, "Luke Skywalker" },
                    { 3, "Alianza Rebelde", "Humano", "vivo", "Rebelde", false, "Han Solo" },
                    { 4, "Orden Jedi", "Desconocida", "vivo", "Rebelde", false, "Yoda" },
                    { 5, "Imperio", "Humano", "vivo", "Imperio", false, "Emperador Palpatine" }
                });

            migrationBuilder.InsertData(
                table: "Cartas",
                columns: new[] { "Id", "Arma", "HabilidadEspecial", "ImagenUrl", "JugadorId", "NivelPeligrosidad", "PersonajeId", "Poder" },
                values: new object[,]
                {
                    { 1, "Sable de luz", "Estrangulamiento", "", null, "Alto", 1, 9000 },
                    { 2, "Sable de luz", "Telequinesis", "", null, "Alto", 2, 8500 },
                    { 3, "Bláster", "Puntería", "", null, "Medio", 3, 5000 },
                    { 4, "Sable de luz", "Fuerza Maestra", "", null, "Alto", 4, 9500 },
                    { 5, "Sable de luz", "Rayos", "", null, "Alto", 5, 9800 },
                    { 6, "Sable de luz", "Fuerza Oscura", "", null, "Medio", 1, 8000 },
                    { 7, "Sable de luz", "Maestría Jedi", "", null, "Medio", 2, 7800 },
                    { 8, "Bláster", "Disparo Rápido", "", null, "Bajo", 3, 4500 },
                    { 9, "Sable de luz", "Salto Alto", "", null, "Alto", 4, 9200 },
                    { 10, "Sable de luz", "Manipulación", "", null, "Medio", 5, 8900 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cartas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cartas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cartas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cartas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cartas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cartas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cartas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cartas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cartas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cartas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Personajes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personajes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personajes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personajes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Personajes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
