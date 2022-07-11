using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCineMVC.Migrations
{
    public partial class Imagenes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Peliculas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Peliculas",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoFile",
                table: "Peliculas",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Dni",
                table: "Compra",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "PhotoFile",
                table: "Peliculas");

            migrationBuilder.AlterColumn<string>(
                name: "Dni",
                table: "Compra",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
