using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GThorRepositorioEntityFramework.Migrations
{
    public partial class CriaTabelaVeiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "veiculo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    capacidadeEmKg = table.Column<int>(nullable: false),
                    codigoInterno = table.Column<string>(maxLength: 10, nullable: true),
                    descricao = table.Column<string>(maxLength: 100, nullable: false),
                    placa = table.Column<string>(maxLength: 7, nullable: false),
                    renavam = table.Column<string>(maxLength: 11, nullable: false),
                    taraEmKg = table.Column<int>(nullable: false),
                    tipoCarroceria = table.Column<int>(nullable: false),
                    tipoRodado = table.Column<int>(nullable: false),
                    ufId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veiculo", x => x.id);
                    table.ForeignKey(
                        name: "FK_veiculo_uf_ufId",
                        column: x => x.ufId,
                        principalTable: "uf",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_veiculo_ufId",
                table: "veiculo",
                column: "ufId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "veiculo");
        }
    }
}
