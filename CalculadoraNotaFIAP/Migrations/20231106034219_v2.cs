using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculadoraNotaFIAP.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calcular",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "NotaPrimeiroSemestre",
                table: "Nota");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeFaltas",
                table: "Materia",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeFaltas",
                table: "Materia");

            migrationBuilder.AddColumn<bool>(
                name: "Calcular",
                table: "Nota",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "NotaPrimeiroSemestre",
                table: "Nota",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
