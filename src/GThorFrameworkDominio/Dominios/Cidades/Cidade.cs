using GThorFrameworkDominio.Base;
using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThorFrameworkDominio.Dominios.Cidades
{
    public class Cidade : EntidadeDominio
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual int CodigoIbge { get; set; }

        public virtual Uf Uf { get; set; }

        protected override int IdUnico => Id;

        public override string ToString()
        {
            return Nome;
        }
    }
}