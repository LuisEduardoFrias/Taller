﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taller.Data;

namespace Taller.Migrations
{
    [DbContext(typeof(TallerDbContext))]
    [Migration("20210215010252_PrimeraMigracion")]
    partial class PrimeraMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Taller.Models.Auto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Años")
                        .HasColumnType("tinyint");

                    b.Property<string>("Cliente_Id")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Modelos")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Cliente_Id");

                    b.ToTable("Autos");
                });

            modelBuilder.Entity("Taller.Models.Cliente", b =>
                {
                    b.Property<string>("Cedula")
                        .HasColumnType("varchar(11)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("Date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Cedula");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Taller.Models.Mecanico", b =>
                {
                    b.Property<string>("Cedula")
                        .HasColumnType("varchar(11)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("Date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TipoMecanico_Id")
                        .HasColumnType("int");

                    b.HasKey("Cedula");

                    b.HasIndex("TipoMecanico_Id");

                    b.ToTable("Mecanicos");
                });

            modelBuilder.Entity("Taller.Models.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Auto_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("Date");

                    b.Property<string>("Mecanico_Id")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<int>("Servicio_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Auto_Id");

                    b.HasIndex("Mecanico_Id");

                    b.HasIndex("Servicio_Id");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("Taller.Models.Servicio", b =>
                {
                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Codigo");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Taller.Models.TipoMecanico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tiepo")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("TiposMecanico");
                });

            modelBuilder.Entity("Taller.Models.Auto", b =>
                {
                    b.HasOne("Taller.Models.Cliente", "Cliente")
                        .WithMany("Autos")
                        .HasForeignKey("Cliente_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Taller.Models.Mecanico", b =>
                {
                    b.HasOne("Taller.Models.TipoMecanico", "TipoMecanico")
                        .WithMany("Mecanicos")
                        .HasForeignKey("TipoMecanico_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Taller.Models.Orden", b =>
                {
                    b.HasOne("Taller.Models.Auto", "Auto")
                        .WithMany("Ordenes")
                        .HasForeignKey("Auto_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Taller.Models.Mecanico", "Mecanico")
                        .WithMany("Ordenes")
                        .HasForeignKey("Mecanico_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Taller.Models.Servicio", "Servicio")
                        .WithMany("Ordenes")
                        .HasForeignKey("Servicio_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
