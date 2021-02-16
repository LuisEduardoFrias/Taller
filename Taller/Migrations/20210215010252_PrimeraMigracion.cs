using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taller.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "Date", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "TiposMecanico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tiepo = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMecanico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "varchar(50)", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Años = table.Column<byte>(type: "tinyint", nullable: false),
                    Color = table.Column<string>(type: "varchar(20)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(10)", nullable: false),
                    Cliente_Id = table.Column<string>(type: "varchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autos_Clientes_Cliente_Id",
                        column: x => x.Cliente_Id,
                        principalTable: "Clientes",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Mecanicos",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "Date", nullable: false),
                    TipoMecanico_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecanicos", x => x.Cedula);
                    table.ForeignKey(
                        name: "FK_Mecanicos_TiposMecanico_TipoMecanico_Id",
                        column: x => x.TipoMecanico_Id,
                        principalTable: "TiposMecanico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    Mecanico_Id = table.Column<string>(type: "varchar(11)", nullable: false),
                    Auto_Id = table.Column<int>(nullable: false),
                    Servicio_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Autos_Auto_Id",
                        column: x => x.Auto_Id,
                        principalTable: "Autos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ordenes_Mecanicos_Mecanico_Id",
                        column: x => x.Mecanico_Id,
                        principalTable: "Mecanicos",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ordenes_Servicios_Servicio_Id",
                        column: x => x.Servicio_Id,
                        principalTable: "Servicios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_Cliente_Id",
                table: "Autos",
                column: "Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mecanicos_TipoMecanico_Id",
                table: "Mecanicos",
                column: "TipoMecanico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Auto_Id",
                table: "Ordenes",
                column: "Auto_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Mecanico_Id",
                table: "Ordenes",
                column: "Mecanico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Servicio_Id",
                table: "Ordenes",
                column: "Servicio_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Mecanicos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposMecanico");
        }
    }
}
