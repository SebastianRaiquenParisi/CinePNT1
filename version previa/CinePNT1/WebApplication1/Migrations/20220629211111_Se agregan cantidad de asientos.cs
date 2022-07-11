using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCineMVC.Migrations
{
    public partial class Seagregancantidaddeasientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Asientos",
                table: "Salas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asientos",
                table: "Salas");
        }
    }
}
