using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GThorRepositorioEntityFramework.Migrations
{
    public partial class CriaTabelaUsuarioECertificadoDigital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "certificadoDigital",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    caminhoCertificado = table.Column<string>(maxLength: 255, nullable: false),
                    descricao = table.Column<string>(maxLength: 255, nullable: false),
                    senha = table.Column<string>(maxLength: 255, nullable: false),
                    serial = table.Column<string>(maxLength: 255, nullable: false),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificadoDigital", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    login = table.Column<string>(maxLength: 20, nullable: false),
                    senha = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "certificadoDigital");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
