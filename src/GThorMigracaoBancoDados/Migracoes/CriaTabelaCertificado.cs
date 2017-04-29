using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes
{
    [Migration(131379040434583657)]
    public class CriaTabelaCertificado : Migration
    {
        public override void Up()
        {
            Create.Table("certificadoDigital")
                .WithColumn("id")
                .AsInt32()
                .PrimaryKey()
                .Identity()
                .WithColumn("caminhoCertificado")
                .AsString(255)
                .NotNullable()
                .WithColumn("serial")
                .AsString(255)
                .NotNullable()
                .WithColumn("tipo")
                .AsInt16()
                .NotNullable()
                .WithColumn("senha")
                .AsString(255)
                .NotNullable()
                .WithColumn("descricao")
                .AsString(100)
                .NotNullable();
        }

        public override void Down()
        {
            Delete.Table("certificadoDigital");
        }
    }
}