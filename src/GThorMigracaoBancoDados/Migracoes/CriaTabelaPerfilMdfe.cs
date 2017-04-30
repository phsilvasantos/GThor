using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes
{
    [Migration(131380344028956477)]
    public class CriaTabelaPerfilMdfe  : Migration
    {
        public override void Up()
        {
            Create.Table("perfilMdfe")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("empresaId").AsInt32().NotNullable()
                .WithColumn("documentoMdfeId").AsInt32().NotNullable()
                .WithColumn("certificadoDigitalId").AsInt32().NotNullable()
                .WithColumn("ufCarregamentoId").AsInt32().Nullable()
                .WithColumn("ufDescarregamentoId").AsInt32().Nullable()
                .WithColumn("veiculoTracaoId").AsInt32().Nullable()
                .WithColumn("observacao").AsString(5000).NotNullable();

            Create.ForeignKey("fk_perfilMdfe__empresa")
                .FromTable("perfilMdfe").ForeignColumn("empresaId")
                .ToTable("empresa").PrimaryColumn("id");

            Create.ForeignKey("fk_perfilMdfe__documentoMdfe")
                .FromTable("perfilMdfe").ForeignColumn("documentoMdfeId")
                .ToTable("documentoMdfe").PrimaryColumn("id");

            Create.ForeignKey("fk_perfilMdfe__certificadoDigital")
                .FromTable("perfilMdfe").ForeignColumn("certificadoDigitalId")
                .ToTable("certificadoDigital").PrimaryColumn("id");

            Create.ForeignKey("fk_perfilMdfe__ufCarregamento")
                .FromTable("perfilMdfe").ForeignColumn("ufCarregamentoId")
                .ToTable("uf").PrimaryColumn("id");

            Create.ForeignKey("fk_perfilMdfe__ufDescarregamento")
                .FromTable("perfilMdfe").ForeignColumn("ufDescarregamentoId")
                .ToTable("uf").PrimaryColumn("id");

            Create.ForeignKey("fk_perfilMdfe__veiculoTracao")
                .FromTable("perfilMdfe").ForeignColumn("veiculoTracaoId")
                .ToTable("veiculo").PrimaryColumn("id");
        }

        public override void Down()
        {
            Delete.Table("perfilMdfe");
        }
    }
}