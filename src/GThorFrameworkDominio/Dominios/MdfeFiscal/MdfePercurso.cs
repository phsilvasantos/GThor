using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    public class MdfePercurso
    {
        public virtual int Id { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual Uf Uf { get; set; }
    }
}