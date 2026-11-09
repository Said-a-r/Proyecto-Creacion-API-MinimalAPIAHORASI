using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoAPICatalogoW.Migrations
{
    /// <inheritdoc />
    public partial class JugadoresYMisiones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Puntaje",
                table: "Jugadores");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Jugadores",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PuntajeCifrado",
                table: "Jugadores",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Misiones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "Facil");

            migrationBuilder.UpdateData(
                table: "Misiones",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "Dificil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "PuntajeCifrado",
                table: "Jugadores");

            migrationBuilder.AddColumn<int>(
                name: "Puntaje",
                table: "Jugadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Misiones",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "Prueba Fácil");

            migrationBuilder.UpdateData(
                table: "Misiones",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "Prueba Difícil");
        }
    }
}
