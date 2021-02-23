using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taller.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(20)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(20)", nullable: false),
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
                    Tipo = table.Column<string>(type: "varchar(30)", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mecanicos",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "varchar(11)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(20)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(20)", nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
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
                    CostoTotalServicio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Autos_Auto_Id",
                        column: x => x.Auto_Id,
                        principalTable: "Autos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_Mecanicos_Mecanico_Id",
                        column: x => x.Mecanico_Id,
                        principalTable: "Mecanicos",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesOrden",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orden_Id = table.Column<int>(nullable: false),
                    Servicio_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesOrden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesOrden_Ordenes_Orden_Id",
                        column: x => x.Orden_Id,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesOrden_Servicios_Servicio_Id",
                        column: x => x.Servicio_Id,
                        principalTable: "Servicios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_Cliente_Id",
                table: "Autos",
                column: "Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrden_Orden_Id",
                table: "DetallesOrden",
                column: "Orden_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesOrden_Servicio_Id",
                table: "DetallesOrden",
                column: "Servicio_Id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesOrden");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Mecanicos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposMecanico");
        }
    }
}
