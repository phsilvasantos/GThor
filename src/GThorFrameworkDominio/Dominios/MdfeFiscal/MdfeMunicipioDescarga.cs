using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Flags;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    public class MdfeMunicipioDescarga
    {
        public virtual int Id { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual string ChaveAcesso { get; set; }
        public virtual TipoDocumentoEletronico TipoDocumentoEletronico { get; set; }
    }
}