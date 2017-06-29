using GThorFrameworkDominio.Dominios.Empresas;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    public class MdfeEmitente
    {
        public virtual int MdfeId { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}