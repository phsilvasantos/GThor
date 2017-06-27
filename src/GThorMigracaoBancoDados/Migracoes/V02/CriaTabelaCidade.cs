using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes.V02
{
    [Migration(2)]
    public class CriaTabelaCidade : Migration
    {
        public override void Up()
        {
            Create.Table("cidade")
                .WithColumn("id")
                .AsInt32()
                .PrimaryKey()
                .Identity()
                .WithColumn("nome")
                .AsString(100)
                .NotNullable()
                .WithColumn("codigoIbge")
                .AsInt32()
                .NotNullable()
                .WithColumn("ufId")
                .AsInt32()
                .NotNullable();

            Create.ForeignKey("fk_cidade__uf")
                .FromTable("cidade").ForeignColumn("ufId")
                .ToTable("uf").PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table("cidade");
        }
    }
}