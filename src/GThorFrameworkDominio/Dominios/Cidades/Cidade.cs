using GThorFrameworkDominio.Dominios.EstadosUf;

namespace GThorFrameworkDominio.Dominios.Cidades
{
    public class Cidade
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int CodigoIbge { get; set; }

        public int UfId { get; set; }

        public Uf Uf { get; set; }
    }
}