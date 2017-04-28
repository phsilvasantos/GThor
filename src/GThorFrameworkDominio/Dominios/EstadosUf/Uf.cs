using GThorFrameworkDominio.Base;

namespace GThorFrameworkDominio.Dominios.EstadosUf
{
    public class Uf : EntidadeDominio
    {
        public virtual int Id { get; set; }

        public virtual string Sigla { get; set; }

        public virtual string Nome { get; set; }

        public virtual byte CodigoIbge { get; set; }

        protected override int IdUnico => Id;
    }
}