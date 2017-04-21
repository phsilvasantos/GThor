using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GThorRepositorioEntityFramework.Migrations
{
    public partial class AdicionadoM3Veiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "capacidadeEmM3",
                table: "veiculo",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "capacidadeEmM3",
                table: "veiculo");
        }
    }
}
