using GThorFrameworkDominio.Dominios.Pessoas;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    public class MdfeCondutor
    {
        public virtual int Id { get; set; }
        public virtual MdfeVeiculoTracao VeiculoTracao { get; set; }
        public virtual Condutor Condutor { get; set; }
    }
}