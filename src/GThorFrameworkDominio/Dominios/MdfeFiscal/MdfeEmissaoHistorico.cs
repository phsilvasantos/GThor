using System;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.flags;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Flags;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    // todo mapear 7
    public class MdfeEmissaoHistorico
    {
        public virtual int Id { get; set; }
        public virtual int MdfeId { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual string VersaoLayout { get; set; }
        public virtual string ChaveTag { get; set; }
        public virtual string Chave { get; set; }
        public virtual Uf Uf { get; set; }
        public virtual AmbienteSefaz AmbienteSefaz { get; set; }
        public virtual ModeloDocumento ModeloDocumento { get; set; }
        public virtual short Serie { get; set; }
        public virtual long NumeroManifesto { get; set; }
        public virtual int CodigoNumerico { get; set; }
        public virtual byte DigitoVerificador { get; set; }
        public virtual DateTime EmissaoFeitaEm { get; set; }
        public virtual TipoEmissao TipoEmissao { get; set; }
        public virtual string XmlEnvio { get; set; }
        public virtual string XmlRetorno { get; set; }
        public virtual string MensagemRetorno { get; set; }
        public virtual short CodigoAutorizacao { get; set; }
        public virtual string VersaoProcessoEmissao { get; set; }
        public virtual bool Finalizou { get; set; }
    }
}