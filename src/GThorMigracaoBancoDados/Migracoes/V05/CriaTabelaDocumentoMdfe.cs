using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes.V05
{
    [Migration(5)]
    public class CriaTabelaDocumentoMdfe : Migration
    {
        public override void Up()
        {
            Create.Table("documentoMdfe")
                .WithColumn("id")
                .AsInt32()
                .PrimaryKey()
                .Identity()
                .WithColumn("descricao")
                .AsString(100)
                .NotNullable()
                .WithColumn("ambienteSefaz")
                .AsInt16()
                .NotNullable()
                .WithColumn("serie")
                .AsInt16()
                .NotNullable()
                .WithColumn("ultimoNumeroUsado")
                .AsInt64()
                .NotNullable();
        }

        public override void Down()
        {
            Delete.Table("documentoMdfe");
        }
    }
}