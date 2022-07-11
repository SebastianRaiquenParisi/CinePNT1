using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCineMVC.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funciones_Peliculas_PeliculaId",
                table: "Funciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Funciones_Salas_SalaId",
                table: "Funciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Salas_Complejos_ComplejoId",
                table: "Salas");

            migrationBuilder.DropTable(
                name: "Complejos");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Compradores");

            migrationBuilder.DropIndex(
                name: "IX_Salas_ComplejoId",
                table: "Salas");

            migrationBuilder.DropColumn(
                name: "ComplejoId",
                table: "Salas");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Salas");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Salas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Funciones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeliculaId",
                table: "Funciones",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Funciones_Peliculas_PeliculaId",
                table: "Funciones",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funciones_Salas_SalaId",
                table: "Funciones",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funciones_Peliculas_PeliculaId",
                table: "Funciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Funciones_Salas_SalaId",
                table: "Funciones");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Salas");

            migrationBuilder.AddColumn<int>(
                name: "ComplejoId",
                table: "Salas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Salas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalaId",
                table: "Funciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PeliculaId",
                table: "Funciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fila = table.Column<int>(type: "int", nullable: false),
                    IdEntrada = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Complejos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complejos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsientoId = table.Column<int>(type: "int", nullable: true),
                    CompradorId = table.Column<int>(type: "int", nullable: true),
                    FuncionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entradas_Asientos_AsientoId",
                        column: x => x.AsientoId,
                        principalTable: "Asientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entradas_Compradores_CompradorId",
                        column: x => x.CompradorId,
                        principalTable: "Compradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Entradas_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salas_ComplejoId",
                table: "Salas",
                column: "ComplejoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_AsientoId",
                table: "Entradas",
                column: "AsientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_CompradorId",
                table: "Entradas",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_FuncionId",
                table: "Entradas",
                column: "FuncionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funciones_Peliculas_PeliculaId",
                table: "Funciones",
                column: "PeliculaId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funciones_Salas_SalaId",
                table: "Funciones",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salas_Complejos_ComplejoId",
                table: "Salas",
                column: "ComplejoId",
                principalTable: "Complejos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
