using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes
{
    [Migration(4)]
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
        }

        public override void Down()
        {
            Delete.Table("cidade");
        }
    }
}