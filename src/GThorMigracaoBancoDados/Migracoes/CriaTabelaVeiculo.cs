using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes
{
    [Migration(5)]
    public class CriaTabelaVeiculo : Migration
    {
        public override void Up()
        {
            Create.Table("veiculo")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("descricao").AsString(100).NotNullable()
                .WithColumn("codigoInterno").AsString(10).NotNullable()
                .WithColumn("placa").AsString(7).NotNullable()
                .WithColumn("renavam").AsString(11).NotNullable()
                .WithColumn("taraEmKg").AsInt32().NotNullable()
                .WithColumn("capacidadeEmKg").AsInt32().NotNullable()
                .WithColumn("capacidadeEmM3").AsInt32().NotNullable()
                .WithColumn("tipoRodado").AsInt16().NotNullable()
                .WithColumn("tipoCarroceria").AsInt16().NotNullable()
                .WithColumn("ufId").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("veiculo");
        }
    }
}