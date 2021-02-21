using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taller.Migrations
{
    public partial class ModificModelClienteAndMecanico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Mecanicos");

            migrationBuilder.RenameColumn(
                name: "Tiepo",
                table: "TiposMecanico",
                newName: "Tipo");

            migrationBuilder.AddColumn<decimal>(
                name: "CostoServicio",
                table: "Ordenes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Mecanicos",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Mecanicos",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Mecanicos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Mecanicos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clientes",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Clientes",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostoServicio",
                table: "Ordenes");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Mecanicos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Mecanicos");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "TiposMecanico",
                newName: "Tiepo");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Mecanicos",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Mecanicos",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Mecanicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clientes",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");
        }
    }
}
