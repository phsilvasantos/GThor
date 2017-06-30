using GThorFrameworkDominio.Dominios.MdfeFiscal.Flags;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    // todo mapear 1
    public class MdfeTotal
    {
        public virtual int MdfeId { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual int QuantidadeCte { get; set; } 
        public virtual int QuantidadeNfe { get; set; }
        public virtual decimal ValorTotalCarga { get; set; } // 15,2
        public virtual decimal PesoBrutoCarga { get; set; } // 15,4
        public virtual UnidadeMedida UnidadeMedida { get; set; }

    }
}