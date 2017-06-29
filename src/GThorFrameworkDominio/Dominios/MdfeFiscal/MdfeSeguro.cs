using System.Collections.Generic;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Flags;
using GThorFrameworkDominio.Dominios.MdfeFiscal.Seguro;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    public class MdfeSeguro
    {
        public virtual int Id { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual ResponsavelSeguro Responsavel { get; set; }
        public virtual string DocumentoUnicoResponsavel { get; set; }
        public virtual string Nome { get; set; }
        public virtual string DocumentoUnico { get; set; }
        public virtual string NumeroApolice { get; set; }

        public virtual List<MdfeNumeroAverbacao> Averbacao { get; set; }

    }
}