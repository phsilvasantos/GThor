using GThorFrameworkDominio.Dominios.MdfeFiscal.Flags;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    public class MdfeTotal
    {
        public virtual int MdfeId { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual int QuantidadeCte { get; set; } 
        public virtual int QuantidadeNfe { get; set; }
        public virtual decimal ValorTotalCarga { get; set; } 
        public virtual decimal PesoBrutoCarga { get; set; } 
        public virtual UnidadeMedida UnidadeMedida { get; set; }

    }
}