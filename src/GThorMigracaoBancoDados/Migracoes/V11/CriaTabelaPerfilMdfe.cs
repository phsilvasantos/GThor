using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes.V11
{
    [Migration(11)]
    public class CriaTabelaPerfilMdfe  : Migration
    {
        public override void Up()
        {
            Create.Table("perfilMdfe")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("descricao").AsString(120).NotNullable()
                .WithColumn("empresaId").AsInt32().NotNullable()
                .WithColumn("documentoMdfeId").AsInt32().NotNullable()
                .WithColumn("certificadoDigitalId").AsInt32().NotNullable();

            Create.ForeignKey("fk_perfilMdfe__empresa")
                .FromTable("perfilMdfe").ForeignColumn("empresaId")
                .ToTable("empresa").PrimaryColumn("id");

            Create.ForeignKey("fk_perfilMdfe__documentoMdfe")
                .FromTable("perfilMdfe").ForeignColumn("documentoMdfeId")
                .ToTable("documentoMdfe").PrimaryColumn("id");

            Create.ForeignKey("fk_perfilMdfe__certificadoDigital")
                .FromTable("perfilMdfe").ForeignColumn("certificadoDigitalId")
                .ToTable("certificadoDigital").PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table("perfilMdfe");
        }
    }
}