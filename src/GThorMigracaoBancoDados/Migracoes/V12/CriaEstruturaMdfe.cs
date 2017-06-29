using FluentMigrator;

namespace GThorMigracaoBancoDados.Migracoes.V12
{
    [Migration(12)]
    public class CriaEstruturaMdfe : Migration
    {
        public override void Up()
        {
            // Cria tabela mdfe
            Create.Table("mdfe")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("serie").AsInt16().NotNullable()
                .WithColumn("numeroManifesto").AsInt64().NotNullable()
                .WithColumn("perfilMdfeId").AsInt32().NotNullable()
                .WithColumn("tipoEmitente").AsInt16().NotNullable()
                .WithColumn("tipoTransportador").AsInt16().NotNullable()
                .WithColumn("modal").AsInt16().NotNullable()
                .WithColumn("ufCarregamentoId").AsInt32().NotNullable()
                .WithColumn("ufDescarregamentoId").AsInt32().NotNullable()
                .WithColumn("rntrc").AsString(8).NotNullable()
                .WithColumn("observacao").AsString(5000).NotNullable();

            Create.ForeignKey("fk_mdfe__perfilMdfe")
                .FromTable("mdfe").ForeignColumn("perfilMdfeId")
                .ToTable("perfilMdfe").PrimaryColumn("id");

            Create.ForeignKey("fk_mdfe__ufCarregamento")
                .FromTable("mdfe").ForeignColumn("ufCarregamentoId")
                .ToTable("uf").PrimaryColumn("id");

            Create.ForeignKey("fk_mdfe__ufDescarregamento")
                .FromTable("mdfe").ForeignColumn("ufDescarregamentoId")
                .ToTable("uf").PrimaryColumn("id");

            // Cria tabela mdfeEmitente
            Create.Table("mdfeEmitente")
                .WithColumn("mdfeId").AsInt32().PrimaryKey()
                .WithColumn("empresaId").AsInt32().NotNullable();

            Create.ForeignKey("fk_mdfeEmitente__mdfe")
                .FromTable("mdfeEmitente").ForeignColumn("mdfeId")
                .ToTable("mdfe").PrimaryColumn("id");

            Create.ForeignKey("fk_mdfeEmitente__empresa")
                .FromTable("mdfeEmitente").ForeignColumn("empresaId")
                .ToTable("empresa").PrimaryColumn("id");


            // Cria tabela mdfeMunicipioCarregamento
            Create.Table("mdfeMunicipioCarregamento")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("mdfeId").AsInt32().NotNullable()
                .WithColumn("cidadeId").AsInt32().NotNullable();

            Create.ForeignKey("fk_mdfeMunicipioCarregamento__mdfe")
                .FromTable("mdfeMunicipioCarregamento").ForeignColumn("mdfeId")
                .ToTable("mdfe").PrimaryColumn("id");

            Create.ForeignKey("fk_mdfeMunicipioCarregamento__cidade")
                .FromTable("mdfeMunicipioCarregamento").ForeignColumn("cidadeId")
                .ToTable("cidade").PrimaryColumn("id");

            // Cria tabela mdfePercurso
            Create.Table("mdfePercurso")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("mdfeId").AsInt32().NotNullable()
                .WithColumn("ufId").AsInt32().NotNullable();

            Create.ForeignKey("fk_mdfePercurso__mdfe")
                .FromTable("mdfePercurso").ForeignColumn("mdfeId")
                .ToTable("mdfe").PrimaryColumn("id");

            Create.ForeignKey("fk_mdfePercurso__uf")
                .FromTable("mdfePercurso").ForeignColumn("ufId")
                .ToTable("uf").PrimaryColumn("id");

            // Cria tabela mdfeMunicipioDescarga
            Create.Table("mdfeMunicipioDescarga")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("mdfeId").AsInt32().NotNullable()
                .WithColumn("cidadeId").AsInt32().NotNullable()
                .WithColumn("chaveAcesso").AsString(44).NotNullable()
                .WithColumn("tipoDocumentoEletronico").AsInt16().NotNullable();

            Create.ForeignKey("fk_mdfeMunicipioDescarga__mdfe")
                .FromTable("mdfeMunicipioDescarga").ForeignColumn("mdfeId")
                .ToTable("mdfe").PrimaryColumn("id");

            Create.ForeignKey("fk_mdfeMunicipioDescarga__cidade")
                .FromTable("mdfeMunicipioDescarga").ForeignColumn("cidadeId")
                .ToTable("cidade").PrimaryColumn("id");


            // Cria tabela mdfeSeguro
            Create.Table("mdfeSeguro")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("mdfeId").AsInt32().NotNullable()
                .WithColumn("responsavel").AsInt16().NotNullable()
                .WithColumn("documentoUnicoResponsavel").AsString(14).NotNullable()
                .WithColumn("nome").AsString(30).NotNullable()
                .WithColumn("documentoUnico").AsString(14).NotNullable()
                .WithColumn("numeroApolice").AsString(20).NotNullable();

            Create.ForeignKey("fk_mdfeSeguro__mdfe")
                .FromTable("mdfeSeguro").ForeignColumn("mdfeId")
                .ToTable("mdfe").PrimaryColumn("id");


            // Cria tabela mdfeNumeroAverbacao
            Create.Table("mdfeNumeroAverbacao")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("seguroId").AsInt32().NotNullable()
                .WithColumn("averbacao").AsString(40).NotNullable();

            Create.ForeignKey("fk_mdfeNumeroAverbacao__mdfeSeguro")
                .FromTable("mdfeNumeroAverbacao").ForeignColumn("seguroId")
                .ToTable("mdfeSeguro").PrimaryColumn("id");
        }

        public override void Down()
        {
            
        }
    }
}