using GThorFrameworkDominio.Dominios.Cidades;

namespace GThorFrameworkDominio.Dominios.MdfeFiscal
{
    public class MdfeMunicipioCarregamento
    {
        public virtual int Id { get; set; }
        public virtual Mdfe Mdfe { get; set; }
        public virtual Cidade Cidade { get; set; }
    }
}