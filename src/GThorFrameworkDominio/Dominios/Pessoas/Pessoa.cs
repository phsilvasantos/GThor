using GThorFrameworkDominio.Dominios.Cidades;
using GThorFrameworkDominio.Dominios.EstadosUf;
using GThorFrameworkDominio.Dominios.Pessoas.Flags;

namespace GThorFrameworkDominio.Dominios.Pessoas
{
    public class Pessoa
    {
        public int Id { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

        public string Nome { get; set; }
        public string NomeFantasia { get; set; }

        public string Cnpj { get; set; }
        public string Cpf { get; set; }

        public string InscricaoEstadual { get; set; }

        public int UfId { get; set; }
        public Uf Uf { get; set; }

        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}