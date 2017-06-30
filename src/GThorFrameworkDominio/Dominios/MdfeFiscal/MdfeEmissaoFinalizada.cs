using System;
using GThorFrameworkDominio.Dominios.DocumentosFiscaisEletronicos.flags;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Flags;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    // todo mapear 8
    public class MdfeEmissaoFinalizada
    {
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
        public virtual string XmlAutorizado { get; set; }
    }
}