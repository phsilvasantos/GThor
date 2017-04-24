using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GThorRepositorioEntityFramework.Migrations
{
    public partial class CriaTabelaPessoaTransCond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cidadeId = table.Column<int>(nullable: false),
                    cnpj = table.Column<string>(maxLength: 14, nullable: false),
                    cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    email = table.Column<string>(maxLength: 255, nullable: false),
                    InscricaoEstadual = table.Column<string>(maxLength: 30, nullable: false),
                    nome = table.Column<string>(maxLength: 255, nullable: false),
                    nomeFantasia = table.Column<string>(maxLength: 255, nullable: false),
                    telefone = table.Column<string>(maxLength: 11, nullable: false),
                    tipoPessoa = table.Column<int>(nullable: false),
                    ufId = table.Column<int>(nullable: false),
                    rntrc = table.Column<string>(maxLength: 8, nullable: false),
                    tipoProprietario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.id);
                    table.ForeignKey(
                        name: "FK_pessoa_cidade_cidadeId",
                        column: x => x.cidadeId,
                        principalTable: "cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pessoa_uf_ufId",
                        column: x => x.ufId,
                        principalTable: "uf",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_cidadeId",
                table: "pessoa",
                column: "cidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_ufId",
                table: "pessoa",
                column: "ufId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pessoa");
        }
    }
}
