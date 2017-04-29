using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes
{
    [Migration(131379040685947915)]
    public class CriaTabelaEmpresa : Migration
    {
        public override void Up()
        {
            Create.Table("empresa")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("cnpj").AsString(14).NotNullable()
                .WithColumn("inscricaoEstadual").AsString(30).NotNullable()
                .WithColumn("rntrc").AsString(8).NotNullable()
                .WithColumn("razaoSocial").AsString(255).NotNullable()
                .WithColumn("nomeFantasia").AsString(255).NotNullable()
                .WithColumn("logradouro").AsString(255).NotNullable()
                .WithColumn("numero").AsString(60).NotNullable()
                .WithColumn("complemento").AsString(60).NotNullable()
                .WithColumn("bairro").AsString(60).NotNullable()
                .WithColumn("cep").AsString(8).NotNullable()
                .WithColumn("telefone").AsString(11).NotNullable()
                .WithColumn("email").AsString(255).NotNullable()
                .WithColumn("cidadeId").AsInt32().NotNullable()
                .WithColumn("ufId").AsInt32().NotNullable();

            Create.ForeignKey("fk_empresa__uf")
                .FromTable("empresa").ForeignColumn("ufId")
                .ToTable("uf").PrimaryColumn("id");

            Create.ForeignKey("fk_empresa__cidade")
                .FromTable("empresa").ForeignColumn("cidadeId")
                .ToTable("cidade").PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table("empresa");
        }
    }
}