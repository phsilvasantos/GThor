using GThorFrameworkDominio.Dominios.Pessoas;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    // mapear 6
    public class MdfeCondutor
    {
        public virtual int Id { get; set; }
        public virtual int MdfeId { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual Condutor Condutor { get; set; }
    }
}