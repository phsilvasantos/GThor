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

            // Cria tabela mdfeTotal
            Create.Table("mdfeTotal")
                .WithColumn("mdfeId").AsInt32().PrimaryKey()
                .WithColumn("quantidadeCte").AsInt32().NotNullable()
                .WithColumn("quantidadeNfe").AsInt32().NotNullable()
                .WithColumn("valorTotalCarga").AsDecimal(15, 2).NotNullable()
                .WithColumn("pesoBrutoCarga").AsDecimal(15, 4).NotNullable()
                .WithColumn("unidadeMedida").AsInt16().NotNullable();

            Create.ForeignKey("fk_mdfeTotal__mdfe")
                .FromTable("mdfeTotal").ForeignColumn("mdfeId")
                .ToTable("mdfe").PrimaryColumn("id");

            // Cria tabela mdfeValePedagio
            Create.Table("mdfeValePedagio")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("mdfeId").AsInt32().NotNullable()
                .WithColumn("cnpjEmpresaFornecedora").AsString(14).NotNullable()
                .WithColumn("documentoUnicoResponsavelPagamento").AsString(14).NotNullable()
                .WithColumn("numeroDoComprovanteCompra").AsString(20).NotNullable()
                .WithColumn("valor").AsDecimal(15, 2).NotNullable();

            Create.ForeignKey("fk_mdfeValePedagio__mdfe")
                .FromTable("mdfeValePedagio").ForeignColumn("mdfeId")
                .ToTable("mdfe").PrimaryColumn("id");

            // Cria Tabela mdfeCiot
            Create.Table("mdfeCiot")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("mdfeId").AsInt32().NotNullable()
                .WithColumn("ciot").AsInt64().NotNullable()
                .WithColumn("documentoUnico").AsString(14).NotNullable();

            Create.ForeignKey("fk_mdfeCiot__mdfe")
                .FromTable("mdfeCiot").ForeignColumn("mdfeId")
                .ToTable("mdfe").PrimaryColumn("id");

            // Cria tabela mdfeContratante
            Create.Table("mdfeContratante")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("mdfeId").AsInt32().NotNullable()
                .WithColumn("documentoUnico").AsString(14).NotNullable();

            Create.ForeignKey("fk_mdfeContratante__mdfe")
                .FromTable("mdfeContratante").ForeignColumn("mdfeId")
                .ToTable("mdfe").PrimaryColumn("id");

            // Cria tabela mdfeVeiculoTracao
            Create.Table("mdfeVeiculoTracao")
                .WithColumn("mdfeId").AsInt32().PrimaryKey()
                .WithColumn("veiculoId").AsInt32().NotNullable()
                .WithColumn("proprietarioId").AsInt32();

            Create.ForeignKey("fk_mdfeVeiculoTracao__mdfe")
                .FromTable("mdfeVeiculoTracao").ForeignColumn("mdfeId")
                .ToTable("mdfe").PrimaryColumn("id");

            Create.ForeignKey("fk_mdfeVeiculoTracao__pessoaProprietaria")
                .FromTable("mdfeVeiculoTracao").ForeignColumn("proprietarioId")
                .ToTable("pessoa").PrimaryColumn("id");

            // Cria tabela mdfeCondutor
            Create.Table("mdfeCondutor")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("veiculoTracaoId").AsInt32().NotNullable()
                .WithColumn("condutorId").AsInt32().NotNullable();

            Create.ForeignKey("fk_mdfeCondutor__mdfeVeiculoTracao")
                .FromTable("mdfeCondutor").ForeignColumn("veiculoTracaoId")
                .ToTable("mdfeVeiculoTracao").PrimaryColumn("mdfeId");

            Create.ForeignKey("fk_mdfeCondutor__condutor")
                .FromTable("mdfeCondutor").ForeignColumn("condutorId")
                .ToTable("condutor").PrimaryColumn("pessoaId");

            // Cria tabela mdfeEmissaoHistorico
            Create.Table("mdfeEmissaoHistorico")
                .WithColumn("mdfeId").AsInt32().PrimaryKey()
                .WithColumn("versaoLayout").AsString(12).NotNullable()
                .WithColumn("chaveTag").AsString(48).NotNullable()
                .WithColumn("chave").AsString(44).NotNullable()
                .WithColumn("ufId").AsInt32().NotNullable()
                .WithColumn("ambienteSefaz").AsInt16().NotNullable()
                .WithColumn("modeloDocumento").AsInt16().NotNullable()
                .WithColumn("serie").AsInt32().NotNullable()
                .WithColumn("numeroManifesto").AsInt64().NotNullable()
                .WithColumn("codigoNumerico").AsInt32().NotNullable()
                .WithColumn("digitoVerificador").AsInt16().NotNullable()
                .WithColumn("emissaoFeitaEm").AsDateTime().NotNullable()
                .WithColumn("tipoEmissao").AsInt16().NotNullable()
                .WithColumn("xmlEnvio").AsString().NotNullable()
                .WithColumn("xmlRetorno").AsString()
                .WithColumn("mensagemRetorno").AsString(255).NotNullable()
                .WithColumn("codigoAutorizacao").AsInt32().NotNullable()
                .WithColumn("versaoProcessoEmissao").AsString(20).NotNullable()
                .WithColumn("finalizou").AsBoolean().NotNullable();

            Create.ForeignKey("fk_mdfeEmissaoHistorico__uf")
                .FromTable("mdfeEmissaoHistorico").ForeignColumn("ufId")
                .ToTable("uf").PrimaryColumn("id");


            // Cria tabela mdfeEmissaoFinalizada
            Create.Table("mdfeEmissaoFinalizada")
                .WithColumn("mdfeId").AsInt32().PrimaryKey()
                .WithColumn("versaoLayout").AsString(12).NotNullable()
                .WithColumn("chaveTag").AsString(48).NotNullable()
                .WithColumn("chave").AsString(44).NotNullable()
                .WithColumn("ufId").AsInt32().NotNullable()
                .WithColumn("ambienteSefaz").AsInt16().NotNullable()
                .WithColumn("modeloDocumento").AsInt16().NotNullable()
                .WithColumn("serie").AsInt32().NotNullable()
                .WithColumn("numeroManifesto").AsInt64().NotNullable()
                .WithColumn("codigoNumerico").AsInt32().NotNullable()
                .WithColumn("digitoVerificador").AsInt16().NotNullable()
                .WithColumn("emissaoFeitaEm").AsDateTime().NotNullable()
                .WithColumn("tipoEmissao").AsInt16().NotNullable()
                .WithColumn("xmlAutorizado").AsString().NotNullable();

            Create.ForeignKey("fk_mdfeEmissaoFinalizada__uf")
                .FromTable("mdfeEmissaoFinalizada").ForeignColumn("ufId")
                .ToTable("uf").PrimaryColumn("id");
        }

        public override void Down()
        {
            
        }
    }
}