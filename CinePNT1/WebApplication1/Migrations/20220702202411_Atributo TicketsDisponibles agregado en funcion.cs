using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCineMVC.Migrations
{
    public partial class AtributoTicketsDisponiblesagregadoenfuncion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Peliculas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketsDisponibles",
                table: "Funciones",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketsDisponibles",
                table: "Funciones");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Peliculas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
