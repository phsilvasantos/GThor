using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes
{
    [Migration(131379039915232884)]
    public class CriaTabelaEstadoUf : Migration
    {
        public override void Up()
        {
            Create.Table("uf")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("sigla").AsString(2).NotNullable()
                .WithColumn("nome").AsString(100).NotNullable()
                .WithColumn("codigoIbge").AsInt16().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("uf");
        }
    }
}