using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes
{
    [Migration(131379850045588718)]
    public class CriaTabelaPessoaERelacoes : Migration
    {
        public override void Up()
        {
            Create.Table("pessoa")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("tipoPessoa").AsInt16().NotNullable()
                .WithColumn("nome").AsString(255).NotNullable()
                .WithColumn("nomeFantasia").AsString(255).NotNullable()
                .WithColumn("cnpj").AsString(14).NotNullable()
                .WithColumn("cpf").AsString(11).NotNullable()
                .WithColumn("inscricaoEstadual").AsString(30).NotNullable()
                .WithColumn("telefone").AsString(11).NotNullable()
                .WithColumn("email").AsString(255).NotNullable()
                .WithColumn("ufId").AsInt32().NotNullable()
                .WithColumn("cidadeId").AsInt32().NotNullable();


            Create.Table("transportadora")
                .WithColumn("pessoaId").AsInt32().PrimaryKey()
                .WithColumn("rntrc").AsString(8).NotNullable()
                .WithColumn("tipoProprietario").AsInt16().NotNullable();

            Create.Table("condutor")
                .WithColumn("pessoaId").AsInt32().PrimaryKey();


            Create.ForeignKey("fk_pessoa__uf")
                .FromTable("pessoa").ForeignColumn("ufId")
                .ToTable("uf").PrimaryColumn("id");

            Create.ForeignKey("fk_pessoa__cidade")
                .FromTable("pessoa").ForeignColumn("cidadeId")
                .ToTable("cidade").PrimaryColumn("id");

            Create.ForeignKey("fk_transportadora__pessoa")
                .FromTable("transportadora").ForeignColumn("pessoaId")
                .ToTable("pessoa").PrimaryColumn("id");

            Create.ForeignKey("fk_condutor__pessoa")
                .FromTable("condutor").ForeignColumn("pessoaId")
                .ToTable("pessoa").PrimaryColumn("id");


        }

        public override void Down()
        {
            Delete.Table("condutor");
            Delete.Table("transportadora");
            Delete.Table("pessoa");
        }
    }
}