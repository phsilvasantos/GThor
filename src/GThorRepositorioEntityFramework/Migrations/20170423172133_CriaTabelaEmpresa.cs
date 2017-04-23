using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GThorRepositorioEntityFramework.Migrations
{
    public partial class CriaTabelaEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    bairro = table.Column<string>(maxLength: 60, nullable: false),
                    cep = table.Column<string>(maxLength: 8, nullable: false),
                    cidadeId = table.Column<int>(nullable: false),
                    cnpj = table.Column<string>(maxLength: 14, nullable: false),
                    complemento = table.Column<string>(maxLength: 60, nullable: false),
                    email = table.Column<string>(maxLength: 255, nullable: false),
                    inscricaoEstadual = table.Column<string>(maxLength: 30, nullable: false),
                    logradouro = table.Column<string>(maxLength: 255, nullable: false),
                    nomeFantasia = table.Column<string>(maxLength: 255, nullable: false),
                    numero = table.Column<string>(maxLength: 60, nullable: false),
                    razaoSocial = table.Column<string>(maxLength: 255, nullable: false),
                    rntrc = table.Column<string>(maxLength: 8, nullable: false),
                    telefone = table.Column<string>(maxLength: 11, nullable: false),
                    ufId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.id);
                    table.ForeignKey(
                        name: "FK_empresa_cidade_cidadeId",
                        column: x => x.cidadeId,
                        principalTable: "cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empresa_uf_ufId",
                        column: x => x.ufId,
                        principalTable: "uf",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_empresa_cidadeId",
                table: "empresa",
                column: "cidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_empresa_ufId",
                table: "empresa",
                column: "ufId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empresa");
        }
    }
}
